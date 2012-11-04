namespace VSS.Milan.Web.Core.Utils
{
    using System.Text.RegularExpressions;

    public static class FormsHelper
    {
        public const string EmailPattern = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsEmailValid(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email.Trim(), EmailPattern);
        }

        public static string RenderError(this bool value)
        {
            return !value ? "error" : string.Empty;
        }
    }
}