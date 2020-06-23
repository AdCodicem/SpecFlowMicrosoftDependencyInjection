# BackToTheCoding.SpecFlow.Microsoft.DependencyInjection
BackToTheCoding.SpecFlow.Microsoft.DependencyInjection is a [SpecFlow](https://specflow.org/getting-started/) plugin that enables to use [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) for resolving test dependencies.
It's based on Gáspár Nagy's [SpecFlow.Autofac](https://github.com/gasparnagy/SpecFlow.Autofac) plugin.

Currently supports : 
- SpecFlow 3.0 or above
- Microsoft.Extensions.DependencyInjection 2.0 or above

License: [Apache](https://raw.githubusercontent.com/Back-To-The-Coding/SpecFlow.Microsoft.DependencyInjection/master/LICENSE)

NuGet: [BackToTheCoding.SpecFlow.Microsoft.DependencyInjection](https://www.nuget.org/packages/BackToTheCoding.SpecFlow.Microsoft.DependencyInjection)

[![Build status](https://dev.azure.com/BackToTheCoding/SpecFlow.Microsoft.DependencyInjection/_apis/build/status/SpecFlow.Microsoft.DependencyInjection-ASP.NET%20Core-CI)](https://dev.azure.com/BackToTheCoding/SpecFlow.Microsoft.DependencyInjection/_build/latest?definitionId=1)

[![Release status](https://vsrm.dev.azure.com/BackToTheCoding/_apis/public/Release/badge/1db51aac-f206-44a7-9973-9809a622ed3b/1/1)](https://dev.azure.com/BackToTheCoding/SpecFlow.Microsoft.DependencyInjection/_release?definitionId=1&_a=releases)

# Why this plugin ?
I created this plugin for Specflow because most of my projects use the plain Microsoft.Extensions.DependencyInjection for injecting dependency.
If you've already familiar why ASP.Net Core dependency injection, you won't be lost with this plugin :wink:.

# Usage
Install plugin from NuGet into your SpecFlow project.
```powershell
PM> Install-Package BackToTheCoding.SpecFlow.Microsoft.DependencyInjection
```

Create a __non-static__ class somewhere in the SpecFlow project implementing the `IServicesConfigurator` interface.
Configure the dependencies within the method.

__You don't have to register the step definition classes as it's already done by this plugin.__

:warning: _Do not use other dependency injection plugin for SpecFlow._

A typical dependency configuration class probably looks like this :
```csharp
public class Startup : IServicesConfigurator
{
    /// <inheritdoc />
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICalculator, Calculator>()
    }
}
```

# Release History
## v1.0.1
- Initial release.
- Increased minimal `Microsoft.Extensions.DependencyInjection` version to 2.0.0 to prevent `MissingMethodException` issue when using an higher version of the NuGet.
