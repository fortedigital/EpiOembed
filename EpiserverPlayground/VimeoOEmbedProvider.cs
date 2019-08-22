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

        public string GetAPIEndpoint()
        {
            return "https://vimeo.com/api/oembed.json";
        }

        public IDictionary<string, string> GetQueryParameters()
        {
            var dict = new Dictionary<string, string> {["format"] = "json"};
            return dict;
        }
    }
}