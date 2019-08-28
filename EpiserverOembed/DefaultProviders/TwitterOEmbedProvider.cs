namespace EPiServer.Oembed.DefaultProviders
{
    public class TwitterOEmbedProvider : BaseOEmbedProvider
    {
        public TwitterOEmbedProvider()
        {
            UrlSchemePattern = @"^(https://twitter\.com/.*/status/.*)|(https://.*\.twitter\.com/.*/status/.*)";
            ApiEndpoint = "https://publish.twitter.com/oembed";
        }
    }
}