using CountryApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountryApp.Repositories
{
    public interface ICountry
    {
        Task<IEnumerable<Models.Country>> GetCountry();

        //Task<IEnumerable<Models.Country>> SearchCountry(int id, string Countrycode,  string countryname);
        Task<IEnumerable<Models.Country>> SearchCountry(CountryViewModel model);

        //Task<IEnumerable<Models.Country>> SearchMultiselect(CountryViewModel model);
    }
}
