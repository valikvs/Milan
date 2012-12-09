namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;

    using VSS.Milan.Web.Core.Utils;

    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;

    public partial class Gallery : System.Web.UI.MasterPage
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
                return this.items ?? (this.items = NodeHelper.GetGalleryAllItems(CurrentNode));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            galNav.GalleryNode = CurrentNode;

            var startNode = CurrentNode.PropertyAsNode(Fields.Gallery.StartItem);
            if (startNode != null && startNode.Id != CurrentNode.Id)
            {
                var url = startNode.Url;
                if (!string.IsNullOrEmpty(url))
                {
                    Response.Redirect(url, true);
                }
            }
        }
    }
}