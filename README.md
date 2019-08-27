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

2. Create block using IOEmbedBlock interface (or BaseOEmbedBlock class)

```csharp
public class OEmbedBlock : BlockData, IOEmbedBlock{...}
```

If you're using interface then add [BackingType(typeof(PropertyResponseObject))] attribute to Response property

## Usage:

Urls to resources are supplied through MediaUrl property in block interface.
