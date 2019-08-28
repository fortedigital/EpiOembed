namespace EPiServer.Oembed.DefaultProviders
{
    public class TwitterOEmbedProvider : BaseOEmbedProvider
    {
        public TwitterOEmbedProvider()
        {
            UrlSchemePattern = @"^(https://twitter\.com/.*/status/.*)|(https://.*\.twitter\.com/.*/status/.*)";
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            return "https://publish.twitter.com/oembed?url=" + block.MediaUrl;
        }
    }
}