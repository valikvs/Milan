namespace VSS.Milan.Web.UserControls
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using umbraco;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Data;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsYear : UserControl
    {
        public Node YearNode
        {
            get;
            set;
        }

        public bool IsCurrentYear
        {
            get;
            set;
        }

        public string NewsUrl
        {
            get
            {
                return (NodeHelper.NewsOverviewNode != null && this.YearNode != null) ? NodeHelper.NewsOverviewNode.Url + "?y=" + this.YearNode.Name : string.Empty;
            }
        }

        public List<Month> Months
        {
            get
            {
                if (this.YearNode == null)
                {
                    return null;
                }

                var dates = this.YearNode.GetChildNodesByType(DocumentTypes.NewsItem).Select(n => n.PropertyAsDateTime(Fields.NewsItem.Date)).ToList();
                var formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
                var months = dates.Select(n => n.Month)
                              .Distinct().OrderByDescending(n => n).Select(
                                  n => new Month { Number = n, Title = formatInfo.GetMonthName(n).ToLower() }).ToList();

                return months;
            }
        }
    }
}