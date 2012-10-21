namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsItem : System.Web.UI.MasterPage
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