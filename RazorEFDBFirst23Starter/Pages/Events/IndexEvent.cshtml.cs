using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Pages.Events
{
    public class IndexEventModel : PageModel
    {
        IEventService repo;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexEventModel(IEventService repository)
        {
            repo = repository;
        }
        public List<Event> Events { get; private set; }
        public IActionResult OnGet()
        {
            Events = repo.GetAllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEventsByCity(FilterCriteria);
            }
            return Page();
        }
        public IActionResult OnGetMyEvents(string code)
        {
            Events = new List<Event>();
            if (code == null)
            {
                return NotFound();
            }
            Events = repo.SearchEventsByCountryCode(code);
            return Page();
        }
    }
}
