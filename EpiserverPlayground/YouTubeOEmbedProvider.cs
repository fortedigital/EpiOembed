using System.Collections.Generic;
using System.Text.RegularExpressions;
using Episerver.Oembed;

namespace EpiserverPlayground
{
    public class YouTubeOEmbedProvider : IOEmbedProvider
    {
        public bool CanInterpretMediaUrl(string url)
        {
            var regex = new Regex("(https://.*\\.youtube\\.com/watch.*)|(https://.*\\.youtube\\.com/v/.*)|(https://youtu\\.be/.*)");
            return regex.IsMatch(url);
        }

        public string GetRequestUrl(IOEmbedBlock block)
        {
            return "https://www.youtube.com/oembed?url=" + block.MediaUrl;
        }
        
    }
}