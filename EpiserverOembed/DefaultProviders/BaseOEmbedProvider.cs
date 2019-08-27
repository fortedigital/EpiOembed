using System.Text.RegularExpressions;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed.DefaultProviders
{
    public abstract class BaseOEmbedProvider : IOEmbedProvider
    {
        public int? MaxWidth { get; set; }
        public int? MaxHeight { get; set; }
        public FormatType FormatType { get; set; }
        public string UrlSchemePattern { get; set; }

        public BaseOEmbedProvider(int? maxWidth= null, int? maxHeight = null, FormatType formatType = FormatType.json)
        {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            FormatType = formatType;
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