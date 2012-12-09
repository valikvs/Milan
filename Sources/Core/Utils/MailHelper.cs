namespace VSS.Milan.Web.Core.Utils
{
    using System;
    using System.Net.Mail;
    using umbraco.BusinessLogic;

    public static class MailHelper
    {
        public static bool SendMail(string fromMail, string toMail, string subject, string body, bool isHtml)
        {
            try
            {
                new SmtpClient().Send(new MailMessage(fromMail.Trim(), toMail.Trim())
                {
                    Subject = subject,
                    IsBodyHtml = isHtml || false,
                    Body = body
                });
            }
            catch (Exception ex)
            {
                Log.Add(LogTypes.Error, -1, string.Format("VSS.Milan.Web.Core.Utils.MailHelper.SendMail: Error sending mail. Exception: {0}", ex));

                return false;
            }

            return true;
        }

        public static string HtmlMessageLine(string field, string content)
        {
            return string.Format("<tr><td valign=\"top\" style=\"text-align: right;font-weight: bold;\">{0}</td><td valign=\"top\" style=\"text-align: left;\">{1}</td></tr>", field, content);
        }

        public static string HtmlTitleLine(string field)
        {
            return string.Format("<tr><td colspan=\"2\" valign=\"top\" style=\"text-align: center;font-weight: bold;padding-bottom: 10px;padding-top: 10px;\">{0}</td></tr>", field);
        }
    }
}