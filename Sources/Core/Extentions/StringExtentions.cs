namespace VSS.Milan.Web.Core.Extentions
{
    public static class StringExtentions
    {
        public static bool IsInteger(this string value)
        {
            int number;
            return int.TryParse(value, out number);
        }
    }
}