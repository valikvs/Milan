namespace VSS.Milan.Web.UserControls
{
    using System;

    using VSS.Milan.Web.Core.Utils;

    public partial class MainNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var menuNodes = Helper.MainNavigationNodes;
            rptNavigation.DataSource = menuNodes;
            rptNavigation.DataBind();
        }
    }
}
