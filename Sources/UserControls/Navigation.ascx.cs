namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Collections.Generic;
    using umbraco.interfaces;

    public partial class Navigation : System.Web.UI.UserControl
    {
        public List<INode> NavigationNodes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.NavigationNodes != null && this.NavigationNodes.Count > 0)
            {
                rptNavigation.DataSource = this.NavigationNodes;
                rptNavigation.DataBind();
            }
            else
            {
                rptNavigation.Visible = false;
            }
        }
    }
}
