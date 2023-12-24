using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Models.Entity
{
    public class Stage
    {
        public string Id { get; set; }
        public string Nama { get; set; }
        public int Kapasitas { get; set; }
        public int Harga { get; set; }
    }
}
