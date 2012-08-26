namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core;
    using VSS.Milan.Web.Core.Extentions;

    public partial class LanguageFolder : System.Web.UI.MasterPage
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

            var startNode = CurrentNode.PropertyAsNode(Constants.LanguageFolder.StartNode);
            if (startNode != null)
            {
                var url = startNode.Url;
                if (!string.IsNullOrEmpty(url))
                {
                    Response.Redirect(url, true);
                    return;
                }
            }

            Response.Redirect("/", true);
        }
    }
}