namespace VSS.Milan.Web.MasterPages
{
    using System;
    using VSS.Milan.Web.Core.Constants;
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

            var homeUrl = NodeHelper.LanguageNode.Url;
            if (!string.IsNullOrEmpty(homeUrl))
            {
                logoUrl.Attributes.Add("href", homeUrl);
            }

            this.footerLeftText.Text = NodeHelper.LanguageNode.Property(Fields.LanguageFolder.FooterLeftText);
            this.footerRightText.Text = NodeHelper.LanguageNode.Property(Fields.LanguageFolder.FooterRightText);
        }
    }
}