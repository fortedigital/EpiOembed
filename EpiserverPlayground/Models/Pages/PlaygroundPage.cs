using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverPlayground.Models.Pages
{
    [SiteContentType(
       GroupName = Global.GroupNames.News,
       GUID = "307827bb-aadd-4663-88b2-ed426234ceab")]
    [ContentType(DisplayName = "PlaygroundPage", GUID = "307827bb-aadd-4663-88b2-ed426234ceab", Description = "")]
    public class PlaygroundPage : StandardPage
    {
        public virtual string OembedString { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            //OembedString = GetOembedHtml();
            OembedString = "";
        }

        public string GetOembedHtml()
        {
            var module = new OembedModule(@"http://www.flickr.com/services/oembed/?format=json&url=http%3A//www.flickr.com/photos/bees/2341623661/");
            return module.GetResponseHtml();
        }

    }
}