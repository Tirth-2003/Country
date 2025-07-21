//using CountryApp.Data;
//using CountryApp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.IdentityModel.Tokens;
//using System.Diagnostics.Metrics;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace CountryApp.Controllers
//{
//    public class CountryController : Controller
//    {
//        public readonly CountryContext _context;
//        public CountryController(CountryContext context)
//        { 
//           _context = context;
//        }
//        public IActionResult Index(
//            int? CountryId,
//            string countryCode,
//            string? countryName)
//        {
//            TempData["CountryId"] = CountryId;
//            TempData["Code"] = countryCode;
//            TempData["name"] = countryName;

//            var Data = _context.Countries.AsQueryable();

//            if (CountryId != null)
//            {
//                Data = Data.Where(r => r.CountryId == CountryId);
//            }
//            if (!string.IsNullOrEmpty(countryCode))
//            {
//                Data = Data.Where(r => r.CountryCode.Contains(countryCode));
//            }
//            if (!string.IsNullOrEmpty(countryName))
//            {
//                Data = Data.Where(r => r.CountryName.Contains(countryName));
//            }

//            //if (!string.IsNullOrEmpty(CName))
//            //{
//            //    Data = Data.Where(r => r.CountryName.Contains(countryName));
//            //}
//            return View(Data.ToList());
//        }


//    }
//}
using CountryApp.Data;
using CountryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            string[] countryCode,
            string? countryName,
            string? shortCode,
            string? currencyCode,
            string? currencyName,
            string[] currencySymbol,
            int? currencyId,
            string? countryShortCode,
            string? countryAlpha3Code,
            decimal? riskScore,
            bool? ibanExist,
            int? ibanLengthMin,
            int? ibanLengthMax,
            string? displayNumber)
        {
            TempData["CountryId"] = CountryId;
            TempData["Code"] = string.Join(",", countryCode ?? new string[] { });
            TempData["name"] = countryName;
            TempData["shortCode"] = shortCode;
            TempData["currencyCode"] = currencyCode;
            TempData["currencyName"] = currencyName;
            TempData["currencySymbol"] = string.Join(",", currencySymbol ?? new string[] { });
            TempData["currencyId"] = currencyId;
            TempData["countryShortCode"] = countryShortCode;
            TempData["countryAlpha3Code"] = countryAlpha3Code;
            TempData["riskScore"] = riskScore;
            TempData["ibanExist"] = ibanExist;
            TempData["ibanLengthMin"] = ibanLengthMin;
            TempData["ibanLengthMax"] = ibanLengthMax;
            TempData["displayNumber"] = displayNumber;

            var Data = _context.Countries.AsQueryable();

            if (CountryId != null)
            {
                Data = Data.Where(r => r.CountryId == CountryId);
            }
            if (countryCode?.Length > 0)
            {
                Data = Data.Where(r => countryCode.Contains(r.CountryCode));
            }
            if (!string.IsNullOrEmpty(countryName))
            {
                Data = Data.Where(r => r.CountryName.Contains(countryName));
            }
            if (!string.IsNullOrEmpty(shortCode))
            {
                Data = Data.Where(r => r.ShortCode.Contains(shortCode));
            }
            if (!string.IsNullOrEmpty(currencyCode))
            {
                Data = Data.Where(r => r.CurrencyCode.Contains(currencyCode));
            }
            if (!string.IsNullOrEmpty(currencyName))
            {
                Data = Data.Where(r => r.CurrencyName.Contains(currencyName));
            }
            if (currencySymbol?.Length > 0)
            {
                Data = Data.Where(r => currencySymbol.Contains(r.CurrencySymbol));
            }
            if (currencyId != null)
            {
                Data = Data.Where(r => r.CurrencyId == currencyId);
            }
            if (!string.IsNullOrEmpty(countryShortCode))
            {
                Data = Data.Where(r => r.CountryShortCode.Contains(countryShortCode));
            }
            if (!string.IsNullOrEmpty(countryAlpha3Code))
            {
                Data = Data.Where(r => r.CountryAlpha3Code.Contains(countryAlpha3Code));
            }
            if (riskScore != null)
            {
                Data = Data.Where(r => r.RiskScore == riskScore);
            }
            if (ibanExist != null)
            {
                Data = Data.Where(r => r.Ibanexist == ibanExist);
            }
            if (ibanLengthMin != null || ibanLengthMax != null)
            {
                Data = Data.Where(r => (ibanLengthMin == null || r.Ibanlength >= ibanLengthMin) &&
                                      (ibanLengthMax == null || r.Ibanlength <= ibanLengthMax));
            }
            if (!string.IsNullOrEmpty(displayNumber))
            {
                Data = Data.Where(r => r.DisplayNumber.Contains(displayNumber));
            }

            return View(Data.ToList());
        }
    }
}
