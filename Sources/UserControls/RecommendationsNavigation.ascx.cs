namespace VSS.Milan.Web.UserControls
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Utils;

    public partial class RecommendationsNavigation : System.Web.UI.UserControl
    {
        private Node recommendationsNode;
        private Node studioNode;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected Node RecommendationsNode
        {
            get
            {
                return this.recommendationsNode ?? (this.recommendationsNode = NodeHelper.RecommendationsNode);
            }
        }

        protected Node StudioNode
        {
            get
            {
                return this.studioNode ?? (this.studioNode = NodeHelper.StudioNode);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}