﻿<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/sangeethnandakumar/Twileloop.Timezone">
    <img src="https://iili.io/HUQ2pxn.png" alt="Logo" width="80" height="80">
  </a>

  <h2 align="center"> Twileloop.Timezone </h2>
  <h4 align="center"> Timezones | Global | Countries </h4>

</div>

## About
An easy to use utility wrapper around NodaTime to easily convert timezones from any timezones, countries, offsets, short and long names etc.. while leveraging the powerfull NodaTime and globaliazation.

> **Note**
> ***Starting from version v2.0+ and above, This is the official documentation. For older versions, Refer old documentation <a href="https://github.com/sangeethnandakumar/Twileloop.Security/blob/master/README_Old.md">
    here
  </a>***

## License
> Twileloop.Timezone is licensed under the MIT License. See the LICENSE file for more details.

#### This library is absolutely free. If it gives you a smile, A small coffee would be a great way to support my work. Thank you for considering it!
[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/sangeethnanda)


## 1. Install Package
```bash
dotnet add package Twileloop.Timezone
```

### Supported Features

| Status | From | | To
| --- | --- | --- | ---
| ✅ | UTC timezone | 🡺 | System timezone
| ✅ | UTC timezone | 🡺 | Custom timezone
| ✅ | Custom timezone | 🡺 | UTC timezone
| ✅ | Custom timezone | 🡺 | Custom timezone
| ✅ | Timezone Abbreviation | 🡺 | Timezone Id
| ✅ | Timezone Id | 🡺 | Timezone Abbreviation
| ✅ | Timezone Id | 🡺 | Country ISO Codes (Under that timezone)
| ✅ | Country ISO Code | 🡺 | Timezone Ids (Under that country)
| ✅ | Country Name | 🡺 | Country ISO Code
| ✅ | Country ISO Code | 🡺 | Country Name

## 2. System timezone 🡺 UTC timezone

```csharp
//System timezone 🡺 UTC timezone
var utcTime = DateTime.UtcNow;
```

## 3. UTC timezone 🡺 System timezone

```csharp
//UTC timezone 🡺 System timezone
var mySystemTime = utcTime.UtcToSystemTimezone();
```

## 4. UTC timezone 🡺 Custom timezone

```csharp
//UTC timezone 🡺 Custom timezone
var japanTime = utcTime.UtcToCustomTimezone("Asia/Tokyo");
```

## 5. Custom timezone 🡺 UTC timezone

```csharp
//Custom timezone 🡺 UTC timezone
var japanTimeInUtc = japanTime.CustomTimezoneToUtc("Asia/Tokyo");
```

## 6. Custom timezone 🡺 Custom timezone

```csharp
//Custom timezone 🡺 Custom timezone
var indianTime = japanTime.MigrateToTimezone("Asia/Tokyo", "Asia/Kolkata");
```

## 7. Timezone Abbreviation 🡺 Timezone Id

```csharp
// Timezone Abbreviation 🡺 Timezone Id
var abbreviation = "IST";
var (displayName, timeZoneIds) = TimezoneHelper.AbbreviationToTimezone(abbreviation);

Console.WriteLine($"Abbreviation: {abbreviation}");
Console.WriteLine($"Full Display Name: {displayName}");
Console.WriteLine("Time Zone Identifiers:");

foreach (var timeZoneIda in timeZoneIds)
{
    Console.WriteLine(timeZoneIda);
}
```

## 8. Timezone Id 🡺 Timezone Abbreviation

```csharp
// Timezone Id 🡺 Timezone Abbreviation
var timeZoneId = "Asia/Kolkata";
var (zoneAbbreviation, zoneDisplayName) = TimezoneHelper.TimezoneToAbbreviation(timeZoneId);

Console.WriteLine($"Time Zone Identifier: {timeZoneId}");
Console.WriteLine($"Abbreviation: {zoneAbbreviation}");
Console.WriteLine($"Full Display Name: {zoneDisplayName}");
```

## 9. Timezone Id 🡺 Countries Under Timezone

```csharp
// Timezone Id 🡺 Country Codes
string timezone = "America/New_York";
List<(string CountryCode, string CountryName)> countriesUnderTimezone  = TimezoneHelper.GetCountriesUnderTimezone(timezone);

Console.WriteLine($"Countries under timezone '{timezone}':");
foreach (var country in countriesUnderTimezone)
{
    Console.WriteLine($"{country.CountryCode} | {country.CountryName}");
}
```

## 10. Country ISO Code 🡺 Timezones Under Country

```csharp
// Country Code 🡺 Timezones
string countryCode = "US";
List<string> timezones = TimezoneHelper.GetTimezonesUnderCountry(countryCode);
Console.WriteLine($"Timezones under country '{countryCode}':");
foreach (string tz in timezones)
{
    Console.WriteLine($"{tz}");
}
```

## 11. Country Name 🡺 Country ISO Code

```csharp
// Country Name 🡺 Country Code
string countryName = "United States";
string isoCountryCode = TimezoneHelper.CountryNameToAbbreviation(countryName);
Console.WriteLine($"Country name '{countryName}' has the abbreviation: {isoCountryCode}");
```

## 12. Country ISO Code 🡺 Country Names

```csharp
// Country Code 🡺 Country Name 
string isoCode = "US";
string fullCountryName = TimezoneHelper.AbbreviationToCountryName(isoCode);
Console.WriteLine($"Abbreviation '{isoCode}' corresponds to the country: {fullCountryName}");
```

## 13. Timezones Sharing Same Offset (In Minuits) 

```csharp
//Find timezones sharing same offset (+5:30 is 330 mins)
var timezonesSharingSameOffset = TimezoneHelper.OffsetToTimezones(330);
timezonesSharingSameOffset.ForEach(timeZone =>
{
    Console.WriteLine(timeZone.DisplayName);
});
```

## 14. All Timezones

```csharp
//Get all timezones
var allTimezones = TimezoneHelper.GetAllTimezones();
allTimezones.ForEach(timeZone =>
{
    Console.WriteLine(timeZone.ToString());
});
```

## 15. All Countries

```csharp
//Get all countries
List<(string CountryCode, string CountryName)> allCountries = TimezoneHelper.GetAllCountries();
allCountries.ForEach(country =>
{
    Console.WriteLine($"{country.CountryCode} | {country.CountryName}");
});
```
