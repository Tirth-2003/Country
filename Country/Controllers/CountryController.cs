
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

        public IActionResult Index(
     List<string>? SelectedCountryNames,
     List<string>? SelectedCurrencyCodes,
     List<string>? SelectedCurrencySymbols,
     List<int>? SelectedCountryId,
        List<string>? SelectedCurrencyNames,
        List<string>? SelectedCountryCodes,
        List<string>? SelectedAlpha3Codes,
        List<string>? SelectedShortCodes,
        List<string>? SelectedDisplayNumbers,
        List<string>? SelectedRiskScores,
        List<bool>? SelectedIbanExists,
        List<string>? SelectedIbanLengths,
        List<string>? SelectedCountryShortCodes,
        List<int>? SelectedCurrencyId,

        int? CountryIdSearch,
     string? CountryNameSearch,
     string? CurrencyCodeSearch,
     string? CurrencySymbolSearch,
        string? CountryCodeSearch,
        string? CountryAlpha3CodeSearch,
        string? CurrencyNameSearch,
        string? ShortCodeSearch,
        string? DisplayNumberSearch,
        decimal? RiskScoreSearch,
        bool? IbanExistsSearch,
        string? IbanLengthSearch,
        string? CountryShortCodeSearch,
        int? CurrencyIdSearch


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
                SelectedCurrencyNames = SelectedCurrencyNames ?? new(),
                SelectedCountryCodes = SelectedCountryCodes ?? new(),
                SelectedAlpha3Codes = SelectedAlpha3Codes ?? new(),
                SelectedShortCodes = SelectedShortCodes ?? new(),
                SelectedDisplayNumbers = SelectedDisplayNumbers ?? new(),
                SelectedRiskScores = SelectedRiskScores ?? new(),
                SelectedIbanExists = SelectedIbanExists ?? new(),
                SelectedIbanLengths = SelectedIbanLengths ?? new(),
                SelectedCountryShortCodes = SelectedCountryShortCodes ?? new(),
                SelectedCurrencyId = SelectedCurrencyId ?? new(),

                CountryIdSearch = CountryIdSearch ?? 0,
                CountryCodeSearch = CountryCodeSearch,
                CountryNameSearch = CountryNameSearch,
                ShortCodeSearch = ShortCodeSearch,

                CurrencyCodeSearch = CurrencyCodeSearch,
                CurrencyNameSearch = CurrencyNameSearch,
                CurrencySymbolSearch = CurrencySymbolSearch,

                CurrencyIdSearch = CurrencyIdSearch ?? 0,    
                CountryAlpha3CodeSearch = CountryAlpha3CodeSearch,
                CountryShortCodeSearch = CountryShortCodeSearch,
                
                DisplayNumberSearch = DisplayNumberSearch,
                RiskScoreSearch = RiskScoreSearch,

                IbanExistsSearch = IbanExistsSearch,
                IbanLengthSearch = IbanLengthSearch,
                

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

                CountryCodeList = allCountries.Select(c => c.CountryCode).Distinct()
                    .Select(code => new SelectListItem
                    {
                        Text = code,
                        Value = code,
                        Selected = SelectedCountryCodes?.Contains(code) == true
                    }).ToList(),

                ShortCodeList = allCountries.Select(c => c.ShortCode).Distinct()
                    .Select(shortCode => new SelectListItem
                    {
                        Text = shortCode,
                        Value = shortCode,
                        Selected = SelectedShortCodes?.Contains(shortCode) == true
                    }).ToList(),

                CurrencyCodeList = allCountries.Select(c => c.CurrencyCode).Distinct()
                    .Select(code => new SelectListItem
                    {
                        Text = code,
                        Value = code,
                        Selected = SelectedCurrencyCodes?.Contains(code) == true
                    }).ToList(),

                CurrencyNameList = allCountries.Select(c => c.CurrencyName).Distinct()
                    .Select(name => new SelectListItem
                    {
                        Text = name,
                        Value = name,
                        Selected = SelectedCurrencyNames?.Contains(name) == true
                    }).ToList(),

                CurrencySymbolList = allCountries.Select(c => c.CurrencySymbol).Distinct()
                    .Select(symbol => new SelectListItem
                    {
                        Text = symbol,
                        Value = symbol,
                        Selected = SelectedCurrencySymbols?.Contains(symbol) == true
                    }).ToList(),

                CurrencyIdList = allCountries.Select(c => c.CurrencyId).Distinct()
                    .Select(id => new SelectListItem
                    {
                        Text = id.ToString(),
                        Value = id.ToString(),
                        Selected = SelectedCurrencyId.Contains((int)id) == true
                    }).ToList(),


                CountryShortCodeList = allCountries.Select(c => c.CountryShortCode).Distinct()
                    .Select(shortCode => new SelectListItem
                    {
                        Text = shortCode,
                        Value = shortCode,
                        Selected = SelectedCountryShortCodes?.Contains(shortCode) == true
                    }).ToList(),

                CountryAlpha3CodeList = allCountries.Select(c => new SelectListItem
                {
                    Value = c.CountryAlpha3Code,
                    Text = c.CountryAlpha3Code
                }).Distinct().ToList(),

                RiskScoreList = allCountries.Select(c => c.RiskScore?.ToString() ?? string.Empty).Distinct()
                    .Select(riskScore => new SelectListItem
                    {
                        Text = riskScore,
                        Value = riskScore,
                        Selected = SelectedRiskScores?.Contains(riskScore) == true
                    }).ToList(),

                 //IbanExistsList = allCountries.Select(c => c.Ibanexist.HasValue ? c.Ibanexist.Value.ToString() : string.Empty).Distinct()
                 //   .Select(ibanExists => new SelectListItem
                 //   {
                 //       Text = ibanExists,
                 //       Value = ibanExists,
                 //       Selected = SelectedIbanExists?.Contains(bool.Parse(ibanExists)) == true
                 //   }).ToList(),

                IbanLengthList = allCountries.Select(c => c.Ibanlength.HasValue ? c.Ibanlength.Value.ToString() : string.Empty).Distinct()
                    .Select(ibanLength => new SelectListItem
                    {
                        Text = ibanLength,
                        Value = ibanLength,
                        Selected = SelectedIbanLengths?.Contains(ibanLength) == true
                    }).ToList(),

                DisplayNumberList = allCountries.Select(c => c.DisplayNumber).Distinct()
                    .Select(displayNumber => new SelectListItem
                    {
                        Text = displayNumber,
                        Value = displayNumber,
                        Selected = SelectedDisplayNumbers?.Contains(displayNumber) == true
                    }).ToList(),

                
               

                


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

            if (model.SelectedCurrencyId?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedCurrencyId.Contains((int)c.CurrencyId)).ToList();

            if (model.SelectedShortCodes?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedShortCodes.Contains(c.ShortCode)).ToList();
            if (model.SelectedDisplayNumbers?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedDisplayNumbers.Contains(c.DisplayNumber)).ToList();
            if (model.SelectedRiskScores?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedRiskScores.Contains(c.RiskScore?.ToString() ?? string.Empty)).ToList();

            if (model.SelectedIbanLengths?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedIbanLengths.Contains(c.Ibanlength.HasValue ? c.Ibanlength.Value.ToString() : string.Empty)).ToList();
            if (model.SelectedCountryShortCodes?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedCountryShortCodes.Contains(c.CountryShortCode)).ToList();
            if (model.SelectedCountryNames?.Any() == true)
                model.Countries = model.Countries.Where(c => model.SelectedCountryNames.Contains(c.CountryName)).ToList();

            // Filter by text input (case-insensitive)


            if (CountryIdSearch.HasValue && CountryIdSearch.Value > 0)
                model.Countries = model.Countries.Where(c => c.CountryId == CountryIdSearch.Value).ToList();
            if (!string.IsNullOrWhiteSpace(CountryNameSearch))
                model.Countries = model.Countries.Where(c => c.CountryName != null && c.CountryName.ToLower().Contains(CountryNameSearch.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(CurrencyCodeSearch))
                model.Countries = model.Countries.Where(c => c.CurrencyCode != null && c.CurrencyCode.ToLower().Contains(CurrencyCodeSearch.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(CurrencySymbolSearch))
                model.Countries = model.Countries.Where(c => c.CurrencySymbol != null && c.CurrencySymbol.ToLower().Contains(CurrencySymbolSearch.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(CountryCodeSearch))
                model.Countries = model.Countries.Where(c => c.CountryCode != null && c.CountryCode.ToLower().Contains(CountryCodeSearch.ToLower())).ToList();
            if (!string.IsNullOrWhiteSpace(CountryAlpha3CodeSearch))
                model.Countries = model.Countries.Where(c => c.CountryAlpha3Code != null && c.CountryAlpha3Code.ToLower().Contains(CountryAlpha3CodeSearch.ToLower())).ToList();
            if (!string.IsNullOrWhiteSpace(CurrencyNameSearch))
                model.Countries = model.Countries.Where(c => c.CurrencyName != null && c.CurrencyName.ToLower().Contains(CurrencyNameSearch.ToLower())).ToList();
            if (!string.IsNullOrWhiteSpace(ShortCodeSearch))
                model.Countries = model.Countries.Where(c => c.ShortCode != null && c.ShortCode.ToLower().Contains(ShortCodeSearch.ToLower())).ToList();
            if (!string.IsNullOrWhiteSpace(DisplayNumberSearch))
                model.Countries = model.Countries.Where(c => c.DisplayNumber != null && c.DisplayNumber.ToLower().Contains(DisplayNumberSearch.ToLower())).ToList();
            if (RiskScoreSearch.HasValue)
                model.Countries = model.Countries.Where(c => c.RiskScore.HasValue && c.RiskScore.Value == RiskScoreSearch.Value).ToList();
            if (IbanExistsSearch.HasValue)
                model.Countries = model.Countries.Where(c => c.Ibanexist.HasValue && c.Ibanexist.Value == IbanExistsSearch.Value).ToList();
            if (!string.IsNullOrWhiteSpace(IbanLengthSearch))
                model.Countries = model.Countries.Where(c => c.Ibanlength.HasValue && c.Ibanlength.Value.ToString() == IbanLengthSearch).ToList();
            if (!string.IsNullOrWhiteSpace(CountryShortCodeSearch))
                model.Countries = model.Countries.Where(c => c.CountryShortCode != null && c.CountryShortCode.ToLower().Contains(CountryShortCodeSearch.ToLower())).ToList();
            if (CurrencyIdSearch.HasValue && CurrencyIdSearch.Value > 0)
                model.Countries = model.Countries.Where(c => c.CurrencyId == CurrencyIdSearch.Value).ToList();


            return View(model);
        }

    }
}
