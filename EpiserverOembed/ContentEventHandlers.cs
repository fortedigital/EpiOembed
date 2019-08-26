using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Logging;

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

            var deserializedObj = ResponseDeserializer.DeserializeResponse(response, foundProvider.FormatType);
            
            embedBlock.FullResponse = response;
            embedBlock.ThumbnailUrl = deserializedObj.ThumbnailUrl;
            embedBlock.EmbedHtml = new XhtmlString(deserializedObj.Html);
        }
    }
}