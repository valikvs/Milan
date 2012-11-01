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

    public class NodeHelper
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

        public static List<INode> MainMenuNodes
        {
            get
            {
                return LanguageNode.ChildrenAsList.Where(c => c.PropertyAsBool(Fields.MainContent.ShowInNavigation)).ToList();
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

        public static Node ProjectsOverviewNode
        {
            get
            {
                return LanguageNode.GetChildNodesByType(DocumentTypes.ProjectsOverview).First();
            }
        }

        public static List<Node> ProjectsSections
        {
            get
            {
                return ProjectsOverviewNode != null ?
                    ProjectsOverviewNode.GetChildNodesByType(DocumentTypes.ProjectsSection).Where(y => y.Children.Count > 0).ToList()
                    : new List<Node>();
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

        public static List<Node> GetArchiveNewsNodes(int year)
        {
            return NewsNodes.Where(n => n.PropertyAsDateTime(Fields.NewsItem.Date).Year == year).ToList();
        }

        public static List<Node> GetSectionYears(Node node)
        {
            return node != null ? 
                node.GetChildNodesByType(DocumentTypes.ProjectsYear).Where(y => y.Children.Count > 0).ToList() : 
                new List<Node>();
        }

        public static List<Node> GetSectionProjects(Node node)
        {
            return node != null ?
                node.GetDescendantNodesByType(DocumentTypes.Project).ToList() :
                new List<Node>();
        }

        public static List<Node> GetYearProjects(Node node)
        {
            return node != null ?
                node.GetChildNodesByType(DocumentTypes.Project).ToList() :
                new List<Node>();
        }

        public static Node GetNextProject(Node node)
        {
            var section = node.Parent.Parent as Node;
            if (section == null)
            {
                return null;
            }

            var projects = GetSectionProjects(section);
            if (projects.Count < 2)
            {
                return null;
            }

            var index = projects.FindIndex(p => p.Id == node.Id);
            if (index >= 0 && projects.Count - 1 > index)
            {
                return projects[++index];
            }

            return null;
        }

        public static Node GetPreviousProject(Node node)
        {
            var section = node.Parent.Parent as Node;
            if (section == null)
            {
                return null;
            }

            var projects = GetSectionProjects(section);
            if (projects.Count < 2)
            {
                return null;
            }

            var index = projects.FindIndex(p => p.Id == node.Id);
            if (index > 0)
            {
                return projects[--index];
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