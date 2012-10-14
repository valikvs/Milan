namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class NewsArchive : System.Web.UI.UserControl
    {
        public string ArchiveUrl
        {
            get
            {
                return (NodeHelper.NewsOverviewNode != null) ? NodeHelper.NewsOverviewNode.Url : string.Empty;
            }
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
                this.archiveTitle.Text = newsNode.Property(Fields.NewsOverview.ArchiveText);
            }

            var archiveYears = NodeHelper.ArchiveNewsYears;
            if (archiveYears == null || archiveYears.Count <= 0)
            {
                this.Visible = false;
            }
        }
    }
}