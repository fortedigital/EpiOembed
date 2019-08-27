namespace EPiServer.Oembed
{
    public interface IOEmbedProvider
    {
        int? MaxWidth { get; set; }
        int? MaxHeight { get; set; }

        bool CanInterpretMediaUrl(string url);

        string GetRequestUrl(IOEmbedBlock block);

    }
}