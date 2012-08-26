namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core;
    using VSS.Milan.Web.Core.Extentions;

    public partial class Home : System.Web.UI.MasterPage
    {
        private static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            if (CurrentNode == null)
            {
                return;
            }

            var russianNode = CurrentNode.PropertyAsNode(Constants.Home.RussianNode);
            if (russianNode != null)
            {
                this.russianNodeUrl.NavigateUrl = russianNode.Url;
            }

            var englishNode = CurrentNode.PropertyAsNode(Constants.Home.EnglishNode);
            if (englishNode != null)
            {
                this.englishNodeUrl.NavigateUrl = englishNode.Url;
            }

            this.footerTopText.Text = CurrentNode.Property(Constants.Home.FooterTopText);
            this.footerBottomText.Text = CurrentNode.Property(Constants.Home.FooterBottomText);
        }
    }
}