using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EPiServer.Oembed
{

    [InitializableModule]
    [ModuleDependency(typeof(ConfiguratorModule))]
    public class OEmbedModule : IInitializableModule
    {
        private ContentEventHandlers _contentEventHandlers;
        
        public void Initialize(InitializationEngine context)
        {
            var providers = ServiceLocator.Current.GetAllInstances<IOEmbedProvider>().ToArray();
            _contentEventHandlers = new ContentEventHandlers(providers);
            context.Locate.ContentEvents().SavingContent += _contentEventHandlers.SavingContentHandler;
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.ContentEvents().SavingContent -= _contentEventHandlers.SavingContentHandler;
        }
        
    }
}