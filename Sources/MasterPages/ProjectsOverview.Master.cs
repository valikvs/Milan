namespace VSS.Milan.Web.MasterPages
{
    using System;

    public partial class ProjectsOverview : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }
        }
    }
}