namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class HeaderButtons : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var russianNode = Helper.HomeNode.PropertyAsNode(Fields.Home.RussianNode);
            if (russianNode != null)
            {
                var css = "rus";
                if (NodeHelper.LanguageNode != null && russianNode.Id == NodeHelper.LanguageNode.Id)
                {
                    css += " cur";
                }
                else
                {
                    this.btnRussian.Attributes.Add("href", russianNode.Url);
                }

                this.btnRussian.Attributes.Add("class", css);
                this.btnRussian.Visible = true;
            }

            var englishNode = Helper.HomeNode.PropertyAsNode(Fields.Home.EnglishNode);
            if (englishNode != null)
            {
                var css = "eng";
                if (NodeHelper.LanguageNode != null && englishNode.Id == NodeHelper.LanguageNode.Id)
                {
                    css += " cur";
                }
                else
                {
                    this.btnEnglish.Attributes.Add("href", englishNode.Url);
                }
                
                this.btnEnglish.Attributes.Add("class", css);
                this.btnEnglish.Visible = true;
            }

            var facebook = NodeHelper.LanguageNode.Property(Fields.LanguageFolder.FacebookButtonUrl);
            if (!string.IsNullOrEmpty(facebook))
            {
                this.btnFacebook.Attributes.Add("href", facebook);
                this.btnFacebook.Visible = true;
            }

            var twitter = NodeHelper.LanguageNode.Property(Fields.LanguageFolder.TwitterButtonUrl);
            if (!string.IsNullOrEmpty(twitter))
            {
                this.btnTwitter.Attributes.Add("href", twitter);
                this.btnTwitter.Visible = true;
            }
        }
    }
}