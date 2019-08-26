using System.Text.RegularExpressions;
using EPiServer.Oembed.Models;

namespace EPiServer.Oembed.DefaultProviders
{
    public class VimeoOEmbedProvider : BaseOEmbedProvider
    {
        public VimeoOEmbedProvider(int? maxWidth = null, int? maxHeight = null, FormatType formatType = FormatType.json) 
            : base(maxWidth, maxHeight, formatType){ }
        
        public override bool CanInterpretMediaUrl(string url)
        {
            const string pattern = @"(^https://vimeo\\.com/.*)|(^https://vimeo\\.com/album/.*/video/.*)|" +
                                   "(^https://vimeo\\.com/channels/.*/.*)|(^https://vimeo\\.com/groups/.*/videos/.*)|" +
                                   "(^https://vimeo\\.com/ondemand/.*/.*)|(^https://player\\.vimeo\\.com/video/.*)";
            return Regex.IsMatch(url, pattern);
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://vimeo.com/api/oembed." + FormatType + "?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return url;
        }

    }
}