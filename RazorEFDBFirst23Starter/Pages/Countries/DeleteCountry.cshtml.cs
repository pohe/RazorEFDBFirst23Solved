using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Pages.Countries
{
    public class DeleteCountryModel : PageModel
    {
        ICountryService repo;

        [BindProperty]
        public Country Country { get; set; }

        public DeleteCountryModel(ICountryService repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(string code)
        {
            Country = repo.GetCountry(code);
            return Page();
        }

        public IActionResult OnPost(string code)
        {
            if (Country != null)
            {
                repo.DeleteCountry(code);
            }

            return RedirectToPage("IndexCountry");
        }
    }
}
