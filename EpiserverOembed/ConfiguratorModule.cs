using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Oembed.DefaultProviders;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace EPiServer.Oembed
{
    [InitializableModule]
    [ModuleDependency(typeof(ShellInitialization))]
    public class ConfiguratorModule : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(t => typeof(IOEmbedProvider).IsAssignableFrom(t))
                .ToList();

            foreach (var implementingType in implementingTypes)
            {
                if (implementingType == typeof(IOEmbedProvider) || implementingType == typeof(BaseOEmbedProvider))
                    continue;
                
                context.Services.AddSingleton(locator =>
                    Activator.CreateInstance(implementingType) as IOEmbedProvider);
            }
        }
        
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

    }
}