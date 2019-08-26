using EPiServer.Core;
using EPiServer.Oembed;

namespace EpiserverPlayground.Models.Blocks
{
    [SiteContentType(GUID = "EACCFAD1-EC79-4D2D-805F-DAC6B3EACE6A")]
    [SiteImageUrl]
    public class OEmbedBlock : SiteBlockData, IOEmbedBlock
    {
        public virtual string MediaUrl { get; set; }
        
        public virtual string ThumbnailUrl { get; set; }
        
        public virtual XhtmlString EmbedHtml { get; set; }
        
        public virtual string FullResponse { get; set; }

    }
}