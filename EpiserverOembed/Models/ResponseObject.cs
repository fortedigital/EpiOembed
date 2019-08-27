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

        [XmlElement(ElementName = "title")]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ResponseObject resp = (ResponseObject) obj;
            var equality = Type == resp.Type &&
                           Title == resp.Title &&
                           ThumbnailUrl == resp.ThumbnailUrl &&
                           ThumbnailHeight == resp.ThumbnailHeight &&
                           ThumbnailWidth == resp.ThumbnailWidth &&
                           Html == resp.Html &&
                           Width == resp.Width && Height == resp.Height;
            return equality;   
        }
    }
}