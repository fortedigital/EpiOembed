using System;
using EPiServer.Find.Helpers.Text;
using EPiServer.Logging;
using EPiServer.Oembed.Models;
using Newtonsoft.Json;

namespace EPiServer.Oembed
{
    public class ResponseDeserializer
    {
        private static readonly ILogger Logger = LogManager.GetLogger();

        public static ResponseObject DeserializeResponse(string response)
        {
            if (response.IsNullOrWhiteSpace())
                return null;
            
            try
            {
                ResponseObject deserializedObj;
                var settings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Ignore, 
                    NullValueHandling = NullValueHandling.Ignore};
                deserializedObj = JsonConvert.DeserializeObject<ResponseObject>(response, settings);
                return deserializedObj;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                return null;
            }
        }
    }
}