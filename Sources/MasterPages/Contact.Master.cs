namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;

    public partial class Contact : System.Web.UI.MasterPage
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