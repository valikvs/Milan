namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Utils;

    public partial class GallerySection : System.Web.UI.MasterPage
    {
        private List<Node> items;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected List<Node> Items
        {
            get
            {
                return this.items ?? (this.items = NodeHelper.GetGallerySectionItems(CurrentNode));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            galNav.GalleryNode = CurrentNode.Parent as Node;
        }
    }
}