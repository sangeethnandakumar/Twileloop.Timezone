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
### Basic DateTime scnerios
C# POCO Model building.
The model should be decorated with Dapper.Contrib attributes for proper working. Here is an example
```csharp
using Dapper.Contrib.Extensions;

namespace Demo
{
    [Table("tblUser")]
    public class tblUser
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Computed]
        public string Fullname { get; set; }
    }
}
```
