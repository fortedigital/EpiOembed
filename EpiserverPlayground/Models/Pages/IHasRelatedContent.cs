using EPiServer.Core;

namespace EpiserverPlayground.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
