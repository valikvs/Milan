namespace VSS.Milan.Web.UserControls
{
    using System;
    using umbraco.NodeFactory;

    public partial class GoogleMap : System.Web.UI.UserControl
    {
        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}