using BoDi;
using Microsoft.Extensions.DependencyInjection;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection.Internal
{
    /// <summary>
    ///     Specifies the contract for a collection of service descriptors using a collection of delegatable services.
    /// </summary>
    internal interface IDelegatableServiceCollection : IServiceCollection
    {
        /// <summary>
        ///     A collection of services used when no service has been found in the <see cref="IServiceCollection" />.<br />
        ///     The services must be registered with <see cref="ServiceCollectionExtensions.AddDelegated{TService}" />.
        /// </summary>
        IObjectContainer DelegateServices { get; }
    }
}
