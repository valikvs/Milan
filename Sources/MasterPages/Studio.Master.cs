namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VSS.Milan.Web.Core.Utils;

    using umbraco.cms.businesslogic.media;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;

    public partial class Studio : System.Web.UI.MasterPage
    {
        private Media imageFolder;
        private List<Media> images;
        private Node recommendationsNode;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected Media ImageFolder
        {
            get
            {
                return this.imageFolder ?? (this.imageFolder = CurrentNode.PropertyAsMediaFolder(Fields.Project.ImageFolder));
            }
        }

        protected List<Media> Images
        {
            get
            {
                return this.images ?? (this.images = this.ImageFolder != null ? this.ImageFolder.Children.ToList() : new List<Media>());
            }
        }

        protected Node RecommendationsNode
        {
            get
            {
                return this.recommendationsNode ?? (this.recommendationsNode = NodeHelper.RecommendationsNode);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }
        }
    }
}