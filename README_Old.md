> **Warning**
> ***This is an older documentation for older versions. For newer versions refer new documentation <a href="https://github.com/sangeethnandakumar/Twileloop.Timezone/blob/master/README.md">
    here
  </a>***

<hr/>

# Express.TimeZone

Express Timezone library is a simple wrapper around popular .NET DateTime framework Noda Time. Github (https://github.com/nodatime/nodatime)

ExpressTimezone exposes extension methords that are easy to use and on the point. Internaly it performs operations with NodaTime. This will make major stuff with DateTime convertion much easier without going deeper into the amazing work of NodaTime

The library exposes easy to use API for all kind of practical DateTime use cases,

Assuming that you have a server running under a specific timezone and clients connecting to it from multiple timezones, And you need to manage incomming and outgoing timezones easily. Like saving UTC in database and displaying on client's timezone on there browser. Or client selecting a time in their timezone and you need to convert it to UTC , Or even you need to migrate a time from one timezone to another. Likewise...

I created this wrapper library just because NodaTime is a little bit hard to kikstart.

![alt text](https://raw.githubusercontent.com/sangeethnandakumar/Express-Timezone-Library/master/ExpressTimezone/icon.png)

### Package Manager
The library is available free on NuGet
https://www.nuget.org/packages/Twileloop.ExpressTimezone/

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
