using ExpressTimezone;
using System;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Current UTC Time");
            var datetime = DateTime.UtcNow;
            Console.WriteLine(datetime);
            Console.WriteLine();

            Console.WriteLine("1. Current Regional Time (Eg: Asia/Kolkata): " + ExpressTimeZone.CurrentRegionalTime("Asia/Kolkata"));
            Console.WriteLine("2. UTC => System Time Zone: " + datetime.UTCToSystemTime());
            Console.WriteLine("3. UTC => Regional Time (Eg: Asia/Calcutta): " + datetime.UTCToRegionalTime("Asia/Calcutta"));            
            Console.WriteLine("4. Regional Time (Eg: Asia/Calcutta) => UTC: " + DateTime.Now.RegionalTimeToUTC("Asia/Calcutta"));
            Console.WriteLine("5. Regional Time (Eg: Asia/Calcutta) => Regional Time (Eg: America/Chihuahua): " + DateTime.Now.MigrateTimezone("Asia/Calcutta", "America/Chihuahua"));

            Console.WriteLine();
            Console.WriteLine("6. All Timezones (Showing only 5..): ");
            var timezones = ExpressTimeZone.AllTimezones();
            foreach(var timezone in timezones.Take(5))
            {
                Console.WriteLine(timezone);
            }

            Console.WriteLine();
            Console.WriteLine("7. Offset => Timezones (+5:30) (Showing only 5..): ");
            var tzs = ExpressTimeZone.OffsetToTimezones(330);
            foreach (var tz in tzs.Take(5))
            {
                Console.WriteLine(tz.DisplayName);
            }

            Console.ReadLine();
        }
    }
}
