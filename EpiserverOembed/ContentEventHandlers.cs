using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Logging;
using EPiServer.Oembed.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EPiServer.Oembed
{
    public class ContentEventHandlers
    {
        private static readonly ILogger Logger = LogManager.GetLogger();
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

            var settings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Ignore};
            try
            {
                var deserializedObj = JsonConvert.DeserializeObject<ResponseObject>(response, settings);

                if (deserializedObj == null)
                    return;

                embedBlock.EmbedResponse = response;
                embedBlock.ThumbnailUrl = deserializedObj.thumbnail_url;
                embedBlock.EmbedHtml = deserializedObj.html;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
            }
        }
    }
}