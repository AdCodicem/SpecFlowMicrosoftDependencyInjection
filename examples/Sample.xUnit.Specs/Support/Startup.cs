using AdCodicem.SpecFlow.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Sample.Specs.Support
{
    public class Startup : IServicesConfigurator
    {
        /// <inheritdoc />
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<Dependency>()
                .AddDelegated<ITestOutputHelper>()
                .AddTransient<ICalculator, Calculator>();
        }
    }

    public class Dependency
    {
        public ITestOutputHelper Output { get; }

        public Dependency(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
