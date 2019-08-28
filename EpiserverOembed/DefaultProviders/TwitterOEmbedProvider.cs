namespace EPiServer.Oembed.DefaultProviders
{
    /// <summary>
    /// Default implementation of Twitter provider
    /// </summary>
    public class TwitterOEmbedProvider : BaseOEmbedProvider
    {
        public TwitterOEmbedProvider()
        {
            UrlSchemePattern = @"^(https://twitter\.com/.*/status/.*)|(https://.*\.twitter\.com/.*/status/.*)";
            ApiEndpoint = "https://publish.twitter.com/oembed";
        }
    }
}