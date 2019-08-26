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
            var regex = new Regex("(https://vimeo\\.com/.*)|(https://vimeo\\.com/album/.*/video/.*)|" +
                                  "(https://vimeo\\.com/channels/.*/.*)|(https://vimeo\\.com/groups/.*/videos/.*)|" +
                                  "(https://vimeo\\.com/ondemand/.*/.*)|(https://player\\.vimeo\\.com/video/.*)");
            return regex.IsMatch(url);
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://vimeo.com/api/oembed." + FormatType + "?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return url;
        }

    }
}