using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EpiserverPlayground.Models.Blocks;

namespace EpiserverPlayground.Controllers
{
    public class OEmbedBlockController : BlockController<OEmbedBlock>
    {
        public override ActionResult Index(OEmbedBlock currentContent)
        {
            return PartialView(currentContent);
        }
    }
}