using EPiServer.Core;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed
{
    public interface IOEmbedBlock
    {
        string MediaUrl { get; set; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        string FullResponse { get; set; }
    }
}