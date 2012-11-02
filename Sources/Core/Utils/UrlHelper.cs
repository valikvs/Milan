namespace VSS.Milan.Web.Core.Utils
{
    using System.Web;

    public static class UrlHelper
    {
        public static string ImageLink(string url, params string[] parameters)
        {
            url = "/ImageGen.ashx?Image=" + url;

            return AddQueryString(url, parameters);
        }

        public static string AddQueryString(string url, params string[] parameters)
        {
            var str = "&";
            var str2 = (url.IndexOf('?') >= 0) ? str : "?";
            for (var i = 0; i < (parameters.Length - 1); i += 2)
            {
                url = url + string.Format("{0}{1}={2}", str2, parameters[i], HttpUtility.UrlEncode(parameters[i + 1]));
                str2 = str;
            }

            return url;
        }
    }
}