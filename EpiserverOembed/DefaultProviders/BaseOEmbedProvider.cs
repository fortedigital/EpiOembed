using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public abstract class BaseOEmbedProvider : IOEmbedProvider
    {
        public int? MaxWidth { get; set; }
        public int? MaxHeight { get; set; }
        protected string UrlSchemePattern { get; set; }

        protected BaseOEmbedProvider(int? maxWidth= null, int? maxHeight = null)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
        }
        
        public virtual bool CanInterpretMediaUrl(string url)
        {
            return Regex.IsMatch(url, UrlSchemePattern);
        }

        public virtual string GetRequestUrl(IOEmbedBlock block)
        {
            var url = string.Empty;
            if (MaxWidth != null)
            {
                url = url + "&maxwidth=" + MaxWidth;
            }
            if (MaxHeight != null)
            {
                url = url + "&maxheight=" + MaxHeight;
            }

            return url;
        }
    }
}