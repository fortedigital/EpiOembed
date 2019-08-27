# EpiOembed - embedding module for EPiServer using OEmbed standard

## Basic configuration:

1. Configure DI container - register IOembedProviders in context.Services (Default providers available in package):

```csharp
	[InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SampleConfigurationModule : IConfigurableModule
    {
        
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Add(...);
        }
	}
```

2. Create block using IOEmbedBlock interface

```csharp
	public class OEmbedBlock : BlockData, IOEmbedBlock{...}
```

## Usage:

Urls to resources are supplied through MediaUrl property in block interface.
