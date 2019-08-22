using Episerver.Oembed;
using EPiServer.ServiceLocation;

namespace EpiserverPlayground
{
    [ServiceConfiguration(ServiceType = typeof(IOEmbedProvider))]
    public class YouTubeOEmbedProvider : IOEmbedProvider
    {
        public bool TryInterpretUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}