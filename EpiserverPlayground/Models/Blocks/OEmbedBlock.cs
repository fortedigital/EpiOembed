using EPiServer.Core;
using EPiServer.DataAbstraction;
using Episerver.Oembed;

namespace EpiserverPlayground.Models.Blocks
{
    [SiteContentType(GUID = "EACCFAD1-EC79-4D2D-805F-DAC6B3EACE6A")]
    [SiteImageUrl]
    public class OEmbedBlock : SiteBlockData, IOEmbedBlock
    {
        public virtual string MediaUrl { get; set; }
        
        public virtual string ThumbnailUrl { get; set; }
        
        public virtual XhtmlString EmbedHtml { get; set; }
        
        public virtual string EmbedResponse { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            //MediaUrl = @"https://www.youtube.com/oembed?url=http%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DiwGFalTRHDA";
        }
    }
}