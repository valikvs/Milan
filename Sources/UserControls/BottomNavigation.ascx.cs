namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Utils;

    public partial class BottomNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var menuNodes = NodeHelper.BottomMenuNodes;
            if (menuNodes != null && menuNodes.Count > 0)
            {
                rptNavigation.DataSource = menuNodes;
                rptNavigation.DataBind();
            }
            else
            {
                rptNavigation.Visible = false;
            }
        }
    }
}