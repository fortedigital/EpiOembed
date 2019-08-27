using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public class FacebookOEmbedProvider : BaseOEmbedProvider
    {
        private string UrlSchemePatternVideos { get; set; }

        private string _resourceType;
        
        public FacebookOEmbedProvider(int? maxWidth = null) : base(maxWidth: maxWidth)
        {
            UrlSchemePattern = @"^(https://www\.facebook\.com/.*/posts/.*)|(https://www\.facebook\.com/.*/activity/.*)|" +
                               @"(https://www\.facebook\.com/photo\.php?fbid=.*)|(https://www\.facebook\.com/photos/.*)|" +
                               @"(https://www\.facebook\.com/permalink\.php?story_fbid=.*)|(https://www\.facebook\.com/media/set?set=.*)|" +
                               @"(https://www\.facebook\.com/questions/.*)|(https://www\.facebook\.com/notes/.*/.*/.*)";

            UrlSchemePatternVideos = @"^(https://www\.facebook\.com/.*/videos/.*/)|(https://www\.facebook\.com/video\.php?id=.*)" +
                                     @"|(https://www\.facebook\.com/video\.php?v=.*)";
        }

        public override bool CanInterpretMediaUrl(string url)
        {
            if (Regex.IsMatch(url, UrlSchemePattern))
            {
                _resourceType = "post";
                return true;
            }
            if (Regex.IsMatch(url, UrlSchemePatternVideos))
            {
                _resourceType = "video";
                return true;
            }
            return false;
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://www.facebook.com/plugins/" + _resourceType + "/oembed.json?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return url;
        }
    }
}