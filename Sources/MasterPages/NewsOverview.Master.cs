namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsOverview : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var news = this.GetNews();
            if (news != null && news.Count > 0)
            {
                this.rptNews.DataSource = news;
                this.rptNews.DataBind();
            }
            else
            {
                this.rptNews.Visible = false;
            }
        }

        private List<Node> GetNews()
        {
            var yearParam = this.Page.Request.QueryString[Parameters.News.Year];
            var monthParam = this.Page.Request.QueryString[Parameters.News.Month];
            var archiveParam = this.Page.Request.QueryString[Parameters.News.Archive];

            if (!string.IsNullOrEmpty(yearParam)
                && !string.IsNullOrEmpty(monthParam))
            {
                int year;
                int month;
                int.TryParse(yearParam, out year);
                int.TryParse(monthParam, out month);

                return NodeHelper.GetNewsNodes(year, month);
            }

            if (!string.IsNullOrEmpty(yearParam))
            {
                int year;
                int.TryParse(yearParam, out year);

                return NodeHelper.GetNewsNodesByYear(year);
            }
            
            if (!string.IsNullOrEmpty(archiveParam))
            {
                int year;
                int.TryParse(archiveParam, out year);

                return NodeHelper.GetNewsNodesByYear(year);
            }

            return NodeHelper.NewsNodes.Take(4).ToList();
        }
    }
}