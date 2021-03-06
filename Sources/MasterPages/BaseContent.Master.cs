﻿namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Enums;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class BaseContent : System.Web.UI.MasterPage
    {
        protected string GoogleAnalyticsId { get; set; }

        private static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var title = CurrentNode.Property(Fields.BaseContent.PageBrowserTitle);
            this.pageTitle.Text = !string.IsNullOrEmpty(title) ? title : CurrentNode.Name;

            var keywords = CurrentNode.Property(Fields.BaseContent.MetaKeywords);
            if (!string.IsNullOrEmpty(keywords))
            {
                mKeywords.Attributes.Add("content", keywords);
                mKeywords.Visible = true;
            }

            var description = CurrentNode.Property(Fields.BaseContent.MetaDescription);
            if (!string.IsNullOrEmpty(description))
            {
                mDescription.Attributes.Add("content", description);
                mDescription.Visible = true;
            }

            var homeNode = NodeHelper.HomeNode;
            if (homeNode != null)
            {
                this.GoogleAnalyticsId = homeNode.Property(Fields.Home.GoogleAnalyticsId);
                if (!string.IsNullOrEmpty(this.GoogleAnalyticsId))
                {
                    plhGoogleAnalytics.Visible = true;
                }
            }

            var effect = Helper.SiteEffect;
            switch (effect)
            {
                case Effect.Snow:
                    plhSnowEffect.Visible = true;
                    break;
                case Effect.Flowers:
                    plhFlowersEffect.Visible = true;
                    break;
            }
        }
    }
}
