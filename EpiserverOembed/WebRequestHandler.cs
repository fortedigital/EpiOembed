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
            client.Headers.Add(HttpRequestHeader.UserAgent, 
                "Mozilla / 5.0(Windows; U; WindowsNT 5.1; en - US; rv1.8.1.6) Gecko / 20070725 Firefox / 2.0.0.6");
            
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