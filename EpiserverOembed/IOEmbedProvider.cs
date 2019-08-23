using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Episerver.Oembed
{
    public interface IOEmbedProvider
    {
        bool CanInterpretMediaUrl(string url);

        string GetRequestUrl(IOEmbedBlock block);
        

    }
}