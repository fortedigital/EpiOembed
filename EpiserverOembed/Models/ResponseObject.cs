using Newtonsoft.Json;

namespace EPiServer.Oembed.Models
{

    /// <summary>
    /// Object holding most important response values
    /// </summary>
    public class ResponseObject
    {
        /// <summary>
        /// Type of the response: video, photo, text, rich
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ResponseType Type { get; set; }

        /// <summary>
        /// Title of the response
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Url to the thumbnail
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Width of the thumbnail
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_width")]
        public int ThumbnailWidth { get; set; }

        /// <summary>
        /// Height of the thumbnail
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_height")]
        public int ThumbnailHeight { get; set; }

        /// <summary>
        /// Html of the embedded resource
        /// </summary>
        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }

        /// <summary>
        /// Width of the response
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        /// <summary>
        /// Height of the response
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

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

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Type;
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThumbnailUrl != null ? ThumbnailUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ThumbnailWidth;
                hashCode = (hashCode * 397) ^ ThumbnailHeight;
                hashCode = (hashCode * 397) ^ (Html != null ? Html.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Width;
                hashCode = (hashCode * 397) ^ Height;
                return hashCode;
            }
        }
    }
}