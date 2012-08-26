namespace VSS.Milan.Web.UserControls
{
    using System;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class MediaPartners : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var partnersNodes = NodeHelper.MediaPartnersNodes;
            if (partnersNodes != null && partnersNodes.Count > 0)
            {
                this.partnersTitle.Text = NodeHelper.NewsOverviewNode.Property(Fields.NewsOverview.MediaPartnersTitle);
                this.rptPartners.DataSource = partnersNodes;
                this.rptPartners.DataBind();
            }
            else
            {
                this.Visible = false;
            }
        }
    }
}