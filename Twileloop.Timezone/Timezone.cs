using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Twileloop.Timezone
{
    public static class Timezone
    {
        public static DateTime UtcToSystemTimezone(this DateTime dateTime)
        {
            return dateTime.ToLocalTime();
        }

        public static DateTime UtcToCustomTimezone(this DateTime dateTime, string timezone)
        {
            var timeZone = DateTimeZoneProviders.Tzdb[timezone];
            var instant = Instant.FromDateTimeUtc(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
            var result = instant.InZone(timeZone).ToDateTimeUnspecified();
            return result;
        }

        public static DateTime CustomTimezoneToUtc(this DateTime dateTime, string timezone)
        {
            DateTimeZone zone = DateTimeZoneProviders.Tzdb[timezone];
            var localtime = LocalDateTime.FromDateTime(dateTime);
            var zonedtime = localtime.InZoneLeniently(zone);
            return zonedtime.ToInstant().InZone(zone).ToDateTimeUtc();
        }

        public static DateTime MigrateToTimezone(this DateTime dateTime, string fromTimezone, string toTimezone)
        {
            return dateTime.CustomTimezoneToUtc(fromTimezone).UtcToCustomTimezone(toTimezone);
        }

        public static List<DateTimeZone> GetAllTimezones()
        {
            return DateTimeZoneProviders.Tzdb.GetAllZones().ToList();
        }

        public static List<TimeZoneInfo> OffsetToTimezones(int offsetInMinuits)
        {
            return TimeZoneInfo.GetSystemTimeZones().Where(x => x.GetUtcOffset(DateTime.Now).TotalMinutes == offsetInMinuits).ToList();
        }

        public static DateTime CurrentRegionalTime(string timezone)
        {
            return DateTime.UtcNow.UtcToCustomTimezone(timezone);
        }

    }
}
