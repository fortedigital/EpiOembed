using EPiServer.Core;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed
{
    /// <summary>
    /// Interface for block holding most important properties for working with oembed
    /// </summary>
    public interface IOEmbedBlock : IContentData
    {
        /// <summary>
        /// Url to the media to be embedded
        /// </summary>
        string MediaUrl { get; set; }

        /// <summary>
        /// Url to the thumbnail returned in oembed response
        /// </summary>
        string ThumbnailUrl { get; set; }

        /// <summary>
        /// Html ready to be embedded returned in response
        /// </summary>
        XhtmlString EmbedHtml { get; set; }

        /// <summary>
        /// Reference to full response
        /// </summary>
        ResponseObject Response { get; set; }
    }
}