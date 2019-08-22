using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Episerver.Oembed;
using EPiServer.ServiceLocation;
using StructureMap;

namespace EpiserverPlayground
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class StructureMapSetUp : IConfigurableModule
    {
        //private IContainer _container;

        public void ConfigureContainer(ServiceConfigurationContext context)
        {

            context.Services.Add<IOEmbedProvider>(f => new YouTubeOEmbedProvider(), ServiceInstanceScope.Transient);
            
            /*
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.StructureMap()));
            _container = context.StructureMap();*/
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

    }
}