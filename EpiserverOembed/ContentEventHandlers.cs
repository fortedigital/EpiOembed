using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAccess;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EPiServer.Oembed
{
    public class ContentEventHandlers
    {
        private readonly IOEmbedProvider[] _providers;

        public ContentEventHandlers(IOEmbedProvider[] providers)
        {
            _providers = providers;
        }
        
        public void SavingContentHandler(object sender, ContentEventArgs e)
        {
            if (!(e.Content is IOEmbedBlock embedBlock))
                return;

            if (!(e is SaveContentEventArgs se))
                return;

            var action = se.Action & SaveAction.ActionMask;
            if (action != SaveAction.Save)
                return;
            
            if (embedBlock.MediaUrl == null)
                return;
            
            var foundProvider = _providers.FirstOrDefault(x => x.CanInterpretMediaUrl(embedBlock.MediaUrl));
            if(foundProvider == null)
                return;
            
            var uri = new Uri(foundProvider.GetRequestUrl(embedBlock));
            var response = WebRequestHandler.GetResponse(uri);
            var json = JsonConvert.DeserializeObject<JObject>(response);
            if(json == null)
                return;

            embedBlock.EmbedResponse = json.ToString();
            embedBlock.ThumbnailUrl = json["thumbnail_url"]?.ToString();
            embedBlock.EmbedHtml = new XhtmlString(json["html"]?.ToString());
        }
    }
}