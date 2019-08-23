namespace EPiServer.Oembed
{
    public interface IOEmbedProvider
    {
        bool CanInterpretMediaUrl(string url);

        string GetRequestUrl(IOEmbedBlock block);

    }
}