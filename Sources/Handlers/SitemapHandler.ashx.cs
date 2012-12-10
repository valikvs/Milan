namespace VSS.Milan.Web.Handlers
{
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Xml;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Utils;

    public class SitemapHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
             context.Response.ContentType = "text/xml";
             context.Response.Write(this.GenerateSiteMap());
             context.Response.End();
        }

        protected string GenerateSiteMap()
        {
            var xmlFile = new StringBuilder();
            xmlFile.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            xmlFile.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\"");
            xmlFile.AppendLine("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
            xmlFile.AppendLine("xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9");
            xmlFile.AppendLine("http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\">");

            var pages = SitemapHelper.GetSitemap();

            foreach (var page in pages)
            {
                xmlFile.AppendLine("<url>");
                xmlFile.Append("<loc>");
                xmlFile.Append(page.PageUrl);
                xmlFile.AppendLine("</loc>");
                if (page.LastUpdated.ToString("yyyy-MM-dd") != "0001-00-01")
                {
                    xmlFile.AppendLine("<lastmod>" + page.LastUpdated.ToString(DateFormats.Iso) + "</lastmod>");
                }

                xmlFile.AppendLine("<changefreq>daily</changefreq>");
                xmlFile.AppendLine("<priority>" + page.Priority + "</priority>");
                xmlFile.AppendLine("</url>");
            }

            xmlFile.AppendLine("</urlset>");
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.WriteRaw(xmlFile.ToString());

                    return stringWriter.ToString();
                }
            }
        }
    }
}