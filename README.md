## Given - UTC To LocalTime()
Gives a list of all permission informations
```csharp
var indianTime = TimezoneHelper.GivenUTCToLocalTime('2020-08-03 12:37:21.603', 'Asia/Calcuta');
```
## Current - UTC To LocalTime()
Gives a list of all permission informations
```csharp
var indianTime = TimezoneHelper.CurrentUTCToLocalTime('Asia/Calcuta');
```
## Given - LocalTime To UTC()
Gives a list of all permission informations
```csharp
var utcTime = TimezoneHelper.GivenLocalTimeToUTC('2020-08-03 12:37:21.603', 'Asia/Calcuta');
```
## TimeZone A To Another TimeZone B
Gives a list of all permission informations
```csharp
var pacaficTime = TimezoneHelper.MigrateTimezone('2020-08-03 12:37:21.603', 'Asia/Calcuta', 'Asia/Pacific');
```
## GetTimezoneOffset()
Gives a list of all permission informations
```csharp
var fiveAndHalfHours = TimezoneHelper.GetTimezoneOffset('Asia/Calcuta').Notation();
```
## GetAllTimezones()
Gives a list of all permission informations
```csharp
var allTimeZones = TimezoneHelper.GetAllTimezones();
```
## DoesTimeZoneSupported
Gives a list of all permission informations
```csharp
var allTimeZones = TimezoneHelper.DoesSupport('Asia/Calcuta');
```
---
# EXTENSION METHORDS
## ToISO233
Gives a list of all permission informations
```csharp
var allTimeZones = DateTime.UTCNow.ToISO233();
```
