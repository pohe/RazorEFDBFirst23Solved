using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Services.DBServices
{
    public class EventService : IEventService
    {
        private EventMakerDB23Context _context;

        public EventService(EventMakerDB23Context context)
        {
            _context = context;
        }

        public List<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Find(id);
        }

        public void AddEvent(Event ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            _context.Events.Remove(GetEvent(id));
            _context.SaveChanges();
        }


        public void UpdateEvent(Event @evt)
        {
            Event oldEvent = _context.Events.Find(evt.Id);
            oldEvent.Id = evt.Id;
            oldEvent.Name = evt.Name;
            oldEvent.City = evt.City;
            oldEvent.Description = evt.Description;
            oldEvent.DateTime = evt.DateTime;
            oldEvent.CountryCode = evt.CountryCode;
            _context.Events.Update(oldEvent);
            _context.SaveChanges();
        }

        public List<Event> FilterEventsByCity(string city)
        {
            return _context.Events.ToList().FindAll(e => e.City == city);
        }

        public List<Event> SearchEventsByCountryCode(string code)
        {
            return _context.Events.ToList().FindAll(e => e.CountryCode == code);
        }
    }
}
