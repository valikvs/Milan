namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Globalization;
    using System.Linq;
    using umbraco;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Data;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsYear : System.Web.UI.UserControl
    {
        public Node DataSource
        {
            get;
            set;
        }

        public string NewsUrl
        {
            get
            {
                return (NodeHelper.NewsOverviewNode != null && this.DataSource != null) ? NodeHelper.NewsOverviewNode.Url + "?y=" + this.DataSource.Name : string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                return;
            }

            var dates = this.DataSource.GetChildNodesByType(DocumentTypes.NewsItem).Select(n => n.PropertyAsDateTime(Fields.NewsItem.Date)).ToList();
            var formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
            var months = dates.Select(n => n.Month)
                          .Distinct().OrderByDescending(n => n).Select(
                              n => new Month { Number = n, Title = formatInfo.GetMonthName(n).ToLower() }).ToList();

            if (months.Count > 0)
            {
                this.rptMonths.DataSource = months;
                this.rptMonths.DataBind();
            }
            else
            {
                this.rptMonths.Visible = false;
            }
        }
    }
}