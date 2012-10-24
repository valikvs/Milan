namespace VSS.Milan.Web.MasterPages
{
    using System;

    using VSS.Milan.Web.Core.Utils;

    public partial class Recommendations : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var recommendations = NodeHelper.AllRecommendations;
            if (recommendations != null && recommendations.Count > 0)
            {
                this.rptRecommendations.DataSource = recommendations;
                this.rptRecommendations.DataBind();
            }
            else
            {
                this.rptRecommendations.Visible = false;
            }
        }
    }
}