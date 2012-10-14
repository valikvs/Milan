namespace VSS.Milan.Web.UserControls
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsNavigation : System.Web.UI.UserControl
    {
        protected bool IsCurrentYear(Node year)
        {
            if (year != null)
            {
                var yearParam = this.Page.Request.QueryString[Parameters.News.Year];
                if (yearParam != null
                    && !string.IsNullOrEmpty(yearParam)
                    && string.Equals(yearParam, year.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

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
        }
    }
}