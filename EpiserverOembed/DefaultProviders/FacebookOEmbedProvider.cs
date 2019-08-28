using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public class FacebookOEmbedProvider : BaseOEmbedProvider
    {
        private string UrlSchemePatternVideos { get; set; }

        private string _resourceType;
        
        public FacebookOEmbedProvider(int? maxWidth = null)
        {
            UrlSchemePattern = @"^(https://www\.facebook\.com/.*/posts/.*)|(https://www\.facebook\.com/.*/activity/.*)|" +
                               @"(https://www\.facebook\.com/photo\.php?fbid=.*)|(https://www\.facebook\.com/photos/.*)|" +
                               @"(https://www\.facebook\.com/permalink\.php?story_fbid=.*)|(https://www\.facebook\.com/media/set?set=.*)|" +
                               @"(https://www\.facebook\.com/questions/.*)|(https://www\.facebook\.com/notes/.*/.*/.*)";

            UrlSchemePatternVideos = @"^(https://www\.facebook\.com/.*/videos/.*/)|(https://www\.facebook\.com/video\.php?id=.*)" +
                                     @"|(https://www\.facebook\.com/video\.php?v=.*)";

            ApiEndpoint = "https://www.facebook.com/plugins/";

            MaxWidth = maxWidth;
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
            var url = ApiEndpoint + _resourceType + "/oembed.json?url=" + block.MediaUrl;
            if (MaxWidth != null)
            {
                url = url + "&maxwidth=" + MaxWidth;
            }
            return url;
        }
    }
}