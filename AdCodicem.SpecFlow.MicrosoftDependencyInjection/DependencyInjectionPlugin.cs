using AdCodicem.SpecFlow.MicrosoftDependencyInjection;
using AdCodicem.SpecFlow.MicrosoftDependencyInjection.Internal;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;

[assembly: RuntimePlugin(typeof(DependencyInjectionPlugin))]

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection
{
    public class DependencyInjectionPlugin : IRuntimePlugin
    {
        private static readonly object RegistrationLock = new object();

        private void ConfigureBindings(IServiceCollection services)
        {
            var bindingTypes =
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(assembly => assembly.GetLoadableTypes())
                    .Where(a => System.Attribute.IsDefined(a, typeof(BindingAttribute)));
            foreach (var bindingType in bindingTypes)
            {
                services.AddScoped(bindingType);
            }
        }

        private IServiceCollection ConfigureServices(IObjectContainer delegateContainer)
        {
            Debug.WriteLine(nameof(ConfigureServices));
            var services = new DelegatableServiceCollection(delegateContainer);

            ConfigureBindings(services);

            // Get all IServicesConfigurator implementations
            var servicesConfiguratorTypes =
                AppDomain.CurrentDomain.GetAssemblies()
                         .SelectMany(assembly => assembly.GetLoadableTypes())
                         .Where(type => typeof(IServicesConfigurator).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                         .Where(type => type.GetConstructor(Type.EmptyTypes) != null)
                         .ToList();

            foreach (var type in servicesConfiguratorTypes)
            {
                var serviceConfigurator = (IServicesConfigurator)Activator.CreateInstance(type);
                serviceConfigurator.ConfigureServices(services);
            }

            services
                .AddDelegated<ScenarioContext>()
                .AddDelegated<FeatureContext>()
                .AddDelegated<TestThreadContext>();

            return services;
        }

        /// <inheritdoc />
        public void Initialize(
            RuntimePluginEvents runtimePluginEvents,
            RuntimePluginParameters runtimePluginParameters,
            UnitTestProviderConfiguration unitTestProviderConfiguration
        )
        {
            runtimePluginEvents.CustomizeGlobalDependencies += (_, args) =>
            {
                // an extra lock to ensure that there are not two super fast threads re-registering the same stuff
                lock (RegistrationLock)
                {
                    if (!args.ObjectContainer.IsRegistered<MicrosoftDependencyInjectionResolver>())
                    {
                        args.ObjectContainer.RegisterTypeAs<MicrosoftDependencyInjectionResolver, ITestObjectResolver>();
                    }
                }

                // workaround for parallel execution issue - this should be rather a feature in BoDi?
                args.ObjectContainer.Resolve<MicrosoftDependencyInjectionResolver>();
            };
            runtimePluginEvents.CustomizeScenarioDependencies += (_, args) =>
            {
                var services = ConfigureServices(args.ObjectContainer);

                var provider = services.BuildServiceProvider(true).CreateScope();
                args.ObjectContainer.RegisterInstanceAs(provider, typeof(IServiceScope), dispose: true);
            };
        }
    }
}
