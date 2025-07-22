
//using CountryApp.Data;
//using CountryApp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
//using System.Linq;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace CountryApp.Controllers
//{
//    public class CountryController : Controller
//    {
//        public readonly CountryContext _context;
//        public CountryController(CountryContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(
//     List<string>? SelectedCountryNames,
//     List<string>? SelectedCurrencyCodes,
//     List<string>? SelectedCurrencySymbols,
//     List<int>? SelectedCountryId,
//        List<string>? SelectedCurrencyNames,
//        List<string>? SelectedCountryCodes,
//        List<string>? SelectedAlpha3Codes,
//        List<string>? SelectedShortCodes,
//        List<string>? SelectedDisplayNumbers,
//        List<string>? SelectedRiskScores,
//        List<bool>? SelectedIbanExists,
//        List<string>? SelectedIbanLengths,
//        List<string>? SelectedCountryShortCodes,
//        List<int>? SelectedCurrencyId,

//        int? CountryIdSearch,
//     string? CountryNameSearch,
//     string? CurrencyCodeSearch,
//     string? CurrencySymbolSearch,
//        string? CountryCodeSearch,
//        string? CountryAlpha3CodeSearch,
//        string? CurrencyNameSearch,
//        string? ShortCodeSearch,
//        string? DisplayNumberSearch,
//        decimal? RiskScoreSearch,
//        bool? IbanExistsSearch,
//        string? IbanLengthSearch,
//        string? CountryShortCodeSearch,
//        int? CurrencyIdSearch


//            )
//        {
//            var allCountries = _context.Countries.ToList();

//            var model = new CountryFilterViewModel
//            {
//                Countries = allCountries,

//                SelectedCountryNames = SelectedCountryNames ?? new(),
//                SelectedCurrencyCodes = SelectedCurrencyCodes ?? new(),
//                SelectedCurrencySymbols = SelectedCurrencySymbols ?? new(),
//                SelectedCountryId = SelectedCountryId ?? new(),
//                SelectedCurrencyNames = SelectedCurrencyNames ?? new(),
//                SelectedCountryCodes = SelectedCountryCodes ?? new(),
//                SelectedAlpha3Codes = SelectedAlpha3Codes ?? new(),
//                SelectedShortCodes = SelectedShortCodes ?? new(),
//                SelectedDisplayNumbers = SelectedDisplayNumbers ?? new(),
//                SelectedRiskScores = SelectedRiskScores ?? new(),
//                SelectedIbanExists = SelectedIbanExists ?? new(),
//                SelectedIbanLengths = SelectedIbanLengths ?? new(),
//                SelectedCountryShortCodes = SelectedCountryShortCodes ?? new(),
//                SelectedCurrencyId = SelectedCurrencyId ?? new(),

//                CountryIdSearch = CountryIdSearch ?? 0,
//                CountryCodeSearch = CountryCodeSearch,
//                CountryNameSearch = CountryNameSearch,
//                ShortCodeSearch = ShortCodeSearch,

//                CurrencyCodeSearch = CurrencyCodeSearch,
//                CurrencyNameSearch = CurrencyNameSearch,
//                CurrencySymbolSearch = CurrencySymbolSearch,

//                CurrencyIdSearch = CurrencyIdSearch ?? 0,    
//                CountryAlpha3CodeSearch = CountryAlpha3CodeSearch,
//                CountryShortCodeSearch = CountryShortCodeSearch,

//                DisplayNumberSearch = DisplayNumberSearch,
//                RiskScoreSearch = RiskScoreSearch,

//                IbanExistsSearch = IbanExistsSearch,
//                IbanLengthSearch = IbanLengthSearch,


//                CountryIdList = allCountries.Select(c => c.CountryId).Distinct()
//                    .Select(id => new SelectListItem
//                    {
//                        Text = id.ToString(),
//                        Value = id.ToString(),
//                        Selected = SelectedCountryId?.Contains(id) == true
//                    }).ToList(),

//                CountryNameList = allCountries.Select(c => c.CountryName).Distinct()
//                    .Select(name => new SelectListItem
//                    {
//                        Text = name,
//                        Value = name,
//                        Selected = SelectedCountryNames?.Contains(name) == true
//                    }).ToList(),

//                CountryCodeList = allCountries.Select(c => c.CountryCode).Distinct()
//                    .Select(code => new SelectListItem
//                    {
//                        Text = code,
//                        Value = code,
//                        Selected = SelectedCountryCodes?.Contains(code) == true
//                    }).ToList(),

//                ShortCodeList = allCountries.Select(c => c.ShortCode).Distinct()
//                    .Select(shortCode => new SelectListItem
//                    {
//                        Text = shortCode,
//                        Value = shortCode,
//                        Selected = SelectedShortCodes?.Contains(shortCode) == true
//                    }).ToList(),

//                CurrencyCodeList = allCountries.Select(c => c.CurrencyCode).Distinct()
//                    .Select(code => new SelectListItem
//                    {
//                        Text = code,
//                        Value = code,
//                        Selected = SelectedCurrencyCodes?.Contains(code) == true
//                    }).ToList(),

//                CurrencyNameList = allCountries.Select(c => c.CurrencyName).Distinct()
//                    .Select(name => new SelectListItem
//                    {
//                        Text = name,
//                        Value = name,
//                        Selected = SelectedCurrencyNames?.Contains(name) == true
//                    }).ToList(),

//                CurrencySymbolList = allCountries.Select(c => c.CurrencySymbol).Distinct()
//                    .Select(symbol => new SelectListItem
//                    {
//                        Text = symbol,
//                        Value = symbol,
//                        Selected = SelectedCurrencySymbols?.Contains(symbol) == true
//                    }).ToList(),

//                CurrencyIdList = allCountries.Select(c => c.CurrencyId).Distinct()
//                    .Select(id => new SelectListItem
//                    {
//                        Text = id.ToString(),
//                        Value = id.ToString(),
//                        Selected = SelectedCurrencyId.Contains((int)id) == true
//                    }).ToList(),


//                CountryShortCodeList = allCountries.Select(c => c.CountryShortCode).Distinct()
//                    .Select(shortCode => new SelectListItem
//                    {
//                        Text = shortCode,
//                        Value = shortCode,
//                        Selected = SelectedCountryShortCodes?.Contains(shortCode) == true
//                    }).ToList(),

//                CountryAlpha3CodeList = allCountries.Select(c => new SelectListItem
//                {
//                    Value = c.CountryAlpha3Code,
//                    Text = c.CountryAlpha3Code
//                }).Distinct().ToList(),

//                RiskScoreList = allCountries.Select(c => c.RiskScore?.ToString() ?? string.Empty).Distinct()
//                    .Select(riskScore => new SelectListItem
//                    {
//                        Text = riskScore,
//                        Value = riskScore,
//                        Selected = SelectedRiskScores?.Contains(riskScore) == true
//                    }).ToList(),



//                IbanLengthList = allCountries.Select(c => c.Ibanlength.HasValue ? c.Ibanlength.Value.ToString() : string.Empty).Distinct()
//                    .Select(ibanLength => new SelectListItem
//                    {
//                        Text = ibanLength,
//                        Value = ibanLength,
//                        Selected = SelectedIbanLengths?.Contains(ibanLength) == true
//                    }).ToList(),

//                DisplayNumberList = allCountries.Select(c => c.DisplayNumber).Distinct()
//                    .Select(displayNumber => new SelectListItem
//                    {
//                        Text = displayNumber,
//                        Value = displayNumber,
//                        Selected = SelectedDisplayNumbers?.Contains(displayNumber) == true
//                    }).ToList(),

//            };


//            // Filter by multi-select
//            if (SelectedCountryId?.Any() == true)
//                model.Countries = model.Countries.Where(c => SelectedCountryId.Contains(c.CountryId)).ToList();

//            if (SelectedCountryNames?.Any() == true)
//                model.Countries = model.Countries.Where(c => SelectedCountryNames.Contains(c.CountryName)).ToList();

//            if (SelectedCurrencyCodes?.Any() == true)
//                model.Countries = model.Countries.Where(c => SelectedCurrencyCodes.Contains(c.CurrencyCode)).ToList();

//            if (model.SelectedCurrencyNames?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedCurrencyNames.Contains(c.CurrencyName)).ToList();

//            if (SelectedCurrencySymbols?.Any() == true)
//                model.Countries = model.Countries.Where(c => SelectedCurrencySymbols.Contains(c.CurrencySymbol)).ToList();

//            if (model.SelectedCountryCodes?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedCountryCodes.Contains(c.CountryCode)).ToList();

//            if (model.SelectedAlpha3Codes?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedAlpha3Codes.Contains(c.CountryAlpha3Code)).ToList();

//            if (model.SelectedCurrencyId?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedCurrencyId.Contains((int)c.CurrencyId)).ToList();

//            if (model.SelectedShortCodes?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedShortCodes.Contains(c.ShortCode)).ToList();
//            if (model.SelectedDisplayNumbers?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedDisplayNumbers.Contains(c.DisplayNumber)).ToList();
//            if (model.SelectedRiskScores?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedRiskScores.Contains(c.RiskScore?.ToString() ?? string.Empty)).ToList();

//            if (model.SelectedIbanLengths?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedIbanLengths.Contains(c.Ibanlength.HasValue ? c.Ibanlength.Value.ToString() : string.Empty)).ToList();
//            if (model.SelectedCountryShortCodes?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedCountryShortCodes.Contains(c.CountryShortCode)).ToList();
//            if (model.SelectedCountryNames?.Any() == true)
//                model.Countries = model.Countries.Where(c => model.SelectedCountryNames.Contains(c.CountryName)).ToList();

//            // Filter by text input (case-insensitive)


//            if (CountryIdSearch.HasValue && CountryIdSearch.Value > 0)
//                model.Countries = model.Countries.Where(c => c.CountryId == CountryIdSearch.Value).ToList();
//            if (!string.IsNullOrWhiteSpace(CountryNameSearch))
//                model.Countries = model.Countries.Where(c => c.CountryName != null && c.CountryName.ToLower().Contains(CountryNameSearch.ToLower())).ToList();

//            if (!string.IsNullOrWhiteSpace(CurrencyCodeSearch))
//                model.Countries = model.Countries.Where(c => c.CurrencyCode != null && c.CurrencyCode.ToLower().Contains(CurrencyCodeSearch.ToLower())).ToList();

//            if (!string.IsNullOrWhiteSpace(CurrencySymbolSearch))
//                model.Countries = model.Countries.Where(c => c.CurrencySymbol != null && c.CurrencySymbol.ToLower().Contains(CurrencySymbolSearch.ToLower())).ToList();

//            if (!string.IsNullOrWhiteSpace(CountryCodeSearch))
//                model.Countries = model.Countries.Where(c => c.CountryCode != null && c.CountryCode.ToLower().Contains(CountryCodeSearch.ToLower())).ToList();
//            if (!string.IsNullOrWhiteSpace(CountryAlpha3CodeSearch))
//                model.Countries = model.Countries.Where(c => c.CountryAlpha3Code != null && c.CountryAlpha3Code.ToLower().Contains(CountryAlpha3CodeSearch.ToLower())).ToList();
//            if (!string.IsNullOrWhiteSpace(CurrencyNameSearch))
//                model.Countries = model.Countries.Where(c => c.CurrencyName != null && c.CurrencyName.ToLower().Contains(CurrencyNameSearch.ToLower())).ToList();
//            if (!string.IsNullOrWhiteSpace(ShortCodeSearch))
//                model.Countries = model.Countries.Where(c => c.ShortCode != null && c.ShortCode.ToLower().Contains(ShortCodeSearch.ToLower())).ToList();
//            if (!string.IsNullOrWhiteSpace(DisplayNumberSearch))
//                model.Countries = model.Countries.Where(c => c.DisplayNumber != null && c.DisplayNumber.ToLower().Contains(DisplayNumberSearch.ToLower())).ToList();
//            if (RiskScoreSearch != null)
//                model.Countries = model.Countries.Where(c => c.RiskScore  == RiskScoreSearch).ToList();
//            if (IbanExistsSearch.HasValue)
//                model.Countries = model.Countries.Where(c => c.Ibanexist.HasValue && c.Ibanexist.Value == IbanExistsSearch.Value).ToList();
//            if (!string.IsNullOrWhiteSpace(IbanLengthSearch))
//                model.Countries = model.Countries.Where(c => c.Ibanlength.HasValue && c.Ibanlength.Value.ToString() == IbanLengthSearch).ToList();
//            if (!string.IsNullOrWhiteSpace(CountryShortCodeSearch))
//                model.Countries = model.Countries.Where(c => c.CountryShortCode != null && c.CountryShortCode.ToLower().Contains(CountryShortCodeSearch.ToLower())).ToList();
//            if (CurrencyIdSearch.HasValue && CurrencyIdSearch.Value > 0)
//                model.Countries = model.Countries.Where(c => c.CurrencyId == CurrencyIdSearch.Value).ToList();


//            return View(model);
//        }

//    }
//}


using CountryApp.Data;
using CountryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CountryApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryContext _context;

        public CountryController(CountryContext context)
        {
            _context = context;
        }

        public IActionResult Index(CountryFilterViewModel model)
        {
            var countries = _context.Countries.ToList();

            // Apply multi-select filters
            if (model.SelectedCountryId?.Any() == true)
                countries = countries.Where(c => model.SelectedCountryId.Contains(c.CountryId)).ToList();

            if (model.SelectedCountryNames?.Any() == true)
                countries = countries.Where(c => model.SelectedCountryNames.Contains(c.CountryName)).ToList();

            if (model.SelectedCurrencyCodes?.Any() == true)
                countries = countries.Where(c => model.SelectedCurrencyCodes.Contains(c.CurrencyCode)).ToList();

            if (model.SelectedCurrencyNames?.Any() == true)
                countries = countries.Where(c => model.SelectedCurrencyNames.Contains(c.CurrencyName)).ToList();

            if (model.SelectedCurrencySymbols?.Any() == true)
                countries = countries.Where(c => model.SelectedCurrencySymbols.Contains(c.CurrencySymbol)).ToList();

            if (model.SelectedCountryCodes?.Any() == true)
                countries = countries.Where(c => model.SelectedCountryCodes.Contains(c.CountryCode)).ToList();

            if (model.SelectedAlpha3Codes?.Any() == true)
                countries = countries.Where(c => model.SelectedAlpha3Codes.Contains(c.CountryAlpha3Code)).ToList();

            if (model.SelectedCurrencyId?.Any() == true)
                countries = countries.Where(c => model.SelectedCurrencyId.Contains((int)c.CurrencyId)).ToList();

            if (model.SelectedShortCodes?.Any() == true)
                countries = countries.Where(c => model.SelectedShortCodes.Contains(c.ShortCode)).ToList();

            if (model.SelectedDisplayNumbers?.Any() == true)
                countries = countries.Where(c => model.SelectedDisplayNumbers.Contains(c.DisplayNumber)).ToList();

            if (model.SelectedRiskScores?.Any() == true)
                countries = countries.Where(c => model.SelectedRiskScores.Contains(c.RiskScore?.ToString() ?? string.Empty)).ToList();

            if (model.SelectedIbanLengths?.Any() == true)
                countries = countries.Where(c => model.SelectedIbanLengths.Contains(c.Ibanlength?.ToString())).ToList();

            if (model.SelectedCountryShortCodes?.Any() == true)
                countries = countries.Where(c => model.SelectedCountryShortCodes.Contains(c.CountryShortCode)).ToList();

            // Apply text-based filters
            if (model.CountryIdSearch > 0)
                countries = countries.Where(c => c.CountryId == model.CountryIdSearch).ToList();

            if (!string.IsNullOrWhiteSpace(model.CountryNameSearch))
                countries = countries.Where(c => c.CountryName?.ToLower().Contains(model.CountryNameSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.CurrencyCodeSearch))
                countries = countries.Where(c => c.CurrencyCode?.ToLower().Contains(model.CurrencyCodeSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.CurrencySymbolSearch))
                countries = countries.Where(c => c.CurrencySymbol?.ToLower().Contains(model.CurrencySymbolSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.CountryCodeSearch))
                countries = countries.Where(c => c.CountryCode?.ToLower().Contains(model.CountryCodeSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.CountryAlpha3CodeSearch))
                countries = countries.Where(c => c.CountryAlpha3Code?.ToLower().Contains(model.CountryAlpha3CodeSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.CurrencyNameSearch))
                countries = countries.Where(c => c.CurrencyName?.ToLower().Contains(model.CurrencyNameSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.ShortCodeSearch))
                countries = countries.Where(c => c.ShortCode?.ToLower().Contains(model.ShortCodeSearch.ToLower()) == true).ToList();

            if (!string.IsNullOrWhiteSpace(model.DisplayNumberSearch))
                countries = countries.Where(c => c.DisplayNumber?.ToLower().Contains(model.DisplayNumberSearch.ToLower()) == true).ToList();

            if (model.RiskScoreSearch.HasValue)
                countries = countries.Where(c => c.RiskScore == model.RiskScoreSearch).ToList();

            if (model.IbanExistsSearch.HasValue)
                countries = countries.Where(c => c.Ibanexist == model.IbanExistsSearch).ToList();

            if (!string.IsNullOrWhiteSpace(model.IbanLengthSearch))
                countries = countries.Where(c => c.Ibanlength?.ToString() == model.IbanLengthSearch).ToList();

            if (!string.IsNullOrWhiteSpace(model.CountryShortCodeSearch))
                countries = countries.Where(c => c.CountryShortCode?.ToLower().Contains(model.CountryShortCodeSearch.ToLower()) == true).ToList();

            if (model.CurrencyIdSearch > 0)
                countries = countries.Where(c => c.CurrencyId == model.CurrencyIdSearch).ToList();

            model.Countries = countries;

            PopulateDropdowns(model);

            return View(model);
        }

        private void PopulateDropdowns(CountryFilterViewModel model)
        {
            var allCountries = _context.Countries.ToList();

            model.CountryIdList = allCountries.Select(c => c.CountryId.ToString()).Distinct()
                .Select(id => new SelectListItem { Text = id, Value = id }).ToList();

            model.CountryNameList = allCountries.Select(c => c.CountryName).Distinct()
                .Select(name => new SelectListItem { Text = name, Value = name }).ToList();

            model.CountryCodeList = allCountries.Select(c => c.CountryCode).Distinct()
                .Select(code => new SelectListItem { Text = code, Value = code }).ToList();

            model.ShortCodeList = allCountries.Select(c => c.ShortCode).Distinct()
                .Select(shortCode => new SelectListItem { Text = shortCode, Value = shortCode }).ToList();

            model.CurrencyCodeList = allCountries.Select(c => c.CurrencyCode).Distinct()
                .Select(code => new SelectListItem { Text = code, Value = code }).ToList();

            model.CurrencyNameList = allCountries.Select(c => c.CurrencyName).Distinct()
                .Select(name => new SelectListItem { Text = name, Value = name }).ToList();

            model.CurrencySymbolList = allCountries.Select(c => c.CurrencySymbol).Distinct()
                .Select(symbol => new SelectListItem { Text = symbol, Value = symbol }).ToList();

            model.CurrencyIdList = allCountries.Select(c => c.CurrencyId?.ToString()).Distinct()
                .Select(id => new SelectListItem { Text = id, Value = id }).ToList();

            model.CountryShortCodeList = allCountries.Select(c => c.CountryShortCode).Distinct()
                .Select(code => new SelectListItem { Text = code, Value = code }).ToList();

            model.CountryAlpha3CodeList = allCountries.Select(c => c.CountryAlpha3Code).Distinct()
                .Select(code => new SelectListItem { Text = code, Value = code }).ToList();

            model.RiskScoreList = allCountries.Select(c => c.RiskScore?.ToString()).Distinct()
                .Select(score => new SelectListItem { Text = score, Value = score }).ToList();

            model.IbanLengthList = allCountries.Select(c => c.Ibanlength?.ToString()).Distinct()
                .Select(length => new SelectListItem { Text = length, Value = length }).ToList();

            model.DisplayNumberList = allCountries.Select(c => c.DisplayNumber).Distinct()
                .Select(display => new SelectListItem { Text = display, Value = display }).ToList();
        }
    }
}
