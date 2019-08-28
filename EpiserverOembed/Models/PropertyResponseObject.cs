using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using Newtonsoft.Json;

namespace EPiServer.Oembed.Models
{
    /// <summary>
    /// Custom propertyData implementation for block's response property 
    /// </summary>
    [PropertyDefinitionTypePlugIn(Description = "Property for OEmbed response", DisplayName = "OEmbed Response")]
    public class PropertyResponseObject : PropertyLongString
    {
        public override Type PropertyValueType => typeof(ResponseObject);

        public override object Value
        {
            get
            {
                var value = base.Value as string;
                return value == null ? null : JsonConvert.DeserializeObject<ResponseObject>(value);
            }
            set
            {
                if (value is ResponseObject)
                {
                    base.Value = JsonConvert.SerializeObject(value);
                }
                else
                {
                    base.Value = value;
                }
                
            }
        }

        public override object SaveData(PropertyDataCollection properties)
        {
            return LongString;
        }
    }
}