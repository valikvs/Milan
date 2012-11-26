namespace VSS.Milan.Web.Core.Umbraco
{
    using System;
    using System.Web;
    using System.Xml;
    using umbraco.cms.businesslogic.web;
    using umbraco.interfaces;

    public class Custom404 : INotFoundHandler
    {
        private int redirectId = -1;

        public bool CacheUrl
        {
            get { return false; }
        }

        public int redirectID
        {
            get
            {
                return this.redirectId;
            }
        }

        public bool Execute(string url)
        {
            var error404Node = umbraco.UmbracoSettings.GetKeyAsNode("/settings/content/errors/error404");

            XmlNode cultureErrorNode;
            try
            {
                var domainName = this.FindDomein(HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + "/" + url);
                if (Domain.Exists(domainName))
                {
                    var d = Domain.GetDomain(domainName);
                    cultureErrorNode = error404Node.SelectSingleNode(string.Format("errorPage [@culture = '{0}']", d.Language.CultureAlias));
                    if (cultureErrorNode != null && cultureErrorNode.FirstChild != null)
                    {
                        this.redirectId = int.Parse(cultureErrorNode.FirstChild.Value);
                    }
                    else
                    {
                        cultureErrorNode = error404Node.SelectSingleNode("errorPage [@culture = 'default']");
                        if (cultureErrorNode != null && cultureErrorNode.FirstChild != null)
                        {
                            this.redirectId = int.Parse(cultureErrorNode.FirstChild.Value);
                        }
                    }
                }
                else
                {
                    cultureErrorNode = error404Node.SelectSingleNode("errorPage [@culture = 'default']");
                    if (cultureErrorNode != null && cultureErrorNode.FirstChild != null)
                    {
                        this.redirectId = int.Parse(cultureErrorNode.FirstChild.Value);
                    }
                }
            }
            catch
            {
                cultureErrorNode = error404Node.SelectSingleNode("errorPage [@culture = 'default']");
                if (cultureErrorNode != null && cultureErrorNode.FirstChild != null)
                {
                    this.redirectId = int.Parse(cultureErrorNode.FirstChild.Value);
                }
            }

            return true;
        }

        private string FindDomein(string url)
        {
            if (!url.Contains("/"))
            {
                return url;
            }

            if (Domain.Exists(url))
            {
                return url;
            }

            url = url.Substring(0, url.LastIndexOf("/", StringComparison.Ordinal));
            return this.FindDomein(url);
        }
    }
}