using EPiServer.Oembed.Models;

namespace EPiServer.Oembed
{
    public interface IOEmbedProvider
    {
        int? MaxWidth { get; set; }
        int? MaxHeight { get; set; }
        FormatType FormatType { get; set; }
        string UrlSchemePattern { get; set; }

        bool CanInterpretMediaUrl(string url);

        string GetRequestUrl(IOEmbedBlock block);

    }
}