# Express.Data

If your project needs to fire queries to a relational database often at different places of your code. This lightweight library will be helpfull.

Express.Data allows playing with database queries easy by making use of Dapper, DapperContrib and DTO classes. Examples are provided below.
This library is a wrapper around the popular Dapper micro ORM and it's extension Dapper.Contrib. It works with any relational database and runs over ADO.NET and DapperMicroORM

The library exposes easy to use API for all kind of database CRUD operations.

![alt text](https://d585tldpucybw.cloudfront.net/sfimages/default-source/productsimages/justmock/justmock__net_770.png?sfvrsn=b4522579_1)

### Package Manager
The library is available free on NuGet
https://www.nuget.org/packages/Twileloop.ExpressData

```nuget
Install-Package Twileloop.ExpressData -Version 1.0.0
```

### Versions
Version Information
| Version | Change log
| ------ | ------
| v1.1 | Basic CRUD Operations support

### Repository Contents
This repo maintains 2 projects. The main library and a demo project to implement it

### PreRequesties
Before running the demo program
1. Create a table named tblUsers
2. Create 3 columns Id, Fname and Lname
3. Set the connection string to database server inside Main()


### Usage
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
Insert a model
```csharp
var record = new tblUser {
	Id = 1,
	FName = "Sangeeth",
	LName = "Nandakumar"
};
var primaryKey = SqlHelper.Insert < tblUser > (record, _connectionString);
```
Update a model
```csharp
record = new tblUser {
	Id = 1,
	FName = "Navaneeth",
	LName = "Nandakumar"
};
var isUpdated = SqlHelper.Update < tblUser > (record, _connectionString);
```
Run a query
```csharp
var sql1 = $ "SELECT * FROM tblUser WHERE Id=1";
var result = SqlHelper.Query < tblUser > (sql1, _connectionString).FirstOrDefault();
```
Run a safe query (Parameterised query)
```csharp
var sql2 = $ "SELECT * FROM tblUser WHERE Id=@id AND Fname=@fname";
result = SqlHelper.QuerySafe < tblUser > (sql2, new {
	id = 1,
	fname = "Navaneeth"
},
_connectionString);
```
Run a stored procedure
```csharp
var procedureName = $ "spGetUsers";
result = SqlHelper.Execute < tblUser > (procedureName, new {
	id = 1
},
_connectionString).FirstOrDefault();
```
