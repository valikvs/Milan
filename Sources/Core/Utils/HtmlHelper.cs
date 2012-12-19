namespace VSS.Milan.Web.Core.Utils
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using umbraco.cms.businesslogic.media;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.UserControls;

    public static class HtmlHelper
    {
        public static string RecomendationImage(Node node, string fieldName)
        {
            var mediaUrl = node.PropertyAsMediaUrl(fieldName);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 530) };

            return RenderControl(image);
        }

        public static string NewsImage(Node node, string fieldName)
        {
            var mediaUrl = node.PropertyAsMediaUrl(fieldName);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 277) };

            var link = new HyperLink { CssClass = "fancybox", NavigateUrl = mediaUrl };
            link.Attributes.Add("rel", "gallery1");
            link.Controls.Add(image);

            return RenderControl(link);
        }

        public static string NewsOverviewImage(Node node)
        {
            var mediaUrl = node.PropertyAsMediaUrl(Fields.NewsItem.Image1) ?? node.PropertyAsMediaUrl(Fields.NewsItem.Image2);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var control = new HyperLink { NavigateUrl = node.Url };
            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 190) };
            control.Controls.Add(image);

            return RenderControl(control);
        }

        public static string StudioImage(Media media)
        {
            var mediaUrl = media.AsMediaUrl();
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 220) };

            return RenderControl(image);
        }

        public static string LeftNavigationItem(Node node)
        {
            if (node == null)
            {
                return string.Empty;
            }

            var item = new HtmlGenericControl("h2");
            var title = new Literal { Text = node.Property(Fields.BaseContent.NavigationTitle) };
            var url = new HyperLink { NavigateUrl = node.Url };
            url.Controls.Add(title);
            item.Controls.Add(url);

            return RenderControl(item);
        }

        public static string Recomendation(Node node)
        {
            var mediaUrl = node.PropertyAsMediaUrl(Fields.Recommendation.Image);
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 185) };

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

        public static string Partner(Control self, Node partner)
        {
            if (partner == null)
            {
                return string.Empty;
            }

            var control = (Partner)LoadControl("~/UserControls/Partner.ascx", self);
            control.PartnerNode = partner;

            return RenderControl(control);
        }

        public static string GalleryYear(Control self, Node year)
        {
            var control = (GalleryYear)LoadControl("~/UserControls/GalleryYear.ascx", self);
            control.YearNode = year;

            return RenderControl(control);
        }

        public static string GalleryImage(Media media)
        {
            var mediaUrl = media.AsMediaUrl();
            if (string.IsNullOrEmpty(mediaUrl))
            {
                return string.Empty;
            }

            var item = new HtmlGenericControl("li");
            var url = new HyperLink { NavigateUrl = mediaUrl };
            var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 113, 85) };
            url.Controls.Add(image);
            item.Controls.Add(url);

            return RenderControl(item);
        }

        public static string GalleryItemOverviewImage(Node item)
        {
            var imageFolder = item.PropertyAsMediaFolder(Fields.GalleryItem.ImageFolder);
            if (imageFolder != null)
            {
                var media = imageFolder.Children.FirstOrDefault();
                if (media != null)
                {
                    var mediaUrl = media.AsMediaUrl();
                    if (!string.IsNullOrEmpty(mediaUrl))
                    {
                        var image = new Image { ImageUrl = ThumbsHelper.ThumbUrl(mediaUrl, 188, 141) };

                        return RenderControl(image);
                    }
                }
            }

            return string.Empty;
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