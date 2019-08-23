using EPiServer.Core;

namespace EPiServer.Oembed
{
    public interface IOEmbedBlock
    {
        string MediaUrl { get; set; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        string EmbedResponse { get; set; }
    }
}