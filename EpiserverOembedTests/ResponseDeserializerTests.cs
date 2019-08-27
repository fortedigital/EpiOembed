using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using EPiServer.Oembed;
using EPiServer.Oembed.DefaultProviders;
using EPiServer.Oembed.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace EpiserverOembedTests
{
    [TestFixture]
    public class ResponseDeserializerTests
    {
        [Test]
        public void NullResponseTest()
        {
            var obj = ResponseDeserializer.DeserializeResponse(null, FormatType.json);
            
            Assert.IsNull(obj);
        }

        [Test]
        public void ProviderDeserializationTestWithFullObjectJson()
        {
            var response = "{\"type\": \"video\", \"title\": \"TestTitle\", \"thumbnail_url\": \"TestThumbnailUrl\"," +
                           "\"thumbnail_width\": 640, \"thumbnail_height\": 480, \"html\": \"TestHtml\", \"width\": 800, \"height\": 600}";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.json);
            
            Assert.True(FullObject.Equals(actual));
        }

        [Test]
        public void ProviderDeserializationTestWithMissingPropertiesJson()
        {
            var response = "{\"type\": \"video\",\"html\": \"TestHtml\"}";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.json);
            
            Assert.True(MissingPropertiesObject.Equals(actual));
        }

        [Test]
        public void ProviderDeserializationTestWithAdditionalPropertiesJson()
        {
            var response = "{\"type\": \"video\", \"title\": \"TestTitle\", \"thumbnail_url\": \"TestThumbnailUrl\", \"additional\": \"Test\"," +
                           "\"thumbnail_width\": 640, \"thumbnail_height\": 480, \"html\": \"TestHtml\", \"width\": 800, \"height\": 600}";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.json);
            
            Assert.True(FullObject.Equals(actual));
        }
        
        [Test]
        public void ProviderDeserializationTestWithFullObjectXml()
        {
            var response = @"<oembed><type>video</type><title>TestTitle</title><thumbnail_url>TestThumbnailUrl</thumbnail_url>" + 
                           @"<thumbnail_width>640</thumbnail_width><thumbnail_height>480</thumbnail_height><html>TestHtml</html>" + 
                           @"<width>800</width><height>600</height></oembed>";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.xml);
            
            Assert.True(FullObject.Equals(actual));
        }

        [Test]
        public void ProviderDeserializationTestWithMissingPropertiesXml()
        {
            var response = @"<oembed><type>video</type><html>TestHtml</html></oembed>";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.xml);
            
            Assert.True(MissingPropertiesObject.Equals(actual));
        }

        [Test]
        public void ProviderDeserializationTestWithAdditionalPropertiesXml()
        {
            var response = @"<oembed><type>video</type><title>TestTitle</title><thumbnail_url>TestThumbnailUrl</thumbnail_url>" + 
                           @"<thumbnail_width>640</thumbnail_width><thumbnail_height>480</thumbnail_height><html>TestHtml</html>" + 
                           @"<width>800</width><height>600</height><additional>Test</additional></oembed>";

            var actual = ResponseDeserializer.DeserializeResponse(response, FormatType.xml);
            
            Assert.True(FullObject.Equals(actual));
        }
        
        private static readonly ResponseObject FullObject = new ResponseObject()
        {
            Type = ResponseType.video,
            Title = "TestTitle",
            ThumbnailUrl = "TestThumbnailUrl",
            ThumbnailWidth = 640,
            ThumbnailHeight = 480,
            Html = "TestHtml",
            Width = 800,
            Height = 600
        };
        
        private static readonly ResponseObject MissingPropertiesObject = new ResponseObject()
        {
            Type = ResponseType.video,
            Html = "TestHtml"
        };
        
    }
}