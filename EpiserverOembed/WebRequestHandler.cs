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
            if(uri == null)
                return null;
            
            WebClient client = new WebClient();
            try
            {
                var response = client.DownloadString(uri);
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