using EPiServer.Core;
using EPiServer.DataAnnotations;
using Episerver.Oembed;
using EpiserverPlayground.Models.Blocks;

namespace EpiserverPlayground.Models.Pages
{
    [SiteContentType(
        GroupName = Global.GroupNames.News,
        GUID = "A6EE3B06-AA07-411D-8EC5-056D9FDAC588")]
    [ContentType(DisplayName = "TestingPage", GUID = "A6EE3B06-AA07-411D-8EC5-056D9FDAC588", Description = "")]
    public class TestingPage : StandardPage
    {
        
        public virtual YouTubeBlock YouTubeBlock { get; set; }
    }
}