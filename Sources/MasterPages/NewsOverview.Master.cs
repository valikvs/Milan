namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco.NodeFactory;
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
            var yearParam = this.Page.Request.QueryString["y"];
            var monthParam = this.Page.Request.QueryString["m"];
            var archiveParam = this.Page.Request.QueryString["archive"];

            if (!string.IsNullOrEmpty(yearParam)
                && !string.IsNullOrEmpty(monthParam))
            {
                int year;
                int month;
                int.TryParse(yearParam, out year);
                int.TryParse(monthParam, out month);

                return NodeHelper.GetNewsNodes(year, month);
            }
            
            if (!string.IsNullOrEmpty(archiveParam))
            {
                int year;
                int.TryParse(archiveParam, out year);

                return NodeHelper.GetArchiveNewsNodes(year);
            }

            return NodeHelper.NewsNodes.Take(4).ToList();
        }
    }
}