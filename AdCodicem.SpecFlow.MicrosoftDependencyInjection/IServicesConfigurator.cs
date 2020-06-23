using Microsoft.Extensions.DependencyInjection;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection
{
    public interface IServicesConfigurator
    {
        void ConfigureServices(IServiceCollection services);
    }
}
