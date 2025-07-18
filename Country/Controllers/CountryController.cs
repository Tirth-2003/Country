using CountryApp.Data;
using CountryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CountryApp.Controllers
{
    public class CountryController : Controller
    {
        public readonly CountryContext _context;
        public CountryController(CountryContext context)
        { 
           _context = context;
        }
        public IActionResult Index(
            int? CountryId,
            string countryCode,
            string? countryName)
        {
            TempData["CountryId"] = CountryId;
            TempData["Code"] = countryCode;
            TempData["name"] = countryName;

            var Data = _context.Countries.AsQueryable();

            if (CountryId != null)
            {
                Data = Data.Where(r => r.CountryId == CountryId);
            }
            if (!string.IsNullOrEmpty(countryCode))
            {
                Data = Data.Where(r => r.CountryCode.Contains(countryCode));
            }
            if (!string.IsNullOrEmpty(countryName))
            {
                Data = Data.Where(r => r.CountryName.Contains(countryName));
            }
            
            //if (!string.IsNullOrEmpty(CName))
            //{
            //    Data = Data.Where(r => r.CountryName.Contains(countryName));
            //}
            return View(Data.ToList());
        }

        
    }
}
