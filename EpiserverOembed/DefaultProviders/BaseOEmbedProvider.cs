using System.Text.RegularExpressions;

namespace EPiServer.Oembed.DefaultProviders
{
    
    /// <summary>
    /// Contains basic properties and method implementations for providers
    /// </summary>
    public abstract class BaseOEmbedProvider : IOEmbedProvider
    {
        
        public int? MaxWidth { get; set; }
        
        public int? MaxHeight { get; set; }
        
        /// <summary>
        /// Url schemes provider should interpret given as regex pattern
        /// </summary>
        /// <example>@"^(www\.website\.com)|(http://.*)"</example>
        protected string UrlSchemePattern { get; set; }
        
        /// <summary>
        /// API endpoint for provider
        /// </summary>
        /// <example>"http://www.website.com/"</example>
        protected string ApiEndpoint { get; set; }
        
        public virtual bool CanInterpretMediaUrl(string url)
        {
            return Regex.IsMatch(url, UrlSchemePattern);
        }
        
        public virtual string GetRequestUrl(string mediaUrl)
        {
            var url = ApiEndpoint + "?url=" + mediaUrl;
            if (MaxHeight != null)
            {
                url = url + "&maxheight=" + MaxHeight;
            }
            if (MaxWidth != null)
            {
                url = url + "&maxwidth=" + MaxWidth;
            }
            return url;
        }
    }
}