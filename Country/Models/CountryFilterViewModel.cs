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
        public List<int> SelectedCountryId { get; set; }
        public List<string>? SelectedCurrencyNames { get; set; }
        public List<string>? SelectedCountryCodes { get; set; }
        public List<string>? SelectedAlpha3Codes { get; set; }

        public int  CountryIdSearch { get; set; }
        public string CountryNameSearch { get; set; }
        public string CurrencyCodeSearch { get; set; }
        public string CurrencySymbolSearch { get; set; }
        // Dropdown options
        public List<SelectListItem> CountryNameList { get; set; } 
        public List<SelectListItem> CurrencyCodeList { get; set; }
        public List<SelectListItem> CurrencySymbolList { get; set; }
        public List<SelectListItem> CountryIdList { get; set; }
        public List<SelectListItem> CountryCodeList { get; set; }
        public List<SelectListItem> CountryAlpha3CodeList { get; set; }
        public List<SelectListItem> CurrencyNameList { get; set; }


    }
}
