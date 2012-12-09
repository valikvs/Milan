namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Collections.Generic;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class GalleryNavigation : System.Web.UI.UserControl
    {
        private List<Node> sections;
        private string viewAllText;

        public Node GalleryNode { get; set; }

        protected List<Node> Sections
        {
            get
            {
                return this.sections ?? (this.sections = NodeHelper.GetGallerySections(this.GalleryNode));
            }
        }

        protected string ViewAllText
        {
            get
            {
                return this.viewAllText ?? (this.viewAllText = this.GalleryNode != null ?
                                                this.GalleryNode.Property(Fields.Gallery.ViewAllText) : 
                                                string.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.GalleryNode == null)
            {
                this.Visible = false;
            }
        }
    }
}