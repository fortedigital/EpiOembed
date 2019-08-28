namespace EPiServer.Oembed.DefaultProviders
{
    /// <summary>
    /// Default implementation of Vimeo provider
    /// </summary>
    public class VimeoOEmbedProvider : BaseOEmbedProvider
    {
        public VimeoOEmbedProvider(int? maxWidth = null, int? maxHeight = null)
        {
            UrlSchemePattern = @"^(https://vimeo\.com/.*)|(https://vimeo\.com/album/.*/video/.*)|" +
                               @"(https://vimeo\.com/channels/.*/.*)|(https://vimeo\.com/groups/.*/videos/.*)|" +
                               @"(https://vimeo\.com/ondemand/.*/.*)|(https://player\.vimeo\.com/video/.*)";
            ApiEndpoint = "https://vimeo.com/api/oembed.json";
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
        }

    }
}