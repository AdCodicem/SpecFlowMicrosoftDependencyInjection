using System;
using System.Diagnostics;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow.Infrastructure;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection
{
    public class MicrosoftDependencyInjectionResolver : ITestObjectResolver
    {
        /// <inheritdoc />
        public object ResolveBindingInstance(Type bindingType, IObjectContainer scenarioContainer)
        {
            Debug.WriteLine($"ResolveBindingInstance {bindingType.FullName}");
            var scope = scenarioContainer.Resolve<IServiceScope>();
            var provider = scope.ServiceProvider;
            var instance = provider.GetService(bindingType);

            return instance;
        }
    }
}
