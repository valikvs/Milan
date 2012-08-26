namespace VSS.Milan.Web.MasterPages
{
    using System;
    using VSS.Milan.Web.Core;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class MainContent : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var homeUrl = Helper.CurrentLanguageNode.Url;
            if (!string.IsNullOrEmpty(homeUrl))
            {
                logoUrl.Attributes.Add("href", homeUrl);
            }

            this.footerLeftText.Text = Helper.CurrentLanguageNode.Property(Constants.LanguageFolder.FooterLeftText);
            this.footerRightText.Text = Helper.CurrentLanguageNode.Property(Constants.LanguageFolder.FooterRightText);
        }
    }
}