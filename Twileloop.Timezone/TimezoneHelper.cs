using NodaTime;
using NodaTime.Extensions;
using NodaTime.TimeZones;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Twileloop.Timezone
{
    public static class TimezoneHelper
    {
        private static readonly IDateTimeZoneProvider TimeZoneProvider = DateTimeZoneProviders.Tzdb;
        private static readonly TzdbDateTimeZoneSource TimeZoneSource = TzdbDateTimeZoneSource.Default;

        public static DateTime UtcToSystemTimezone(this DateTime dateTime)
        {
            return dateTime.ToLocalTime();
        }

        public static DateTime UtcToCustomTimezone(this DateTime dateTime, string timezone)
        {
            var timeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezone);
            if (timeZone == null)
                throw new ArgumentException("Invalid time zone identifier.", nameof(timezone));

            var instant = Instant.FromDateTimeUtc(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
            var result = instant.InZone(timeZone).ToDateTimeUnspecified();
            return result;
        }

        public static DateTime CustomTimezoneToUtc(this DateTime dateTime, string timezone)
        {
            var zone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezone);
            if (zone == null)
                throw new ArgumentException("Invalid time zone identifier.", nameof(timezone));

            var localtime = LocalDateTime.FromDateTime(dateTime);
            var zonedtime = localtime.InZoneLeniently(zone);
            return zonedtime.ToInstant().InZone(zone).ToDateTimeUtc();
        }

        public static DateTime MigrateToTimezone(this DateTime dateTime, string fromTimezone, string toTimezone)
        {
            var utcDateTime = dateTime.CustomTimezoneToUtc(fromTimezone);
            return utcDateTime.UtcToCustomTimezone(toTimezone);
        }

        public static List<DateTimeZone> GetAllTimezones()
        {
            return DateTimeZoneProviders.Tzdb.GetAllZones().ToList();
        }

        public static List<TimeZoneInfo> OffsetToTimezones(int offsetInMinuits)
        {
            return TimeZoneInfo.GetSystemTimeZones().Where(x => x.GetUtcOffset(DateTime.Now).TotalMinutes == offsetInMinuits).ToList();
        }





        public static (string, List<string>) AbbreviationToTimezone(string abbreviation)
        {
            var timeZoneIds = TimeZoneProvider.Ids;
            var matchingZones = new List<string>();
            string displayName = null;

            foreach (var timeZoneId in timeZoneIds)
            {
                var timeZone = TimeZoneProvider[timeZoneId];
                var now = SystemClock.Instance.GetCurrentInstant();
                var zoneInterval = timeZone.GetZoneInterval(now);
                if (zoneInterval.Name.Contains(abbreviation, StringComparison.OrdinalIgnoreCase))
                {
                    if (displayName == null)
                        displayName = timeZone.ToString();
                    matchingZones.Add(timeZoneId);
                }
            }

            return (displayName, matchingZones);
        }

        public static (string, string) TimezoneToAbbreviation(string timezone)
        {
            var timeZone = TimeZoneProvider[timezone];
            var now = SystemClock.Instance.GetCurrentInstant();
            var zoneInterval = timeZone.GetZoneInterval(now);
            var abbreviation = zoneInterval.Name;
            var displayName = timeZone.ToString();
            return (abbreviation, displayName);
        }




        public static List<(string CountryCode, string CountryName)> GetCountriesUnderTimezone(string timezone)
        {
            var zoneLocations = TimeZoneSource.ZoneLocations
                .Where(location => location.ZoneId == timezone)
                .ToList();

            var countries = zoneLocations
                .Select(location => (location.CountryCode, GetCountryName(location.CountryCode)))
                .Distinct()
                .ToList();

            return countries;
        }

        public static List<string> GetTimezonesUnderCountry(string country)
        {
            var zoneLocations = TimeZoneSource.ZoneLocations
                .Where(location => location.CountryCode == country)
                .Select(location => location.ZoneId)
                .ToList();

            return zoneLocations;
        }

        private static string GetCountryName(string countryCode)
        {
            return new RegionInfo(countryCode).EnglishName;
        }

        public static string CountryNameToAbbreviation(string countryName)
        {
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(culture => new RegionInfo(culture.Name))
                .GroupBy(region => region.Name)
                .Select(group => group.First())
                .ToList();

            var country = countries.FirstOrDefault(region => region.EnglishName.Equals(countryName, StringComparison.OrdinalIgnoreCase));

            if (country == null)
            {
                throw new ArgumentException("Invalid country name.", nameof(countryName));
            }

            return country.TwoLetterISORegionName;
        }

        public static string AbbreviationToCountryName(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode) || countryCode.Length != 2)
            {
                throw new ArgumentException("Invalid country code.", nameof(countryCode));
            }

            try
            {
                var region = new RegionInfo(countryCode.ToUpper());
                return region.EnglishName;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid country code.", nameof(countryCode));
            }
        }

    }
}
