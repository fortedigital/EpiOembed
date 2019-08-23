using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Logging;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Episerver.Oembed
{
    
    [ModuleDependency(typeof(ShellInitialization))]
    [InitializableModule]
    public class OEmbedModule : IInitializableModule
    {
        private IOEmbedProvider[] _providers;
        private readonly ILogger _logger = LogManager.GetLogger();
        
        private void ContentEventHandler(object sender, ContentEventArgs e)
        {
            
            if (!(e.Content is IOEmbedBlock embedBlock))
                return;

            if (embedBlock.MediaUrl == null)
                return;
            
            //TODO: first or default? maybe other way to choose
            var foundProvider = _providers.FirstOrDefault(x => x.CanInterpretMediaUrl(embedBlock.MediaUrl));
            if(foundProvider == null)
                return;
            
            JObject json = MakeRequest(embedBlock, foundProvider);
            if(json == null)
                return;

            embedBlock.EmbedResponse = json.ToString();
            embedBlock.ThumbnailUrl = json["thumbnail_url"]?.ToString();
            embedBlock.EmbedHtml = new XhtmlString(json["html"]?.ToString());

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
        
        private JObject MakeRequest(IOEmbedBlock block, IOEmbedProvider provider)
        {
            
            Uri uri = new Uri(provider.GetRequestUrl(block));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }
    }
}