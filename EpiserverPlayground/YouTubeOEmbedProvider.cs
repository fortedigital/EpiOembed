using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using EPiServer.Core;
using Episerver.Oembed;
using EPiServer.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EpiserverPlayground
{
    public class YouTubeOEmbedProvider : IOEmbedProvider
    {
        private const string APIendpoint = "https://www.youtube.com/oembed?url=";
        
        public bool CanInterpretMediaUrl(string url)
        {
            var regex = new Regex("(https://.*\\.youtube\\.com/watch.*)|(https://.*\\.youtube\\.com/v/.*)|(https://youtu\\.be/.*)");
            return regex.IsMatch(url);
        }

        public JObject MakeRequest(IOEmbedBlock block)
        {
            Uri uri = new Uri(APIendpoint + block.MediaUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) //exception 404 not found
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());
            }
        }
    }
}