namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco.cms.businesslogic.media;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class GalleryItem : System.Web.UI.MasterPage
    {
        private Node previousItem;
        private Node nextItem;
        private Node gallery;
        private Media imageFolder;
        private List<Media> images;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected Node PreviousItem
        {
            get
            {
                return this.previousItem ?? (this.previousItem = NodeHelper.GetGalleryItemPrevious(CurrentNode));
            }
        }

        protected Node NextItem
        {
            get
            {
                return this.nextItem ?? (this.nextItem = NodeHelper.GetGalleryItemNext(CurrentNode));
            }
        }

        protected Node Gallery
        {
            get
            {
                return this.gallery ?? (this.gallery = CurrentNode.Parent.Parent.Parent as Node);
            }
        }

        protected Media ImageFolder
        {
            get
            {
                return this.imageFolder ?? (this.imageFolder = CurrentNode.PropertyAsMediaFolder(Fields.GalleryItem.ImageFolder));
            }
        }

        protected List<Media> Images
        {
            get
            {
                return this.images ?? (this.images = this.ImageFolder != null ? this.ImageFolder.Children.ToList() : new List<Media>());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            galNav.GalleryNode = this.Gallery;
        }
    }
}