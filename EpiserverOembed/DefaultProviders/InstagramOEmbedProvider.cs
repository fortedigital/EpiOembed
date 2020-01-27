namespace EPiServer.Oembed.DefaultProviders
{
    /// <summary>
    /// Default implementation of Instagram provider
    /// </summary>
    public class InstagramOEmbedProvider : BaseOEmbedProvider
    {

        public InstagramOEmbedProvider()
        {
            UrlSchemePattern = @"^(http://instagram\.com/p/.*)|(http://instagr\.am/p/.*)|" +
                               @"(http://www\.instagram\.com/p/.*)|(http://www\.instagr\.am/p/.*)|" +
                               @"(https://instagram\.com/p/.*)|(https://instagr\.am/p/.*)|" +
                               @"(https://www\.instagram\.com/p/.*)|(https://www\.instagr\.am/p/.*)";
            ApiEndpoint = "https://api.instagram.com/oembed";
        }

    }
}