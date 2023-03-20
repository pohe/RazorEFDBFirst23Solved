using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Pages.Events
{
    public class DeleteEventModel : PageModel
    {
        IEventService repo;
        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventModel(IEventService repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            repo.DeleteEvent(id);
            return RedirectToPage("IndexEvent");
        }
    }
}
