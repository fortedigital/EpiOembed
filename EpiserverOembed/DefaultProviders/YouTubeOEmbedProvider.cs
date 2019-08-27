namespace EPiServer.Oembed.DefaultProviders
{
    public class YouTubeOEmbedProvider : BaseOEmbedProvider
    {
        public YouTubeOEmbedProvider(int? maxWidth = null, int? maxHeight = null)
            : base(maxWidth: maxWidth, maxHeight: maxHeight)
        {
            UrlSchemePattern = @"^(https://.*\.youtube\.com/watch.*)|(https://.*\.youtube\.com/v/.*)|(https://youtu\.be/.*)";
        }
        
        public override string GetRequestUrl(IOEmbedBlock block)
        {
            var url = "https://www.youtube.com/oembed?url=" + block.MediaUrl;
            url += base.GetRequestUrl(block);
            return  url;
        }

    }
}