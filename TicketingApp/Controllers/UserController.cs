using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Entity;
using TicketingApp.Models.Repository;
using TicketingApp.Models.Context;
using System.Windows.Forms;
using TicketingApp.Views;
using TicketingApp.Utils;

namespace TicketingApp.Controllers
{
    public class UserController
    {
        public UserRepository _repository;

        public bool Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User name harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool isValidUser = false;

            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);

                isValidUser = _repository.GetUserToLogin(userName, password);
            }

            if (!isValidUser)
            {
                MessageBox.Show("User name atau password salah !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        public void Logout()
        {
            Application.Run(new frmLogin());
        }

        public bool Register(User newUser)
        { using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                string newId = RandomID.Generate();
                int result = _repository.RegisterNewUser(newUser, newId);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        }
    }
}
