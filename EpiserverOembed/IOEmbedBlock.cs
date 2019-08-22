using EPiServer.Core;

namespace Episerver.Oembed
{
    public interface IOEmbedBlock
    {
        string MediaUrl { get; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        string EmbedResponse { get; set; }
    }
}