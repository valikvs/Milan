namespace VSS.Milan.Web.Core.Utils
{
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.UserControls;

    public static class HtmlHelper
    {
        public static string NewsYear(Control self, Node year, bool current)
        {
            var control = (NewsYear)LoadControl("~/UserControls/NewsYear.ascx", self);
            control.YearNode = year;
            control.IsCurrentYear = current;

            return RenderControl(control);
        }

        private static object LoadControl(string path, Control self)
        {
            Page page;

            if (self != null && self.Page != null)
            {
                page = self.Page;
            }
            else
            {
                page = new Page();
            }

            return page.LoadControl(path);
        }

        private static string RenderControl(Control ctrl)
        {
            var sb = new StringBuilder();
            var tw = new StringWriter(sb);
            var hw = new HtmlTextWriter(tw);

            ctrl.RenderControl(hw);
            return sb.ToString();
        }
    }
}