namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsNavigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var newsNode = NodeHelper.NewsOverviewNode;
            if (newsNode != null)
            {
                this.newsTitle.Text = newsNode.Property(Fields.BaseContent.NavigationTitle);
            }

            var newsYears = NodeHelper.NewsYears;
            if (newsYears != null && newsYears.Count > 0)
            {
                this.rptNewsNavigation.DataSource = newsYears;
                this.rptNewsNavigation.DataBind();
            }
            else
            {
                this.rptNewsNavigation.Visible = false;
            }
        }
    }
}