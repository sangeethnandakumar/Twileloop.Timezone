using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressTimezone
{
    public static class ExpressTimeZone
    {
        public static DateTime UTCToSystemTime(this DateTime dateTime)
        {
            return dateTime.ToLocalTime();
        }

        public static DateTime UTCToRegionalTime(this DateTime dateTime, string timezone)
        {
            var timeZone = DateTimeZoneProviders.Tzdb[timezone];
            var instant = Instant.FromDateTimeUtc(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
            var result = instant.InZone(timeZone).ToDateTimeUnspecified();
            return result;
        }

        public static DateTime RegionalTimeToUTC(this DateTime dateTime, string timezone)
        {
            DateTimeZone zone = DateTimeZoneProviders.Tzdb[timezone];
            var localtime = LocalDateTime.FromDateTime(dateTime);
            var zonedtime = localtime.InZoneLeniently(zone);
            return zonedtime.ToInstant().InZone(zone).ToDateTimeUtc();
        }
        
        public static DateTime MigrateTimezone(this DateTime dateTime, string fromTimezone, string toTimezone)
        {
            return dateTime.RegionalTimeToUTC(fromTimezone).UTCToRegionalTime(toTimezone);
        }

        public static IEnumerable<string> AllTimezones()
        {
            return DateTimeZoneProviders.Tzdb.Ids;
        }
        
        public static IEnumerable<TimeZoneInfo> OffsetToTimezones(int offsetInMinuits)
        {
            return TimeZoneInfo.GetSystemTimeZones().Where(x => x.GetUtcOffset(DateTime.Now).TotalMinutes == offsetInMinuits);
        }

        public static DateTime CurrentRegionalTime(string timezone)
        {
            return DateTime.UtcNow.UTCToRegionalTime(timezone);
        }
        
    }
}
