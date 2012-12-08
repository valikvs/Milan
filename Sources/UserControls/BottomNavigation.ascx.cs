namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Utils;

    public partial class BottomNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            navBottom.NavigationNodes = NodeHelper.BottomMenuNodes;
        }
    }
}
