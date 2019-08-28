namespace EPiServer.Oembed
{
    /// <summary>
    /// Interface for oembed providers
    /// </summary>
    public interface IOEmbedProvider
    {
        /// <summary>
        /// Optional MaxWidth request parameter
        /// </summary>
        int? MaxWidth { get; set; }
        
        /// <summary>
        /// Optional MaxHeight request parameter
        /// </summary>
        int? MaxHeight { get; set; }

        /// <summary>
        /// Checks if this provider can interpret given url
        /// </summary>
        /// <param name="url">Media Url</param>
        /// <returns>True if given url matches provider's url scheme pattern</returns>
        bool CanInterpretMediaUrl(string url);

        /// <summary>
        /// Constructs and returns request url
        /// </summary>
        /// <param name="mediaUrl">Url to the media to be embedded</param>
        /// <returns>Constructed request url with optional parameters if there are any</returns>
        string GetRequestUrl(string mediaUrl);

    }
}