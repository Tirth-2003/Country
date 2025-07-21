
using CountryApp.Data;
using CountryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CountryApp.Controllers
{
    public class CountryController : Controller
    {
        public readonly CountryContext _context;
        public CountryController(CountryContext context)
        {
            _context = context;
        }
        //public IActionResult Index(
        //    int? CountryId,
        //    string? countryCode,
        //    string? countryName,
        //    string? shortCode,
        //    string? currencyCode,
        //    string? currencyName,
        //    //string[] currencySymbol,
        //    string? currencySymbol,
        //    int? currencyId,
        //    string? countryShortCode,
        //    string? countryAlpha3Code,
        //    decimal? riskScore,
        //    bool? ibanExist,
        //    int? ibanLength,
        //    //int? ibanLengthMax,
        //    string? displayNumber,
        //    //int[] dropId, 
        //    string[] DropCode


        //    )
        //{
        //   //TempData["dropId"] = string.Join(",", dropId ?? new int[] { }) ;
        //    TempData["CountryId"] = CountryId;

        //    TempData["Code"] = currencyCode;
        //    TempData["name"] = countryName;
        //    TempData["shortCode"] = shortCode;
        //    TempData["currencyCode"] = currencyCode;
        //    TempData["currencyName"] = currencyName;
        //    //TempData["currencySymbol"] = string.Join(",", currencySymbol ?? new string[] { });
        //    TempData["currencySymbol"] = currencySymbol;
        //    TempData["currencyId"] = currencyId;
        //    TempData["countryShortCode"] = countryShortCode;
        //    TempData["countryAlpha3Code"] = countryAlpha3Code;
        //    TempData["riskScore"] = riskScore;
        //    TempData["ibanExist"] = ibanExist;
        //    TempData["ibanLength"] = ibanLength;
        //    //TempData["ibanLengthMax"] = ibanLengthMax;
        //    TempData["displayNumber"] = displayNumber;

        //    // multi select dropdown
        //    TempData["CountryCode"] = string.Join(",", DropCode ?? new string[] { });


        //    var Data = _context.Countries.AsQueryable();

        //    if (CountryId != null)
        //    {
        //        Data = Data.Where(r => r.CountryId == CountryId);
        //    }

        //    if (!string.IsNullOrEmpty(countryCode))
        //    {
        //        Data = Data.Where(r => r.CountryCode.Contains(countryCode));
        //    }
        //    if (!string.IsNullOrEmpty(countryName))
        //    {
        //        Data = Data.Where(r => r.CountryName.Contains(countryName));
        //    }
        //    if (!string.IsNullOrEmpty(shortCode))
        //    {
        //        Data = Data.Where(r => r.ShortCode.Contains(shortCode));
        //    }
        //    if (!string.IsNullOrEmpty(currencyCode))
        //    {
        //        Data = Data.Where(r => r.CurrencyCode.Contains(currencyCode));
        //    }
        //    if (!string.IsNullOrEmpty(currencyName))
        //    {
        //        Data = Data.Where(r => r.CurrencyName.Contains(currencyName));
        //    }
        //    //if (currencySymbol?.Length > 0)
        //    //{
        //    //    Data = Data.Where(r => currencySymbol.Contains(r.CurrencySymbol));
        //    //}
        //    if (!string.IsNullOrEmpty(currencySymbol))
        //    {
        //        Data = Data.Where(r => r.CurrencySymbol.Contains(currencySymbol));
        //    }

        //    if (currencyId != null)
        //    {
        //        Data = Data.Where(r => r.CurrencyId == currencyId);
        //    }
        //    if (!string.IsNullOrEmpty(countryShortCode))
        //    {
        //        Data = Data.Where(r => r.CountryShortCode.Contains(countryShortCode));
        //    }
        //    if (!string.IsNullOrEmpty(countryAlpha3Code))
        //    {
        //        Data = Data.Where(r => r.CountryAlpha3Code.Contains(countryAlpha3Code));
        //    }
        //    if (riskScore != null)
        //    {
        //        Data = Data.Where(r => r.RiskScore ==  riskScore);
        //    }

        //    if (ibanLength != null)
        //    {
        //        Data = Data.Where(r => r.Ibanlength == ibanLength);
        //    }

        //    if (!string.IsNullOrEmpty(displayNumber))
        //    {
        //        Data = Data.Where(r => r.DisplayNumber.Contains(displayNumber));
        //    }




        //    //MultiSelect(Data);
        //    return View(Data.ToList());
        //}

        public IActionResult Index(
     List<string>? SelectedCountryNames,
     List<string>? SelectedCurrencyCodes,
     List<string>? SelectedCurrencySymbols,
     List<int>? SelectedCountryId,
        List<string>? SelectedCurrencyNames,
        List<string>? SelectedCountryCodes,
        List<string>? SelectedAlpha3Codes,
        int? CountryIdSearch,
     string? CountryNameSearch,
     string? CurrencyCodeSearch,
     string? CurrencySymbolSearch


            )
        {
            var allCountries = _context.Countries.ToList();

            var model = new CountryFilterViewModel
            {
                Countries = allCountries,

                SelectedCountryNames = SelectedCountryNames ?? new(),
                SelectedCurrencyCodes = SelectedCurrencyCodes ?? new(),
                SelectedCurrencySymbols = SelectedCurrencySymbols ?? new(),
                SelectedCountryId = SelectedCountryId ?? new(),
                CountryIdSearch = CountryIdSearch ?? 0, // Default value, can be changed based on your needs
                CountryNameSearch = CountryNameSearch,
                CurrencyCodeSearch = CurrencyCodeSearch,
                CurrencySymbolSearch = CurrencySymbolSearch,
                SelectedCurrencyNames = SelectedCurrencyNames ?? new(),
                SelectedCountryCodes = SelectedCountryCodes ?? new(),
                SelectedAlpha3Codes = SelectedAlpha3Codes ?? new(),

                CountryIdList = allCountries.Select(c => c.CountryId).Distinct()
                    .Select(id => new SelectListItem
                    {
                        Text = id.ToString(),
                        Value = id.ToString(),
                        Selected = SelectedCountryId?.Contains(id) == true
                    }).ToList(),

                CountryNameList = allCountries.Select(c => c.CountryName).Distinct()
                    .Select(name => new SelectListItem
                    {
                        Text = name,
                        Value = name,
                        Selected = SelectedCountryNames?.Contains(name) == true
                    }).ToList(),

                CurrencyCodeList = allCountries.Select(c => c.CurrencyCode).Distinct()
                    .Select(code => new SelectListItem
                    {
                        Text = code,
                        Value = code,
                        Selected = SelectedCurrencyCodes?.Contains(code) == true
                    }).ToList(),

                CurrencyNameList = allCountries.Select(c => new SelectListItem
                {
                    Value = c.CurrencyName,
                    Text = c.CurrencyName
                }).Distinct().ToList(),

                CurrencySymbolList = allCountries.Select(c => c.CurrencySymbol).Distinct()
                    .Select(symbol => new SelectListItem
                    {
                        Text = symbol,
                        Value = symbol,
                        Selected = SelectedCurrencySymbols?.Contains(symbol) == true
                    }).ToList(),

                CountryCodeList = allCountries.Select(c => new SelectListItem
                {
                    Value = c.CountryCode,
                    Text = c.CountryCode
                }).Distinct().ToList(),

                CountryAlpha3CodeList = allCountries.Select(c => new SelectListItem
                {
                    Value = c.CountryAlpha3Code,
                    Text = c.CountryAlpha3Code
                }).Distinct().ToList()
            };


            // Filter by multi-select
            if (SelectedCountryId?.Any() == true)
                model.Countries = model.Countries.Where(c => SelectedCountryId.Contains(c.CountryId)).ToList();
            if (SelectedCountryNames?.Any() == true)
                model.Countries = model.Countries.Where(c => SelectedCountryNames.Contains(c.CountryName)).ToList();

            if (SelectedCurrencyCodes?.Any() == true)
                model.Countries = model.Countries.Where(c => SelectedCurrencyCodes.Contains(c.CurrencyCode)).ToList();

            if (model.SelectedCurrencyNames?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedCurrencyNames.Contains(c.CurrencyName)).ToList();

            if (SelectedCurrencySymbols?.Any() == true)
                model.Countries = model.Countries.Where(c => SelectedCurrencySymbols.Contains(c.CurrencySymbol)).ToList();

            if (model.SelectedCountryCodes?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedCountryCodes.Contains(c.CountryCode)).ToList();

            if (model.SelectedAlpha3Codes?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedAlpha3Codes.Contains(c.CountryAlpha3Code)).ToList();
            // Filter by text input (case-insensitive)


            if (CountryIdSearch.HasValue && CountryIdSearch.Value > 0)
                model.Countries = model.Countries.Where(c => c.CountryId == CountryIdSearch.Value).ToList();
            if (!string.IsNullOrWhiteSpace(CountryNameSearch))
                model.Countries = model.Countries.Where(c => c.CountryName != null && c.CountryName.ToLower().Contains(CountryNameSearch.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(CurrencyCodeSearch))
                model.Countries = model.Countries.Where(c => c.CurrencyCode != null && c.CurrencyCode.ToLower().Contains(CurrencyCodeSearch.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(CurrencySymbolSearch))
                model.Countries = model.Countries.Where(c => c.CurrencySymbol != null && c.CurrencySymbol.ToLower().Contains(CurrencySymbolSearch.ToLower())).ToList();

            return View(model);
        }

    }
}
