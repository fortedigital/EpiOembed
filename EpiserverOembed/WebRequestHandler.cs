using System;
using System.Net;
using EPiServer.Logging;

namespace EPiServer.Oembed
{
    public class WebRequestHandler
    {
        private static readonly ILogger Logger = LogManager.GetLogger();
        
        public static string GetResponse(Uri uri)
        {
            WebClient client = new WebClient();
            try
            {
                var response = client.DownloadStringTaskAsync(uri).Result;
                return response;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                return null;
            }
        }
        
    }
}