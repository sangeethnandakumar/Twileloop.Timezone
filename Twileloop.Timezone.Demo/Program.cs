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




            //Get all timezones
            var allTimezones = Timezone.GetAllTimezones();
            allTimezones.ForEach(timeZone =>
            {
                Console.WriteLine(timeZone.ToString());
            });

            //Find timezones sharing same offset (+5:30 is 330 mins)
            var timezonesSharingSameOffset = Timezone.OffsetToTimezones(330);
            timezonesSharingSameOffset.ForEach(timeZone =>
            {
                Console.WriteLine(timeZone.DisplayName);
            });
        }
    }
}