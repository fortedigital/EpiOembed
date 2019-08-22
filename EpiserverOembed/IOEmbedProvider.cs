using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Episerver.Oembed
{
    public interface IOEmbedProvider
    {
        bool CanInterpretMediaUrl(string url);

        string GetAPIEndpoint();

        //Should return dictionary with these keys only: maxwidth, maxheight, format
        IDictionary<string, string> GetQueryParameters();

    }
}