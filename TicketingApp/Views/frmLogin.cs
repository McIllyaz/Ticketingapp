using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketingApp.Controllers;
using TicketingApp.Models.Entity;

namespace TicketingApp.Views
{
    public partial class frmLogin : Form
    {
        UserController controller;

        public frmLogin()
        {
            InitializeComponent();;
            controller = new UserController();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            UserController controller = new UserController();

            bool isValidUser = controller.Login(txtEmail.Text, txtPassword.Text);
            if (isValidUser)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                frmHome frm = new frmHome();
                frm.ShowDialog();
            }
        }

        private void btnTestRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Nama = "arya";
            user.Password = "test";
            user.NoTlp = "90128390812";
            user.Email = "arya@mail.com";

            UserController controller = new UserController();
            bool result = controller.Register(user);
            if(result)
            {
                MessageBox.Show("User berhasil ditambahkan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            } 
            else
            {
                MessageBox.Show("User gagal ditambahkan !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTestPw_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Nama = "arya";
            user.Password = "test";
            user.NoTlp = "90128390812";
            user.Email = "arya@mail.com";
            //bool result = controller.
        }
    }
}
