# EpiOembed

This plugin will enable you to create blocks displaying any media from sites that support oembed standard

## Basic configuration:

**Version 1.0.22942 automatically detects classes implementing IOEmbedProvider interface so you can skip step 1**

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

**Make sure that provider has paramaterless constructor**

## Usage:

Urls to resources are supplied through MediaUrl property in block interface.

You'll probably want to hide other properties from editors.

Other response properties like media width/height, thumbnail width/height can be accessed through Response property
