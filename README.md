# Express.TimeZone

EXpress Timezone library is basicaly a wrapper around popular .NET DateTime framework Noda Time. Github (https://github.com/nodatime/nodatime)

ExpressTimezone exposes extension methords that are easy to use and on the point APIs and performs operations with NodaTime. This will make major stuff with dateTime convertion much easier indirectly using NodaTime

The library exposes easy to use API for all kind of practical DateTime conversions, Keeping in mind that you have a server on a specific timezone and clients connecting to it from multiple timezones

![alt text](https://d585tldpucybw.cloudfront.net/sfimages/default-source/productsimages/justmock/justmock__net_770.png?sfvrsn=b4522579_1)

### Package Manager
The library is available free on NuGet
https://www.nuget.org/packages/Twileloop.ExpressData

```nuget
Install-Package Twileloop.ExpressTimezone -Version 1.0.0
```

### Repository Contents
This repo maintains 2 projects. The main library and a demo project that implements it

## Basic DateTime scnerios
* Assume server timezone is "Asia/Calcutta" for these examples

### Getting TimeZone from a Client's Browser (JavaScript)
If you need to retrive timezone from a client's browser, You can use this
```javascript
var timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
```

### UTC => System Time Zone
Converts UTC time to System default timezone
```csharp
var datetime = DateTime.UtcNow;
datetime.UTCToSystemTime()
```

### UTC => Regional Time
Convert UTC time to a regional time
```csharp
var datetime = DateTime.UtcNow;
datetime.UTCToRegionalTime("Asia/Calcutta")
```

### Regional Time => UTC
This example system timezone to UTC
```csharp
var datetime = DateTime.Now;
datetime.RegionalTimeToUTC("Asia/Calcutta")
```

### Regional Time => Regional Time
Converts time from one timezone to another
```csharp
var datetime = DateTime.Now;
datetime.MigrateTimezone("Asia/Calcutta", "America/Chihuahua")
```

### List of all timezones
Gets a list of all timezones available on NodaTime
```csharp
var timezones = ExpressTimeZone.AllTimezones();
foreach(var timezone in timezones)
{
    Console.WriteLine(timezone);
}
```

### List of all timezones
Get a list of timezones falls under specific UTC offset
```csharp
//+5:30 is 330 mins
var tzs = ExpressTimeZone.OffsetToTimezones(330);
foreach (var tz in tzs))
{
    Console.WriteLine(tz.DisplayName);
}
```
