using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Oembed;
using EPiServer.Oembed.DefaultProviders;
using EPiServer.ServiceLocation;

namespace EpiserverPlayground
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class StructureMapSetUp : IConfigurableModule
    {
        
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IOEmbedProvider, YouTubeOEmbedProvider>();
            context.Services.AddSingleton<IOEmbedProvider, VimeoOEmbedProvider>();
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

    }
}