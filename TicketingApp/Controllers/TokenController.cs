using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Repository;
using TicketingApp.Utils;
using TicketingApp.Models.Context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TicketingApp.Controllers
{
    public class TokenController
    {
        public UserRepository _repository;
        public bool GenerateToken(string email)
        {
            Random random = new Random();
            int token = random.Next(100000, 999999);
            SendEmail.SendEmailToken(token);
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                int result = _repository.PushToken(email, token);
                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }          
        }

        public bool VerifyToken(string email, int token, string newPassword)
        {
            using (DbContext context = new DbContext())
            {
                _repository = new UserRepository(context);
                int result = _repository.GetToken(email, token);
                if (result > 0)
                {
                    int isUpdated = _repository.UpdatePassword(email, newPassword);
                    if (isUpdated > 0)
                    {
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
