using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAccess;

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
            if (action != SaveAction.Publish)
                return;

            if (string.IsNullOrWhiteSpace(embedBlock.MediaUrl))
            {
                ClearBlockProperties(embedBlock);
                return;
            }

            var foundProvider = _providers.FirstOrDefault(x => x.CanInterpretMediaUrl(embedBlock.MediaUrl));
            if(foundProvider == null)
                return;
            
            var uri = new Uri(foundProvider.GetRequestUrl(embedBlock.MediaUrl));
            var response = WebRequestHandler.GetResponse(uri);

            var deserializedObj = ResponseDeserializer.DeserializeResponse(response);

            if (deserializedObj == null)
                return;
            
            embedBlock.ThumbnailUrl = deserializedObj.ThumbnailUrl;
            embedBlock.EmbedHtml = new XhtmlString(deserializedObj.Html);
            embedBlock.Response = deserializedObj;
        }

        private static void ClearBlockProperties(IOEmbedBlock block)
        {
            block.ThumbnailUrl = null;
            block.EmbedHtml = null;
            block.Response = null;
        }
    }
}