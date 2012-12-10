namespace VSS.Milan.Web.Core.Data
{
    using System;

    public class SitemapPage
    {
        public string PageUrl { get; set; }

        public DateTime LastUpdated { get; set; }

        public decimal Priority { get; set; }

        public string UpdateFrequency { get; set; }
    }
}