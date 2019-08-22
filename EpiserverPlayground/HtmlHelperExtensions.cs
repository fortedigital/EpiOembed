using System.Web;
using System.Web.Mvc;

namespace EpiserverPlayground
{
    public static class HtmlHelperExtensions
    {

        public static IHtmlString GetOembedHtml(this HtmlHelper helper)
        {
            return GetOembedHtml(helper, 
                @"http://www.flickr.com/services/oembed/?format=json&url=http%3A//www.flickr.com/photos/bees/2341623661/");
        }

        public static IHtmlString GetOembedHtml(this HtmlHelper helper, string uri)
        {
            var module = new OembedModule(uri);
            return helper.Raw(module.GetResponseHtml());
        }

    }
}