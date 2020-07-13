using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow.Infrastructure;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection.Internal
{
    internal class MicrosoftDependencyInjectionResolver : ITestObjectResolver
    {
        /// <inheritdoc />
        public object ResolveBindingInstance(Type bindingType, IObjectContainer scenarioContainer)
        {
            Debug.WriteLine($"ResolveBindingInstance {bindingType.FullName}");
            var scope = scenarioContainer.Resolve<IServiceScope>();
            var provider = scope.ServiceProvider;

            return provider.GetService(bindingType);
        }
    }
}
