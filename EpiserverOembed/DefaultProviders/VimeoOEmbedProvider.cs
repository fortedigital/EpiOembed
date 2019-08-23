using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    public class VimeoOEmbedProvider : IOEmbedProvider
    {
        public bool CanInterpretMediaUrl(string url)
        {
            var regex = new Regex("(https://vimeo\\.com/.*)|(https://vimeo\\.com/album/.*/video/.*)|" +
                                  "(https://vimeo\\.com/channels/.*/.*)|(https://vimeo\\.com/groups/.*/videos/.*)|" +
                                  "(https://vimeo\\.com/ondemand/.*/.*)|(https://player\\.vimeo\\.com/video/.*)");
            return regex.IsMatch(url);
        }

        public string GetRequestUrl(IOEmbedBlock block)
        {
            return "https://vimeo.com/api/oembed.json?url=" + block.MediaUrl;
        }

    }
}