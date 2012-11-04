namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Web.UI.WebControls;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class ContactForm : System.Web.UI.UserControl
    {
        public ContactForm()
        {
            this.IsEmailValid = true;
            this.IsNameValid = true;
            this.IsMessageValid = true;
        }

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected bool IsEmailValid { get; set; }

        protected bool IsNameValid { get; set; }

        protected bool IsMessageValid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSend.Text = CurrentNode.Property(Fields.Contact.SendText);
        }

        protected void CvInputCharsNumberValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Trim().Length >= 2;
            this.HiglightField(((BaseValidator)source).ControlToValidate, args.IsValid);
        }

        protected void CvInputRequiredValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value.Trim().Length > 0;
            this.HiglightField(((BaseValidator)source).ControlToValidate, args.IsValid);
        }

        protected void CvEmailValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = FormsHelper.IsEmailValid(args.Value);
            this.HiglightField(((BaseValidator)source).ControlToValidate, args.IsValid);
        }

        protected void BtnSendClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {

            }
        }

        private void HiglightField(string field, bool isValid)
        {
            switch (field)
            {
                case "txtEmail":
                    this.IsEmailValid = isValid;
                    break;
                case "txtName":
                    this.IsNameValid = isValid;
                    break;
                case "txtMessage":
                    this.IsMessageValid = isValid;
                    break;
            }
        }
    }
}