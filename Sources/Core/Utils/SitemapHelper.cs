namespace VSS.Milan.Web.Core.Utils
{
    using System.Collections.Generic;
    using System.Web;
    using umbraco.interfaces;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Data;

    public static class SitemapHelper
    {
        public static List<SitemapPage> GetSitemap()
        {
            var root = new Node(-1);
            var pages = new List<SitemapPage>();
            var scheme = HttpContext.Current.Request.Url.Scheme;
            var host = HttpContext.Current.Request.Url.Host;
            var port = HttpContext.Current.Request.Url.Port;
            var prefix = port == 80 ? string.Format("{0}://{1}", scheme, host) : 
                string.Format("{0}://{1}:{2}", scheme, host, port);

            FillPages(root.ChildrenAsList, ref pages, prefix);
            
            return pages;
        }

        private static void FillPages(IEnumerable<INode> children, ref List<SitemapPage> pages, string host)
        {
            foreach (var child in children)
            {
                if (child.template > 0)
                {
                    pages.Add(NodeToSitemapPage(child, host));
                }

                if (child.ChildrenAsList.Count > 0)
                {
                    FillPages(child.ChildrenAsList, ref pages, host);
                }
            }
        }

        private static SitemapPage NodeToSitemapPage(INode node, string host)
        {
            var page = new SitemapPage
            {
                PageUrl = host + node.Url,
                LastUpdated = node.UpdateDate,
                Priority = 0.9M
            };

            return page;
        }
    }
}