namespace EPiServer.Oembed.DefaultProviders
{
    /// <summary>
    /// Default implementation of YouTube provider
    /// </summary>
    public class YouTubeOEmbedProvider : BaseOEmbedProvider
    {
        public YouTubeOEmbedProvider()
        {
            UrlSchemePattern = @"^(https://.*\.youtube\.com/watch.*)|(https://.*\.youtube\.com/v/.*)|(https://youtu\.be/.*)";
            ApiEndpoint = "https://www.youtube.com/oembed";
        }
        
    }
}