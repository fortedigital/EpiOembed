using System.Text.RegularExpressions;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed.DefaultProviders
{
    public class YouTubeOEmbedProvider : BaseOEmbedProvider
    {
        public YouTubeOEmbedProvider(int? maxWidth = null, int? maxHeight = null, FormatType formatType = FormatType.json) 
            : base(maxWidth, maxHeight, formatType){ }
        
        public override bool CanInterpretMediaUrl(string url)
        {
            var regex = new Regex("(https://.*\\.youtube\\.com/watch.*)|(https://.*\\.youtube\\.com/v/.*)|(https://youtu\\.be/.*)");
            return regex.IsMatch(url);
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://www.youtube.com/oembed?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            url = url + "&format=" + FormatType;
            return  url;
        }

    }
}