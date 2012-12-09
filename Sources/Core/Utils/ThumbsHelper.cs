namespace VSS.Milan.Web.Core.Utils
{
    public static class ThumbsHelper
    {
        public static string ThumbUrl(string url, int width, int height)
        {
            url = string.Format("/thumbs/{0}x{1}{2}", width, height, url);

            return url;
        }

        public static string ThumbUrl(string url, int width)
        {
            url = string.Format("/thumbs/{0}{1}", width, url);

            return url;
        }
    }
}