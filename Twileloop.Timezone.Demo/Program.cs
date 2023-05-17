using System.Collections.Generic;

namespace Twileloop.Timezone.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System timezone 🡺 UTC timezone
            var utcTime = DateTime.UtcNow;

            //UTC timezone 🡺 System timezone
            var mySystemTime = utcTime.UtcToSystemTimezone();

            //UTC timezone 🡺 Custom timezone
            var japanTime = utcTime.UtcToCustomTimezone("Asia/Tokyo");

            //Custom timezone 🡺 UTC timezone
            var japanTimeInUtc = japanTime.CustomTimezoneToUtc("Asia/Tokyo");

            //Custom timezone 🡺 Custom timezone
            var indianTime = japanTime.MigrateToTimezone("Asia/Tokyo", "Asia/Kolkata");

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


            // Timezone Id 🡺 Timezone Abbreviation
            var timeZoneId = "Asia/Kolkata";
            var (zoneAbbreviation, zoneDisplayName) = TimezoneHelper.TimezoneToAbbreviation(timeZoneId);
            Console.WriteLine($"Time Zone Identifier: {timeZoneId}");
            Console.WriteLine($"Abbreviation: {zoneAbbreviation}");
            Console.WriteLine($"Full Display Name: {zoneDisplayName}");


            // Timezone Id 🡺 Country Code
            string timezone = "America/New_York";
            List<(string CountryCode, string CountryName)> countriesUnderTimezone  = TimezoneHelper.GetCountriesUnderTimezone(timezone);
            Console.WriteLine($"Countries under timezone '{timezone}':");
            foreach (var country in countriesUnderTimezone)
            {
                Console.WriteLine($"{country.CountryCode} | {country.CountryName}");
            }


            // Country Code 🡺 Timezones
            string countryCode = "US";
            List<string> timezones = TimezoneHelper.GetTimezonesUnderCountry(countryCode);
            Console.WriteLine($"Timezones under country '{countryCode}':");
            foreach (string tz in timezones)
            {
                Console.WriteLine($"{tz}");
            }


            // Country Name 🡺 Country Code
            string countryName = "United States";
            string isoCountryCode = TimezoneHelper.CountryNameToAbbreviation(countryName);
            Console.WriteLine($"Country name '{countryName}' has the abbreviation: {isoCountryCode}");


            // Country Code 🡺 Country Name 
            string isoCode = "US";
            string fullCountryName = TimezoneHelper.AbbreviationToCountryName(isoCode);
            Console.WriteLine($"Abbreviation '{isoCode}' corresponds to the country: {fullCountryName}");


            //Get all countries
            List<(string CountryCode, string CountryName)> allCountries = TimezoneHelper.GetAllCountries();
            allCountries.ForEach(country =>
            {
                Console.WriteLine($"{country.CountryCode} | {country.CountryName}");
            });


            //Get all timezones
            var allTimezones = TimezoneHelper.GetAllTimezones();
            allTimezones.ForEach(timeZone =>
            {
                Console.WriteLine(timeZone.ToString());
            });


            //Find timezones sharing same offset (+5:30 is 330 mins)
            var timezonesSharingSameOffset = TimezoneHelper.OffsetToTimezones(330);
            timezonesSharingSameOffset.ForEach(timeZone =>
            {
                Console.WriteLine(timeZone.DisplayName);
            });
        }
    }
}