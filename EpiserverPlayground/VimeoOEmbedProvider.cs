using System.Collections.Generic;
using System.Text.RegularExpressions;
using Episerver.Oembed;

namespace EpiserverPlayground
{
    public class VimeoOEmbedProvider : IOEmbedProvider
    {
        public bool CanInterpretMediaUrl(string url)
        {
            var regex = new Regex("(https://vimeo\\.com/.*)"); //TODO: more schemes available
            return regex.IsMatch(url);
        }

        public string GetRequestUrl(IOEmbedBlock block)
        {
            return "https://vimeo.com/api/oembed.json?url=" + block.MediaUrl;
        }

    }
}