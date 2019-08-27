using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public class InstagramOEmbedProvider : BaseOEmbedProvider
    {

        public InstagramOEmbedProvider(int? maxWidth = null) : base(maxWidth: maxWidth)
        {
            UrlSchemePattern = @"^(http://instagram\.com/p/.*)|(http://instagr\.am/p/.*)|" +
                               @"(http://www\.instagram\.com/p/.*)|(http://www\.instagr\.am/p/.*)|" +
                               @"(https://instagram\.com/p/.*)|(https://instagr\.am/p/.*)|" +
                               @"(https://www\.instagram\.com/p/.*)|(https://www\.instagr\.am/p/.*)";
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://api.instagram.com/oembed?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return url;
        }
    }
}