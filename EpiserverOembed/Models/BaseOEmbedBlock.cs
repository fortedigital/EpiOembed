using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EPiServer.Oembed.Models
{
    /// <summary>
    /// Base abstract implementation of IOEmbedBlock interface
    /// </summary>
    public abstract class BaseOEmbedBlock : BlockData, IOEmbedBlock
    {
        public virtual string MediaUrl { get; set; }
        
        public virtual string ThumbnailUrl { get; set; }
        
        public virtual XhtmlString EmbedHtml { get; set; }
        
        [BackingType(typeof(PropertyResponseObject))]
        public virtual ResponseObject Response { get; set; }
    }
}