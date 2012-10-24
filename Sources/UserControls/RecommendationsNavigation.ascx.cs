namespace VSS.Milan.Web.UserControls
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class RecommendationsNavigation : System.Web.UI.UserControl
    {
        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected bool IsCurrentNode(Node node)
        {
            if (node != null && CurrentNode != null)
            {
                if (node.Id == CurrentNode.Id)
                {
                    return true;
                }
            }

            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var recommendationsNode = NodeHelper.RecommendationsNode;
            if (recommendationsNode != null)
            {
                this.recommendationsTitle.Text = recommendationsNode.Property(Fields.BaseContent.NavigationTitle);
                this.viewAllText.Text = recommendationsNode.Property(Fields.Recommendations.ViewAllText);
            }
        }
    }
}