using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Newtonsoft.Json.Linq;

namespace Episerver.Oembed
{
    
    [ModuleDependency(typeof(ShellInitialization))]
    [InitializableModule]
    public class OEmbedModule : IInitializableModule
    {
        private IOEmbedProvider[] _providers;
        
        private void ContentEventHandler(object sender, ContentEventArgs e)
        {
            /*w którym szukamy, czy mamy zarejestrowany IOEmbedProvider,
             który potrafi zinterpretować MediaUrl, 
             jeśli tak to pozwalamy mu pociagnac EmbedResponse 
             i populujemy ThumbnailUrl i EmbedHtml.
             */
            if (!(e.Content is IOEmbedBlock embedBlock))
                return;

            if (embedBlock.MediaUrl == null)
                return;
            
            var foundProvider = _providers.FirstOrDefault(x => x.CanInterpretMediaUrl(embedBlock.MediaUrl));
            if(foundProvider == null)
                return;
            
            JObject json = foundProvider.MakeRequest(embedBlock);

            embedBlock.EmbedResponse = json.ToString();
            embedBlock.ThumbnailUrl = json["thumbnail_url"].ToString();
            embedBlock.EmbedHtml = new XhtmlString(json["html"].ToString());

        }
        
        public void Initialize(InitializationEngine context)
        {
            _providers = ServiceLocator.Current.GetAllInstances<IOEmbedProvider>().ToArray();
            context.Locate.ContentEvents().PublishingContent += ContentEventHandler;
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.ContentEvents().PublishingContent -= ContentEventHandler;
        }
    }
}