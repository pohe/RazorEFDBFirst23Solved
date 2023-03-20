using RazorEFDBFirst23Starter.Models;

namespace RazorEFDBFirst23Starter.Interfaces
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
        Country GetCountry(string code);
        void DeleteCountry(string code);
        void AddCountry(Country country);
    }
}
