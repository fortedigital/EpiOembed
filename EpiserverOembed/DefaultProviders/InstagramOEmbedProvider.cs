using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public class InstagramOEmbedProvider : BaseOEmbedProvider
    {

        public InstagramOEmbedProvider(int? maxWidth = null)
        {
            UrlSchemePattern = @"^(http://instagram\.com/p/.*)|(http://instagr\.am/p/.*)|" +
                               @"(http://www\.instagram\.com/p/.*)|(http://www\.instagr\.am/p/.*)|" +
                               @"(https://instagram\.com/p/.*)|(https://instagr\.am/p/.*)|" +
                               @"(https://www\.instagram\.com/p/.*)|(https://www\.instagr\.am/p/.*)";
            ApiEndpoint = "https://api.instagram.com/oembed";
            MaxWidth = maxWidth;
        }

    }
}