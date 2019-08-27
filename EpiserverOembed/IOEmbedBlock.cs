using EPiServer.Core;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed
{
    public interface IOEmbedBlock : IContentData
    {
        string MediaUrl { get; set; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        ResponseObject Response { get; set; }
    }
}