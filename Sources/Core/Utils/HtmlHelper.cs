namespace VSS.Milan.Web.Core.Utils
{
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.UserControls;

    public static class HtmlHelper
    {
        public static string Image(Node node, string fieldName)
        {
            var mediaUrl = node.PropertyAsMediaUrl(fieldName);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = mediaUrl };

            return RenderControl(image);
        }

        public static string NewsImage(Node node, string fieldName)
        {
            var mediaUrl = node.PropertyAsMediaUrl(fieldName);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = mediaUrl, Width = 277, Height = 199, AlternateText = "pic" };

            return RenderControl(image);
        }

        public static string NewsOverviewImage(Node node)
        {
            var mediaUrl = node.PropertyAsMediaUrl(Fields.NewsItem.Image1) ?? node.PropertyAsMediaUrl(Fields.NewsItem.Image2);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var control = new HyperLink { NavigateUrl = node.Url };
            var image = new Image
                { ImageUrl = mediaUrl, Width = 190, Height = 140 };
            control.Controls.Add(image);

            return RenderControl(control);
        }

        public static string Recomendation(Node node)
        {
            var mediaUrl = node.PropertyAsMediaUrl(Fields.Recommendation.Image);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = mediaUrl, Width = 185, Height = 251, AlternateText = "pic" };

            var link = new HyperLink { CssClass = "fancybox", NavigateUrl = mediaUrl };
            link.Attributes.Add("rel", "gallery1");
            link.Controls.Add(image);

            return RenderControl(link);
        }

        public static string NewsYear(Control self, Node year, bool current)
        {
            var control = (NewsYear)LoadControl("~/UserControls/NewsYear.ascx", self);
            control.YearNode = year;
            control.IsCurrentYear = current;

            return RenderControl(control);
        }

        public static string ProjectsYear(Control self, Node year)
        {
            var control = (ProjectsYear)LoadControl("~/UserControls/ProjectsYear.ascx", self);
            control.YearNode = year;

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