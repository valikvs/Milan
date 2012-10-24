namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;

    public partial class Recommendation : System.Web.UI.MasterPage
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
            if (this.Page.IsPostBack)
            {
                return;
            }
        }
    }
}