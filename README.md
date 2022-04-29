# This repo is not maintained anymore, please use [SpecFlow.DependencyInjection](https://github.com/solidtoken/SpecFlow.DependencyInjection)

# AdCodicem.SpecFlow.MicrosoftDependencyInjection
AdCodicem.SpecFlow.MicrosoftDependencyInjection is a [SpecFlow](https://specflow.org/getting-started/) plugin that enables to use [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) for resolving test dependencies.
It's based on Gáspár Nagy's [SpecFlow.Autofac](https://github.com/gasparnagy/SpecFlow.Autofac) plugin.

Currently supports : 
- SpecFlow 3.7 or above
- Microsoft.Extensions.DependencyInjection 2.1 or above

License: [Apache](https://raw.githubusercontent.com/AdCodicem/SpecFlowMicrosoftDependencyInjection/master/LICENSE)

NuGet: [![Nuget](https://img.shields.io/nuget/v/AdCodicem.SpecFlow.MicrosoftDependencyInjection)](https://www.nuget.org/packages/AdCodicem.SpecFlow.MicrosoftDependencyInjection)

Build Status [![Build Status](https://dev.azure.com/AdCodicem/SpecFlow.MicrosoftDependencyInjection/_apis/build/status/AdCodicem.SpecFlowMicrosoftDependencyInjection?branchName=master&stageName=build)](https://dev.azure.com/AdCodicem/SpecFlow.MicrosoftDependencyInjection/_build/latest?definitionId=2&branchName=master)

Release Status [![Release Status](https://dev.azure.com/AdCodicem/SpecFlow.MicrosoftDependencyInjection/_apis/build/status/AdCodicem.SpecFlowMicrosoftDependencyInjection?branchName=master&stageName=release)](https://dev.azure.com/AdCodicem/SpecFlow.MicrosoftDependencyInjection/_build/latest?definitionId=2&branchName=master)

# Why this plugin ?
I created this plugin for Specflow because most of my projects use the plain Microsoft.Extensions.DependencyInjection for injecting dependency.
If you've already familiar why ASP.Net Core dependency injection, you won't be lost with this plugin :wink:.

# Usage
## Typical usage
Install plugin from NuGet into your SpecFlow project.
```powershell
PM> Install-Package AdCodicem.SpecFlow.MicrosoftDependencyInjection
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
        services.AddTransient<ICalculator, Calculator>();
    }
}
```

## Delegate the resolution to the original container
Since v1.1.0 you can instruct the service collection to use the dependencies registered automatically by Specflow.
```csharp
public class Startup : IServicesConfigurator
{
    /// <inheritdoc />
    public void ConfigureServices(IServiceCollection services)
    {
        services
            // ITestOutputHelper is automatically registered by Specflow when using xUnit runner
            .AddDelegated<ITestOutputHelper>()
            // Calculator can use ITestOutputHelper as it's registered above to delegate the resolution to the original container
            .AddTransient<ICalculator, Calculator>();
    }
}
```

To register a delegated service, simply add the following call in configuration pipeline: `AddDelegated<TService>()`. 
The service resolution is delegated to the original container used by Specflow.

# Release History

## v1.1.3
- Fix: Support for Specflow v3.7+

## v1.1.1
- Fix: Added Intellisense documentation

## v1.1.0
- Feature: Allow the delegation of the resolution of some services to the original Specflow dependency injection. 
The delegated services must be registered like this: `services.AddDelegated<ITestOutputHelper>()`.

## v1.0.2
- Fix: Registered services are now disposed if they're disposable.

## v1.0.1
- Initial release.
- Increased minimal `Microsoft.Extensions.DependencyInjection` version to 2.1.0 to prevent `MissingMethodException` issue when using an higher version of the NuGet.
