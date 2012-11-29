namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Text;
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

        protected string Result { get; set; }

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
            if (!this.Page.IsValid)
            {
                return;
            }

            var fromEmail = this.txtEmail.Text.Trim();
            var toEmail = NodeHelper.HomeNode.Property(Fields.Home.Email);
            var subject = CurrentNode.Property(Fields.Contact.MessageSubject);
            var body = this.GenerateHtmlMessageBody();

            var result = MailHelper.SendMail(fromEmail, toEmail, subject, body, true);

            this.Result = result ? CurrentNode.Property(Fields.Contact.SentMessage) : CurrentNode.Property(Fields.Contact.ErrorMessage);
            this.plhResult.Visible = true;
            this.txtEmail.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtSubject.Text = string.Empty;
            this.txtMessage.Text = string.Empty;
        }

        private string GenerateHtmlMessageBody()
        {
            var emailFromField = CurrentNode.Property(Fields.Contact.EmailText);
            var emailFromValue = txtEmail.Text.Trim();

            var nameField = CurrentNode.Property(Fields.Contact.NameText);
            var nameValue = txtName.Text.Trim();

            var phoneField = CurrentNode.Property(Fields.Contact.PhoneText);
            var phoneValue = txtPhone.Text.Trim();

            var subjectField = CurrentNode.Property(Fields.Contact.SubjectText);
            var subjectValue = txtSubject.Text.Trim();

            var messageField = CurrentNode.Property(Fields.Contact.MessageText);
            var messageValue = txtMessage.Text.Trim();

            var messageBody = new StringBuilder();

            if (!string.IsNullOrEmpty(emailFromValue))
            {
                messageBody.AppendLine(MailHelper.HtmlMessageLine(emailFromField, emailFromValue));
            }

            if (!string.IsNullOrEmpty(nameValue))
            {
                messageBody.AppendLine(MailHelper.HtmlMessageLine(nameField, nameValue));
            }

            if (!string.IsNullOrEmpty(phoneValue))
            {
                messageBody.AppendLine(MailHelper.HtmlMessageLine(phoneField, phoneValue));
            }

            if (!string.IsNullOrEmpty(subjectValue))
            {
                messageBody.AppendLine(MailHelper.HtmlMessageLine(subjectField, subjectValue));
            }

            if (!string.IsNullOrEmpty(messageField))
            {
                messageBody.AppendLine(MailHelper.HtmlMessageLine(messageField, messageValue));
            }

            return string.Format("<table border=\"1\" cellspacing=\"0\" cellpadding=\"5\" style=\"border: 1px solid #B2B2B2;\"><tbody>{0}</tbody></table>", messageBody);
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