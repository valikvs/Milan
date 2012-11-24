namespace VSS.Milan.Web.MasterPages
{
    using umbraco.NodeFactory;

    public partial class ContentPage : System.Web.UI.MasterPage
    {
        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }
    }
}