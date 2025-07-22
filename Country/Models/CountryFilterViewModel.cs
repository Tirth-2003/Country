using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountryApp.Models
{
    public class CountryFilterViewModel
    {
        public List<Country> Countries { get; set; }

        // Selected values
        public List<string> SelectedCountryNames { get; set; }
        public List<string> SelectedCurrencyCodes { get; set; }
        public List<string> SelectedCurrencySymbols { get; set; }
        public List<int>    SelectedCountryId { get; set; }
        public List<string>? SelectedCurrencyNames { get; set; }
        public List<string>? SelectedCountryCodes { get; set; }
        public List<string>? SelectedAlpha3Codes { get; set; }
        public List<string>? SelectedShortCodes { get; set; }
        public List<string>? SelectedDisplayNumbers { get; set; }
        public List<string>? SelectedRiskScores { get; set; }
        public List<bool>? SelectedIbanExists { get; set; } 
        public List<string> SelectedIbanLengths { get; set; } 
        public List<string>? SelectedCountryShortCodes { get; set; }
        public List<int> SelectedCurrencyId { get; set; }

        public int  CountryIdSearch { get; set; }
        public string CountryNameSearch { get; set; }
        public string CurrencyCodeSearch { get; set; }
        public string CurrencySymbolSearch { get; set; }
        public string CountryCodeSearch { get; set; }
        public string CountryAlpha3CodeSearch { get; set; }
        public string CurrencyNameSearch { get; set; }
        public string ShortCodeSearch { get; set; }
        public string DisplayNumberSearch { get; set; }
        public decimal? RiskScoreSearch { get; set; }
        public bool? IbanExistsSearch { get; set; }
        public string IbanLengthSearch { get; set; }
        public string CountryShortCodeSearch { get; set; }
        public int CurrencyIdSearch { get; set; }

        public List<SelectListItem> CountryNameList { get; set; } 
        public List<SelectListItem> CurrencyCodeList { get; set; }
        public List<SelectListItem> CurrencySymbolList { get; set; }
        public List<SelectListItem> CountryIdList { get; set; }
        public List<SelectListItem> CountryCodeList { get; set; }
        public List<SelectListItem> CountryAlpha3CodeList { get; set; }
        public List<SelectListItem> CurrencyNameList { get; set; }
        public List<SelectListItem> ShortCodeList { get; set; }
        public List<SelectListItem> DisplayNumberList { get; set; }
        public List<SelectListItem> RiskScoreList { get; set; }
        public List<SelectListItem> IbanExistsList { get; set; }
        public List<SelectListItem> IbanLengthList { get; set; }
        public List<SelectListItem> CountryShortCodeList { get; set; }
        public List<SelectListItem> CurrencyIdList { get; set; }



    }
}
