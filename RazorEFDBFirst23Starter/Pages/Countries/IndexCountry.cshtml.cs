using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Pages.Countries
{
    public class IndexCountryModel : PageModel
    {
        ICountryService repo;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IndexCountryModel(ICountryService repository)
        {
            repo = repository;
        }

        public List<Country> Countries { get; private set; }
        public IActionResult OnGet()
        {
            Countries = repo.GetAllCountries();
            return Page();
        }
    }
}
