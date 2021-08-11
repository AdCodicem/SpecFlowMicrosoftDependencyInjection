using AdCodicem.SpecFlow.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.MsTests.Specs.Support
{
    public class Startup : IServicesConfigurator
    {
        /// <inheritdoc />
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<ICalculator, Calculator>();
        }
    }
}
