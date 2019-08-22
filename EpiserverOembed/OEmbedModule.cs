using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace Episerver.Oembed
{
    
    [ModuleDependency(typeof(ShellInitialization))]
    [InitializableModule]
    public class OEmbedModule : IInitializableModule
    {
        private IEnumerable<IOEmbedProvider> _providers;
        
        private void HandleSavedContent(object sender, ContentEventArgs e)
        {
            /*w którym szukamy, czy mamy zarejestrowany IOEmbedProvider,
             który potrafi zinterpretować MediaUrl, 
             jeśli tak to pozwalamy mu pociagnac EmbedResponse 
             i populujemy ThumbnailUrl i EmbedHtml.
             */
            
        }
        
        public void Initialize(InitializationEngine context)
        {
            _providers = ServiceLocator.Current.GetAllInstances<IOEmbedProvider>();
            context.Locate.ContentEvents().SavedContent += HandleSavedContent;
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.ContentEvents().SavedContent -= HandleSavedContent;
        }
    }
}