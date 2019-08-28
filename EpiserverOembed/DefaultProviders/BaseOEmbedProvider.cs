using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public abstract class BaseOEmbedProvider : IOEmbedProvider
    {
        public int? MaxWidth { get; set; }
        public int? MaxHeight { get; set; }
        protected string UrlSchemePattern { get; set; }
        protected string ApiEndpoint { get; set; }
        
        public virtual bool CanInterpretMediaUrl(string url)
        {
            return Regex.IsMatch(url, UrlSchemePattern);
        }

        public virtual string GetRequestUrl(IOEmbedBlock block)
        {
            var url = ApiEndpoint + "?url=" + block.MediaUrl;
            if (MaxHeight != null)
            {
                url = url + "&maxheight=" + MaxHeight;
            }
            if (MaxWidth != null)
            {
                url = url + "&maxwidth=" + MaxWidth;
            }
            return url;
        }
    }
}