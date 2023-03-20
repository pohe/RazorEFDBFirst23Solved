using Microsoft.EntityFrameworkCore;
using RazorEFDBFirst23Starter.Interfaces;
using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Services.DBServices
{
    public class CountryService : ICountryService
    {
        private EventMakerDB23Context _context;

        public CountryService(EventMakerDB23Context context)
        {
            _context = context;
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(string code)
        {
            Country countryToRemove = _context.Countries.Find(code);
            _context.Countries.Remove(countryToRemove);
            _context.SaveChanges();
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.Include(c => c.Events).ToList();
        }

        public Country GetCountry(string code)
        {
            return _context.Countries.Find(code);
        }
    }
}
