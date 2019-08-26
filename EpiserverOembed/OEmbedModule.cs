using System.Linq;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace EPiServer.Oembed
{
    
    //TODO: select provider instead of firstOrDefault
    
    //Testing urls:
    //https://www.youtube.com/watch?v=iwGFalTRHDA
    //https://vimeo.com/76979871
    
    [ModuleDependency(typeof(ShellInitialization))]
    [InitializableModule]
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