using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        IEventService repo;

        [BindProperty]
        public Event Event { get; set; }
        public CreateEventModel(IEventService repository)
        {
            repo = repository;
            Event = new Event();
        }
        public IActionResult OnGet(string Code)
        {
            Event.CountryCode = Code;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.AddEvent(Event);
            return RedirectToPage("IndexEvent");
        }
    }
}
