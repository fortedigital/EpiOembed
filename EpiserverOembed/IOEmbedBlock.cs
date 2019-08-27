using EPiServer.Core;

namespace EPiServer.Oembed
{
    public interface IOEmbedBlock : IContentData
    {
        string MediaUrl { get; set; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        string FullResponse { get; set; }
    }
}