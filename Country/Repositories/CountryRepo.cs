
using CountryApp.Data;
using CountryApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace CountryApp.Repositories
{
    public class CountryRepo : ICountry
    {
        public readonly CountryContext _context;

        public CountryRepo(CountryContext context) 
        {
           _context = context;
        }

        public async Task<IEnumerable<Models.Country>> GetCountry() 
        {
            var Data = await _context.Countries.FromSqlRaw("GetData").ToListAsync();
            return Data;
        }

        //public async Task<IEnumerable<Models.Country>> SearchCountry(int id, string Countrycode, string countryname)
        //public async Task<IEnumerable<Models.Country>> SearchCountry(CountryFilterViewModel? model)

        //{
        //    var GetId = new SqlParameter("@id", model.CountryIdSearch);
        //   var GetCode = new SqlParameter("@countrycode", string.IsNullOrEmpty(model.CountryCodeSearch) ? (object)DBNull.Value : model.CountryCodeSearch);
        //    var Getname = new SqlParameter("@Countryname", string.IsNullOrEmpty(model.CountryNameSearch) ? (object)DBNull.Value : model.CountryNameSearch);
        //    var Data = await _context.Countries.FromSqlRaw("EXEC GetsingleData @id, @countrycode ,@Countryname", GetId, GetCode, Getname).ToListAsync();
        //    return Data;
        //}

        //new SqlParameter("@currencysymbol", SqlDbType.NVarChar, 10) {     Value = string.IsNullOrWhiteSpace(model.CurrencySymbolSearch) ? DBNull.Value : model.CurrencySymbolSearch},


        //public async Task<IEnumerable<Models.Country>> SearchCountry(CountryFilterViewModel? model)
        //{
        //    var parameters = new[]
        //          {
        //           new SqlParameter("@id", SqlDbType.Int) { Value = model.CountryIdSearch ?? (object)DBNull.Value },
        //           new SqlParameter("@countrycode", SqlDbType.VarChar, 20) { Value = (object?)model.CountryCodeSearch ?? DBNull.Value },
        //           new SqlParameter("@Countryname", SqlDbType.NVarChar, 100) { Value = (object?)model.CountryNameSearch ?? DBNull.Value },
        //           new SqlParameter("@shortcode", SqlDbType.VarChar, 10) { Value = (object?)model.ShortCodeSearch ?? DBNull.Value },
        //           new SqlParameter("@currencycode", SqlDbType.VarChar, 50) { Value = (object?)model.CurrencyCodeSearch ?? DBNull.Value },
        //           new SqlParameter("@currencyname", SqlDbType.VarChar, 30) { Value = (object?)model.CurrencyNameSearch ?? DBNull.Value },
        //           new SqlParameter("@currencyID", SqlDbType.Int) { Value = model.CurrencyIdSearch ?? (object)DBNull.Value },
        //           new SqlParameter("@countryshortcode", SqlDbType.VarChar, 50) { Value = (object?)model.CountryShortCodeSearch ?? DBNull.Value },
        //           new SqlParameter("@countryalpha3code", SqlDbType.VarChar, 50) { Value = (object?)model.CountryAlpha3CodeSearch ?? DBNull.Value },
        //           new SqlParameter("@riskscore", SqlDbType.Decimal) { Value = model.RiskScoreSearch ?? (object)DBNull.Value },
        //           new SqlParameter("@ibanLenght", SqlDbType.Int) { Value = model.IbanLengthSearch.HasValue ? (object)model.IbanLengthSearch.Value : DBNull.Value },
        //           new SqlParameter("@displaynumber", SqlDbType.Int) { Value = string.IsNullOrEmpty(model.DisplayNumberSearch) ? (object)DBNull.Value : Convert.ToInt32(model.DisplayNumberSearch) }
        //         };

        //    var data = await _context.Countries
        //        .FromSqlRaw("EXEC GetsingleData @id, @countrycode, @Countryname, @shortcode, @currencycode,@currencyname,  @currencyID, @countryshortcode, @countryalpha3code, @riskscore, @ibanLenght, @displaynumber", parameters)
        //        .ToListAsync();
        //    return data;

        //}

        public async Task<IEnumerable<Models.Country>> SearchCountry(CountryViewModel model)
        {
            var parameters = new[]
            {
            new SqlParameter("@CountryId", SqlDbType.Int) { Value = model.CountryIdSearch ?? (object)DBNull.Value },
            new SqlParameter("@CountryNameSearch", SqlDbType.NVarChar, 100) { Value = model.CountryNameSearch ?? (object)DBNull.Value },
            new SqlParameter("@CountryCodeSearch", SqlDbType.VarChar, 20) { Value = model.CountryCodeSearch ?? (object)DBNull.Value },
            new SqlParameter("@ShortCodeSearch", SqlDbType.VarChar, 10) { Value = model.ShortCodeSearch ?? (object)DBNull.Value },
            new SqlParameter("@CurrencyCodeSearch", SqlDbType.VarChar, 50) { Value = model.CurrencyCodeSearch ?? (object)DBNull.Value },
            new SqlParameter("@CurrencyNameSearch", SqlDbType.VarChar, 30) { Value = model.CurrencyNameSearch ?? (object)DBNull.Value },
            new SqlParameter("@CurrencySymbolSearch", SqlDbType.NVarChar, 10) { Value = model.CurrencySymbolSearch ?? (object)DBNull.Value },
            new SqlParameter("@CurrencyId", SqlDbType.Int) { Value = model.CurrencyIdSearch ?? (object)DBNull.Value },
            new SqlParameter("@CountryShortCodeSearch", SqlDbType.VarChar, 50) { Value = model.CountryShortCodeSearch ?? (object)DBNull.Value },
            new SqlParameter("@CountryAlpha3CodeSearch", SqlDbType.VarChar, 10) { Value = model.CountryAlpha3CodeSearch ?? (object)DBNull.Value },
            new SqlParameter("@RiskScoreSearch", SqlDbType.Decimal) { Value = model.RiskScoreSearch ?? (object)DBNull.Value },
            new SqlParameter("@IbanExistsSearch", SqlDbType.Bit) { Value = model.IbanExistsSearch ?? (object)DBNull.Value },
            new SqlParameter("@IbanLengthSearch", SqlDbType.Int) { Value = model.IbanLengthSearch ?? (object)DBNull.Value },
            new SqlParameter("@DisplayNumberSearch", SqlDbType.VarChar, 50) { Value = model.DisplayNumberSearch ?? (object)DBNull.Value },
            


           // Multi-select parameters
            new SqlParameter("@CountryIDMulti",  SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCountryIds ?? new List<int>()) },
            new SqlParameter("@CurrencyIDMulti",  SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCurrencyIds ?? new List<int>()) },
            new SqlParameter("@RiskscoreMulti",  SqlDbType.VarChar) { Value = string.Join(",", model.SelectedRiskScores ?? new List<string>()) },

            new SqlParameter("@CountryNameMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCountryNames ?? new List<string>()) },
            new SqlParameter("@CountryCodeMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCountryCodes ?? new List<string>()) },
            new SqlParameter("@ShortCodeMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedShortCodes ?? new List<string>()) },
            new SqlParameter("@CurrencyCodeMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCurrencyCodes ?? new List<string>()) },
            new SqlParameter("@CurrencyNameMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCurrencyNames ?? new List<string>()) },
            new SqlParameter("@CurrencySymbolMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCurrencySymbols ?? new List<string>()) },
            new SqlParameter("@CountryShortCodeMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedCountryShortCodes ?? new List<string>()) },
            new SqlParameter("@CountryAlpha3CodeMulti", SqlDbType.VarChar) { Value = string.Join(",", model.SelectedAlpha3Codes ?? new List<string>()) }
        };
            var data = await _context.Countries
                .FromSqlRaw("EXEC GetSearch @CountryId, @CountryNameSearch, @CountryCodeSearch, @ShortCodeSearch, @CurrencyCodeSearch, @CurrencyNameSearch, @CurrencySymbolSearch, @CurrencyId, @CountryShortCodeSearch, @CountryAlpha3CodeSearch, @RiskScoreSearch, @IbanExistsSearch, @IbanLengthSearch, @DisplayNumberSearch, @CountryIDMulti ,@CurrencyIDMulti ,@RiskscoreMulti, @CountryNameMulti, @CountryCodeMulti, @ShortCodeMulti, @CurrencyCodeMulti, @CurrencyNameMulti, @CurrencySymbolMulti, @CountryShortCodeMulti, @CountryAlpha3CodeMulti", parameters)
                .ToListAsync();
            return data;
        }

        //Task<IEnumerable<Models.Country>> ICountry.GetCountry()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Models.Country>> ICountry.SearchCountry(CountryFilterViewModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
