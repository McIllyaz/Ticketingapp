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
	public class EventController
	{
		public EventRepository _repository;

		public List<Event> ReadAllEvents(int offset)
		{
            return _repository.ReadAllEvents(offset);
        }

        public List<Event> ReadPopularEvents()
        {
            return _repository.ReadPopularEvents();
        }

        public List<Event> GetEventBySearch(string content)
        {
            return _repository.GetEventBySearch(content);
        }

        public int AddEvent(Event newEvent)
        {
            return _repository.AddEvent(newEvent);
        }

        public int DeleteEvent(Event eventToDelete)
        {
            return _repository.DeleteEvent(eventToDelete);
        }

        public bool SoldEvent(Event eventToBuy)
        {
            eventToBuy.Stock--;

            using (DbContext context = new DbContext())
            {
                int result = _repository.UpdateStock(eventToBuy);
                if(result > 1)
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

