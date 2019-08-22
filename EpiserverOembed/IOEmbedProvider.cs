using Newtonsoft.Json.Linq;

namespace Episerver.Oembed
{
    public interface IOEmbedProvider
    {
        bool CanInterpretMediaUrl(string url);

        JObject MakeRequest(IOEmbedBlock block);

    }
}