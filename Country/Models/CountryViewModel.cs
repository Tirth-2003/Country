using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CountryApp.Models
{
    public class CountryViewModel
    {
        public string FromType { get; set; } = "Input";
        public IEnumerable<Country> Countries { get; set; }
        //public List<Country> SearchResults { get; set; } = new List<Country>();

        // Individual Search Inputs
        public int? CountryIdSearch { get; set; }
        public string CountryNameSearch { get; set; }
        public string CountryCodeSearch { get; set; }
        public string ShortCodeSearch { get; set; }
        public string CurrencyCodeSearch { get; set; }
        public string CurrencyNameSearch { get; set; }
        public string CurrencySymbolSearch { get; set; }
        public int? CurrencyIdSearch { get; set; }
        public string CountryShortCodeSearch { get; set; }
        public string CountryAlpha3CodeSearch { get; set; }
        public decimal? RiskScoreSearch { get; set; }
        public bool? IbanExistsSearch { get; set; }
        public int? IbanLengthSearch { get; set; }
        public string DisplayNumberSearch { get; set; }

        // Individual Multiselect Dropdowns
        public List<string> SelectedCountryNames { get; set; } = new List<string>();
        public List<string> SelectedCountryCodes { get; set; } = new List<string>();
        public List<string> SelectedShortCodes { get; set; } = new List<string>();
        public List<string> SelectedCurrencyCodes { get; set; } = new List<string>();
        public List<string> SelectedCurrencyNames { get; set; } = new List<string>();
        public List<string> SelectedCurrencySymbols { get; set; } = new List<string>();
        public List<int> SelectedCountryIds { get; set; } = new List<int>();
        public List<int> SelectedCurrencyIds { get; set; } = new List<int>();
        public List<string> SelectedAlpha3Codes { get; set; } = new List<string>();
        public List<string> SelectedCountryShortCodes { get; set; } = new List<string>();
        public List<string> SelectedDisplayNumbers { get; set; } = new List<string>();
        public List<string> SelectedRiskScores { get; set; } = new List<string>();
        public List<bool> SelectedIbanExists { get; set; } = new List<bool>();
        public List<int> SelectedIbanLengths { get; set; } = new List<int>();

        // Dropdown Options
        public List<SelectListItem> CurrencyIdList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CountryNameList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CountryCodeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ShortCodeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CurrencyCodeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CurrencyNameList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CurrencySymbolList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CountryIdList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CountryAlpha3CodeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CountryShortCodeList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> DisplayNumberList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> RiskScoreList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> IbanExistsList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> IbanLengthList { get; set; } = new List<SelectListItem>();
    }
}