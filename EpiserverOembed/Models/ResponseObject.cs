using System.Xml.Serialization;
using Newtonsoft.Json;

namespace EPiServer.Oembed.Models
{
    [XmlRoot(ElementName = "oembed")]
    public class ResponseObject
    {
        
        [XmlElement(ElementName = "type")]
        [JsonProperty(PropertyName = "type")]
        public ResponseType Type { get; set; }

        [XmlElement(ElementName = "version")]
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [XmlElement(ElementName = "title")]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        
        [XmlElement(ElementName = "author_name")]
        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName { get; set; }
        
        [XmlElement(ElementName = "author_url")]
        [JsonProperty(PropertyName = "author_url")]
        public string AuthorUrl { get; set; }
        
        [XmlElement(ElementName = "provider_name")]
        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }

        [XmlElement(ElementName = "provider_url")]
        [JsonProperty(PropertyName = "provider_url")]
        public string ProviderUrl { get; set; }

        [XmlElement(ElementName = "cache_age")]
        [JsonProperty(PropertyName = "cache_age")]
        public int CacheAge { get; set; }

        [XmlElement(ElementName = "thumbnail_url")]
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [XmlElement(ElementName = "thumbnail_width")]
        [JsonProperty(PropertyName = "thumbnail_width")]
        public int ThumbnailWidth { get; set; }

        [XmlElement(ElementName = "thumbnail_height")]
        [JsonProperty(PropertyName = "thumbnail_height")]
        public int ThumbnailHeight { get; set; }

        [XmlElement(ElementName = "html")]
        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }

        [XmlElement(ElementName = "width")]
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [XmlElement(ElementName = "height")]
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }
}