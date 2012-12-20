namespace VSS.Milan.Web.Core.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using umbraco;
    using umbraco.cms.businesslogic.language;
    using umbraco.interfaces;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;

    public static class NodeHelper
    {
        public static Node HomeNode
        {
            get
            {
                return Helper.HomeNode;
            }
        }

        public static Node LanguageNode
        {
            get
            {
                var lang = Language.GetByCultureCode(Thread.CurrentThread.CurrentUICulture.Name);
                var langCode = lang.CultureAlias.Substring(0, 2);
                return HomeNode.GetChildNodeByNameIgnoreCase(langCode) as Node;
            }
        }

        public static List<INode> TopMenuNodes
        {
            get
            {
                return LanguageNode.ChildrenAsList.Where(c => c.PropertyAsBool(Fields.MainContent.ShowInTopNavigation)).ToList();
            }
        }

        public static List<INode> BottomMenuNodes
        {
            get
            {
                return LanguageNode.ChildrenAsList.Where(c => c.PropertyAsBool(Fields.MainContent.ShowInBottomNavigation)).ToList();
            }
        }

        public static Node NewsOverviewNode
        {
            get
            {
                return LanguageNode.GetChildNodesByType(DocumentTypes.NewsOverview).First();
            }
        }

        public static List<Node> AllNewsYears
        {
            get
            {
                return NewsOverviewNode != null
                    ? NewsOverviewNode.GetChildNodesByType(DocumentTypes.NewsYear).Where(y => y.Name.IsInteger()
                        && y.Children.Count > 0).ToList()
                    : null;
            }
        }

        public static List<Node> NewsYears
        {
            get
            {
                return AllNewsYears != null
                    ? AllNewsYears.Where(y => !y.PropertyAsBool(Fields.NewsYear.Archive)).ToList()
                    : new List<Node>();
            }
        }

        public static List<Node> ArchiveNewsYears
        {
            get
            {
                return AllNewsYears != null
                    ? AllNewsYears.Where(y => y.PropertyAsBool(Fields.NewsYear.Archive)).ToList()
                    : null;
            }
        }

        public static List<Node> NewsNodes
        {
            get
            {
                return NewsOverviewNode != null
                    ? NewsOverviewNode.GetDescendantNodesByType(DocumentTypes.NewsItem).OrderByDescending(x => x.PropertyAsDateTime(Fields.NewsItem.Date)).ToList()
                    : null;
            }
        }

        public static Node StudioNode
        {
            get
            {
                return LanguageNode.GetChildNodesByType(DocumentTypes.Studio).First();
            }
        }

        public static Node RecommendationsNode
        {
            get
            {
                return LanguageNode.GetChildNodesByType(DocumentTypes.Recommendations).First();
            }
        }

        public static List<Node> AllRecommendations
        {
            get
            {
                return RecommendationsNode != null
                    ? RecommendationsNode.GetChildNodesByType(DocumentTypes.Recommendation).ToList()
                    : null;
            }
        }

        public static Node MediaPartnersNode
        {
            get
            {
                return NewsOverviewNode.PropertyAsNode(Fields.NewsOverview.MediaPartnersNode) as Node;
            }
        }

        public static List<Node> MediaPartnersNodes
        {
            get
            {
                return MediaPartnersNode != null ? MediaPartnersNode.GetChildNodesByType(DocumentTypes.MediaPartner).ToList() : null;
            }
        }

        public static List<Node> GetNewsNodes(int year, int month)
        {
            if (year < 0 || month < 1 || month > 12)
            {
                return null;
            }

            return NewsNodes.Where(n => n.PropertyAsDateTime(Fields.NewsItem.Date).Year == year && n.PropertyAsDateTime(Fields.NewsItem.Date).Month == month).ToList();
        }

        public static List<Node> GetNewsNodesByYear(int year)
        {
            return NewsNodes.Where(n => n.PropertyAsDateTime(Fields.NewsItem.Date).Year == year).ToList();
        }

        public static List<Node> GetPartnersPages(Node node)
        {
            return node != null
                    ? node.GetChildNodesByType(DocumentTypes.PartnersPage).ToList()
                    : null;
        }

        public static List<Node> GetPartnersPageColumns(Node node)
        {
            return node != null
                    ? node.GetChildNodesByType(DocumentTypes.PartnersColumn).ToList()
                    : null;
        }

        public static List<Node> GetPartnersColumnGroups(Node node)
        {
            return node != null
                    ? node.GetChildNodesByType(DocumentTypes.PartnersGroup).ToList()
                    : null;
        }

        public static List<Node> GetPartnersByGroup(Node node)
        {
            return node != null
                    ? node.GetChildNodesByType(DocumentTypes.Partner).ToList()
                    : null;
        }

        public static List<Node> GetGallerySections(Node gallery)
        {
            return gallery != null ?
                gallery.GetChildNodesByType(DocumentTypes.GallerySection).Where(y => y.Children.Count > 0).ToList() :
                new List<Node>();
        }

        public static List<Node> GetGalleryYears(Node section)
        {
            return section != null ?
                section.GetChildNodesByType(DocumentTypes.GalleryYear).Where(y => y.Children.Count > 0).ToList() :
                new List<Node>();
        }

        public static List<Node> GetGalleryItems(Node year)
        {
            return year != null ?
                year.GetChildNodesByType(DocumentTypes.GalleryItem).ToList() :
                new List<Node>();
        }

        public static List<Node> GetGalleryAllItems(Node gallery)
        {
            return gallery != null ?
                gallery.GetDescendantNodesByType(DocumentTypes.GalleryItem).ToList() :
                new List<Node>();
        }

        public static List<Node> GetGallerySectionItems(Node section)
        {
            return section != null ?
                section.GetDescendantNodesByType(DocumentTypes.GalleryItem).ToList() :
                new List<Node>();
        }

        public static List<Node> GetGallerySectionYearItems(Node year)
        {
            return year != null ?
                year.GetChildNodesByType(DocumentTypes.GalleryItem).ToList() :
                new List<Node>();
        }

        public static Node GetGalleryItemNext(Node item)
        {
            var section = item.Parent.Parent as Node;
            if (section == null)
            {
                return null;
            }

            var items = GetGallerySectionItems(section);
            if (items.Count < 2)
            {
                return null;
            }

            var index = items.FindIndex(p => p.Id == item.Id);
            if (index >= 0 && items.Count - 1 > index)
            {
                return items[++index];
            }

            return null;
        }

        public static Node GetGalleryItemPrevious(Node item)
        {
            var section = item.Parent.Parent as Node;
            if (section == null)
            {
                return null;
            }

            var items = GetGallerySectionItems(section);
            if (items.Count < 2)
            {
                return null;
            }

            var index = items.FindIndex(p => p.Id == item.Id);
            if (index > 0)
            {
                return items[--index];
            }

            return null;
        }

        public static bool IsCurrentNode(Node node)
        {
            var currentNode = Node.GetCurrent();

            return node != null
                   && currentNode != null
                   && node.Id == currentNode.Id;
        }

        public static bool IsCurrentPath(Node node)
        {
            var currentNode = Node.GetCurrent();
            
            return node != null
                   && currentNode != null
                   && currentNode.GetAncestorOrSelfNodes().Count(n => n.Id == node.Id) == 1;
        }
    }
}