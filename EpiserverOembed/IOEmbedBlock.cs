using System;
using EPiServer.Core;

namespace EpiserverOembed
{
    public interface IOEmbedBlock
    {
        string MediaUrl { get; }

        string ThumbnailUrl { get; set; }

        XhtmlString EmbedHtml { get; set; }

        string EmbedResponse { get; set; }
    }
}