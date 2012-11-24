namespace VSS.Milan.Web.UserControls
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;

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
    }
}