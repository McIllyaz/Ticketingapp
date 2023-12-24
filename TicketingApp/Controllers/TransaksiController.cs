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
	public class TransaksiController
	{
        public TransaksiRepository _repository;

        public int CreateTransaksi(List<Transaksi> newTransaksi)
        {
            using (DbContext context = new DbContext())
            {
                return _repository.CreateTransaksi(newTransaksi);
            }
        }

        public bool datajpg()
        {
            return SendEmail.datajpg();
        }
    }
}