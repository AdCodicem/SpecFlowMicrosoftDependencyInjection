using AdCodicem.SpecFlow.MicrosoftDependencyInjection.Internal;
using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///     Extension methods for adding services to an <see cref="IServiceCollection" />.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds a delegated service of the type specified in <typeparamref name="TService" />.<br />
        ///     This method only works with <see cref="IDelegatableServiceCollection" />
        /// </summary>
        /// <typeparam name="TService">
        ///     The type of the delegated service to add.
        ///     This is the type used to resolve the service therefore it may be an interface.
        /// </typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
        public static IServiceCollection AddDelegated<TService>(this IServiceCollection services)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // In order to be failsafe, this method won't throw an exception if it's not used with IDelegatableServiceCollection
            // but the resolution may fail at runtime.
            if (services is IDelegatableServiceCollection delegatableServices)
            {
                delegatableServices.AddTransient(_ => delegatableServices.DelegateServices.Resolve<TService>());
            }

            return services;
        }
    }
}
