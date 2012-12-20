namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Utils;

    public partial class GallerySection : System.Web.UI.MasterPage
    {
        private List<Node> items;
        private Node yearNode;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected Node YearNode
        {
            get
            {
                if (this.yearNode == null)
                {
                    var yearParam = Page.Request.QueryString[Parameters.Gallery.Year];

                    this.yearNode = !string.IsNullOrEmpty(yearParam)
                               ? NodeHelper.GetGallerySectionYearNode(CurrentNode, yearParam)
                               : null;
                }

                return this.yearNode;
            }
        }

        protected string YearText
        {
            get
            {
                return this.YearNode != null ? string.Format("({0})", this.YearNode.Name) : string.Empty;
            }
        }

        protected List<Node> Items
        {
            get
            {
                return this.items ?? (this.items = this.GetItems());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            galNav.GalleryNode = CurrentNode.Parent as Node;
        }

        private List<Node> GetItems()
        {
            return this.YearNode != null ? 
                NodeHelper.GetGallerySectionYearItems(this.YearNode) : 
                NodeHelper.GetGallerySectionItems(CurrentNode);
        }
    }
}