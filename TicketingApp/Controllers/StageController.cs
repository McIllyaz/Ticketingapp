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

namespace TicketingApp.Controllers
{
	public class StageController
	{
        public StageRepository _repository;

        public List<Stage> ReadStageEvent(string eventId)
        {
            return _repository.ReadStageEvent(eventId);
        }
	}
}

