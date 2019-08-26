using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using EPiServer.Logging;
using EPiServer.Oembed.Models;
using Newtonsoft.Json;

namespace EPiServer.Oembed
{
    public class ResponseDeserializer
    {
        private static readonly ILogger Logger = LogManager.GetLogger();

        public static ResponseObject DeserializeResponse(string response, FormatType format)
        {
            try
            {
                ResponseObject deserializedObj;
                if (format == FormatType.json)
                {
                    var settings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Ignore};
                    deserializedObj = JsonConvert.DeserializeObject<ResponseObject>(response, settings);
                }
                else
                {
                    var serializer = new XmlSerializer(typeof(ResponseObject));
                    var stream = new MemoryStream(Encoding.UTF8.GetBytes(response));
                    deserializedObj = (ResponseObject) serializer.Deserialize(stream);
                }
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