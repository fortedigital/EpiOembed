using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EpiserverPlayground.Models.Blocks;

namespace EpiserverPlayground
{
    [ScheduledPlugIn(DisplayName = "Test")]
    public class TestJob : ScheduledJobBase
    {
        public override string Execute()
        {
            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var video = repo.Get<OEmbedBlock>(new ContentReference(19135));
            video = (OEmbedBlock) video.CreateWritableClone();

            video.MediaUrl = "https://twitter.com/Interior/status/507185938620219395";

            repo.Save((IContent) video, SaveAction.Publish);
            
            
            return "done";
        }
    }
}