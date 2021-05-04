# Project Estimator API for Abbott Construction

## Developer Notes

**Required/minimum prerequisites:**
- .NET Core 3.1 (latest patch under 3.1 recommended)
- SQL Server 2017 or newer. You can run the Windows version, but if you are developing on Mac or Linux, you should use a Docker image of SQL Server.
- Recommended IDE: Visual Studio 2019 or JetBrains Rider
- Recommended API request tool: Postman

**Coding style:**
- Follow Microsoft's C# conventions as much as possible, including when naming (usually Pascal case). Rider does a good job at pointing out convention mistakes.

**Database configuration:**

In the development environment, the default connection string is `Server=localhost;Database=AbbottProjectEstimator;Trusted_Connection=True;`, which is set in appsettings.Development.json. This works good if your local development instance of SQL Server is hosted in the same environment you're running this app on.

If you must use a different connection string, please do not change this default as it would affect all contributors. Please set an environment variable or store it in your _user secrets_ through Visual Studio or command line like so:

~~~
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=AbbottProjectEstimator;Trusted_Connection=True;"
~~~
