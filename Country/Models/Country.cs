using System;
using System.Collections.Generic;

namespace CountryApp.Models;

public partial class Country
{
    public int CountryId { get; set; } = 0;

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public string? ShortCode { get; set; }

    public string? CurrencyCode { get; set; }

    public string? CurrencyName { get; set; }

    public string? CurrencySymbol { get; set; }

    public int? CurrencyId { get; set; }

    public string? CountryShortCode { get; set; }

    public string? CountryAlpha3Code { get; set; }

    public decimal? RiskScore { get; set; }

    public bool? Ibanexist { get; set; }

    public int? Ibanlength { get; set; }

    public string? DisplayNumber { get; set; }
}
