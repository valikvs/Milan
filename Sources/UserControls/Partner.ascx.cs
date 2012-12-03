namespace VSS.Milan.Web.UserControls
{
    using System.Web.UI;
    using VSS.Milan.Web.Core.Utils;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;

    public partial class Partner : UserControl
    {
        public Node PartnerNode { get; set; }

        protected string Title { get; set; }

        protected string Address { get; set; }

        protected string Phone { get; set; }

        protected string Url { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            this.Title = this.PartnerNode.Property(Fields.Partner.Title);
            plhTitle.Visible = !string.IsNullOrEmpty(this.Title);

            this.Address = this.PartnerNode.Property(Fields.Partner.Address);
            plhAddress.Visible = !string.IsNullOrEmpty(this.Address);

            this.Phone = this.PartnerNode.Property(Fields.Partner.Phone);
            plhPhone.Visible = !string.IsNullOrEmpty(this.Phone);

            this.Url = this.PartnerNode.Property(Fields.Partner.Url);
            plhUrl.Visible = !string.IsNullOrEmpty(this.Url);

            base.Render(writer);
        }
    }
}