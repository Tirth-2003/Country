using CountryApp.Data;
using CountryApp.Models;
using CountryApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CountryApp.Controllers
{
    public class SpCountryController : Controller
    {


        private readonly ICountry _context;

        public SpCountryController(ICountry context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index(int? id, string Countrycode, string countryname)
        //{
        //    var Data = await ((id.HasValue || !string.IsNullOrEmpty(Countrycode) || !string.IsNullOrEmpty(countryname)) ? _context.SearchCountry(id ?? 0, Countrycode, countryname)
        //        : _context.GetCountry());
        //    return View(Data);
        //}

        //public async Task<IActionResult> Index(CountryFilterViewModel model)
        //{

        //    if (model.CountryIdSearch.HasValue ||
        //         !string.IsNullOrEmpty(model.CountryCodeSearch) ||
        //        !string.IsNullOrEmpty(model.CountryNameSearch) ||
        //        !string.IsNullOrEmpty(model.ShortCodeSearch) ||
        //        !string.IsNullOrEmpty(model.CurrencyCodeSearch) ||
        //        !string.IsNullOrEmpty(model.CurrencyNameSearch) ||

        //        //!string.IsNullOrEmpty(model.CurrencySymbolSearch) ||
        //        model.CurrencyIdSearch.HasValue ||
        //        !string.IsNullOrEmpty(model.CountryShortCodeSearch) ||
        //        !string.IsNullOrEmpty(model.CountryAlpha3CodeSearch) ||
        //        model.RiskScoreSearch.HasValue ||
        //        model.IbanLengthSearch > 0 ||
        //        !string.IsNullOrEmpty(model.DisplayNumberSearch))
        //    {
        //        model.Countries = await _context.SearchCountry(model);
        //    }
        //    else
        //    {
        //        model.Countries = await _context.GetCountry();
        //    }


        //    return View(model);
        //}


        public async Task<IActionResult> Index(CountryViewModel model)
        {
            if (model == null)
            {
                model = new CountryViewModel();
            }

            // Populate dropdown options
            model.Countries = await _context.GetCountry();


            
            model.CountryNameList = model.Countries.Select(c =>
                new SelectListItem { Value = c.CountryName, Text = c.CountryName }).ToList();
            model.CountryCodeList = model.Countries.Select(c =>
                new SelectListItem { Value = c.CountryCode, Text = c.CountryCode }).ToList();
            model.ShortCodeList = model.Countries.Select(c => 
                new SelectListItem { Value = c.ShortCode, Text = c.ShortCode }).ToList();
            model.CurrencyCodeList = model.Countries.Select(c => 
                new SelectListItem { Value = c.CurrencyCode, Text = c.CurrencyCode }).ToList();
            model.CurrencyNameList = model.Countries.Select(c =>
                new SelectListItem { Value = c.CurrencyName, Text = c.CurrencyName }).ToList();
            model.CurrencySymbolList = model.Countries.Select(c => 
                new SelectListItem { Value = c.CurrencySymbol, Text = c.CurrencySymbol }).ToList();
            model.CountryShortCodeList = model.Countries.Select(c => 
                new SelectListItem { Value = c.CountryShortCode, Text = c.CountryShortCode }).ToList();
            model.CountryAlpha3CodeList = model.Countries.Select(c =>
                new SelectListItem { Value = c.CountryAlpha3Code, Text = c.CountryAlpha3Code }).ToList();
            model.DisplayNumberList = model.Countries.Select(c => 
                new SelectListItem { Value = c.DisplayNumber, Text = c.DisplayNumber }).ToList();
            model.RiskScoreList = model.Countries.Select(c =>
                new SelectListItem { Value = c.RiskScore.ToString(), Text = c.RiskScore.ToString() }).ToList();
            model.IbanLengthList = model.Countries.Where(c =>c.Ibanlength.HasValue).Select(c => 
                new SelectListItem { Value = c.Ibanlength.ToString(), Text = c.Ibanlength.ToString() }).ToList();
            model.CountryIdList = model.Countries.Select(c =>
                new SelectListItem { Value = c.CountryId.ToString(), Text = c.CountryId.ToString() }).ToList();
            model.CurrencyIdList = model.Countries.Where(c => c.CurrencyId.HasValue).Select(c =>
                new SelectListItem { Value = c.CurrencyId.ToString(), Text = c.CurrencyId.ToString() }).ToList();

            // Handle search
            if (model.CountryIdSearch.HasValue ||
                !string.IsNullOrEmpty(model.CountryNameSearch) ||
                !string.IsNullOrEmpty(model.CountryCodeSearch) ||
                !string.IsNullOrEmpty(model.ShortCodeSearch) ||
                !string.IsNullOrEmpty(model.CurrencyCodeSearch) ||
                !string.IsNullOrEmpty(model.CurrencyNameSearch) ||
                !string.IsNullOrEmpty(model.CurrencySymbolSearch) ||
                model.CurrencyIdSearch.HasValue ||
                !string.IsNullOrEmpty(model.CountryShortCodeSearch) ||
                !string.IsNullOrEmpty(model.CountryAlpha3CodeSearch) ||
                model.RiskScoreSearch.HasValue ||
                model.IbanExistsSearch.HasValue ||
                model.IbanLengthSearch.HasValue ||
                !string.IsNullOrEmpty(model.DisplayNumberSearch) ||

                model.SelectedCountryNames.Any() ||
                model.SelectedCountryCodes.Any() ||
                model.SelectedShortCodes.Any() ||
                model.SelectedCurrencyCodes.Any() ||
                model.SelectedCurrencyNames.Any() ||
                model.SelectedCurrencySymbols.Any() ||
                model.SelectedCountryShortCodes.Any() ||
                model.SelectedAlpha3Codes.Any() || 
                model.SelectedRiskScores.Any() ||
                model.SelectedCurrencyIds.Any() ||
                model.SelectedCountryIds.Any())
            {
                model.Countries = (await _context.SearchCountry(model)).ToList();
            }
            else
            {
                model.Countries = (await _context.GetCountry()).ToList();
            }

            return View(model);
        }


    }
}
