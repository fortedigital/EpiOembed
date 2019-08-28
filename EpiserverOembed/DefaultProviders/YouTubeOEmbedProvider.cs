namespace EPiServer.Oembed.DefaultProviders
{
    public class YouTubeOEmbedProvider : BaseOEmbedProvider
    {
        public YouTubeOEmbedProvider(int? maxWidth = null, int? maxHeight = null)
        {
            UrlSchemePattern = @"^(https://.*\.youtube\.com/watch.*)|(https://.*\.youtube\.com/v/.*)|(https://youtu\.be/.*)";
            ApiEndpoint = "https://www.youtube.com/oembed";
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
        }
        
    }
}