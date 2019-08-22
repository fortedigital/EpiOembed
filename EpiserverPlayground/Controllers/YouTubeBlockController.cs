using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverPlayground.Models.Blocks;

namespace EpiserverPlayground.Controllers
{
    public class YouTubeBlockController : BlockController<YouTubeBlock>
    {
        public override ActionResult Index(YouTubeBlock currentContent)
        {
            return PartialView(currentContent);
        }
    }
}