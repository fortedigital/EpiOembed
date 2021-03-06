using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Oembed;
using EPiServer.Oembed.Models;

namespace EpiserverPlayground.Models.Blocks
{
    [SiteContentType(GUID = "EACCFAD1-EC79-4D2D-805F-DAC6B3EACE6A")]
    [SiteImageUrl]
    public class OEmbedBlock : SiteBlockData, IOEmbedBlock
    {
        public virtual string MediaUrl { get; set; }
        
        public virtual string ThumbnailUrl { get; set; }
        
        public virtual XhtmlString EmbedHtml { get; set; }

        [BackingType(typeof(PropertyResponseObject))]
        public virtual ResponseObject Response { get; set; }
        
    }
}