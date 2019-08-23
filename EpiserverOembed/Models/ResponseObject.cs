using EPiServer.Core;

namespace EPiServer.Oembed.Models
{
    public class ResponseObject
    {
        
        public ResponseType Type { get; set; }

        public string Version { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string AuthorUrl { get; set; }

        public string ProviderName { get; set; }

        public string ProviderUrl { get; set; }

        public int CacheAge { get; set; }

        public string ThumbnailUrl { get; set; }

        public int ThumbnailWidth { get; set; }

        public int ThumbnailHeight { get; set; }

        public XhtmlString Html { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}