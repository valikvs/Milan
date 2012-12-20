namespace VSS.Milan.Web.UserControls
{
    using umbraco.NodeFactory;

    public partial class GalleryYear : System.Web.UI.UserControl
    {
        public Node YearNode { get; set; }

        protected Node SectionNode
        {
            get
            {
                return YearNode.Parent as Node;
            }
        }
    }
}