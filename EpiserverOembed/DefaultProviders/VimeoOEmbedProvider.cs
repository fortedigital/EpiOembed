namespace EPiServer.Oembed.DefaultProviders
{
    public class VimeoOEmbedProvider : BaseOEmbedProvider
    {
        public VimeoOEmbedProvider(int? maxWidth = null, int? maxHeight = null)
            : base(maxWidth: maxWidth, maxHeight: maxHeight)
        {
            UrlSchemePattern = @"^(https://vimeo\.com/.*)|(https://vimeo\.com/album/.*/video/.*)|" +
                               @"(https://vimeo\.com/channels/.*/.*)|(https://vimeo\.com/groups/.*/videos/.*)|" +
                               @"(https://vimeo\.com/ondemand/.*/.*)|(https://player\.vimeo\.com/video/.*)";
        }

        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://vimeo.com/api/oembed.json?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return url;
        }

    }
}