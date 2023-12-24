using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Context;
using TicketingApp.Models.Repository;

namespace TicketingApp.Models.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string Nama { get; set; }
        public string NoTlp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public void BayarTicket()
        {

        }

        public void EditProfile()
        {

        }

    }

}
