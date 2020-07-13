using Microsoft.Extensions.DependencyInjection;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection
{
    /// <summary>
    ///     Specifies the contract for a class used to configure the services used during the tests run.
    /// </summary>
    public interface IServicesConfigurator
    {
        /// <summary>
        ///     Configure the <see cref="services" />
        /// </summary>
        /// <param name="services">Services to configure</param>
        void ConfigureServices(IServiceCollection services);
    }
}
