﻿namespace VSS.Milan.Web.Core.Utils
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

        public static List<Node> NewsYears
        {
            get
            {
                return NewsOverviewNode != null
                    ? NewsOverviewNode.GetChildNodesByType(DocumentTypes.NewsYear).Where(y => y.Name.IsInteger()
                        && y.Children.Count > 0).ToList()
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
    }
}