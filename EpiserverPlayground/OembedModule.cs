using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace EpiserverPlayground
{
    public class OembedModule
    {
        
        private string URI;
        
        public OembedModule(string uri)
        {
            URI = uri;
        }

        public string GetResponseHtml()
        {
            dynamic json = Get(URI);
            return json.html.Value as string;
        }

        public object Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) //exception 404 not found
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var responseString = reader.ReadToEnd();
                return JsonConvert.DeserializeObject(responseString);
            }
        }
    }
}