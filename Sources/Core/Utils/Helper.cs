namespace VSS.Milan.Web.Core.Utils
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using umbraco;
    using umbraco.cms.businesslogic.language;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Extentions;

    using umbraco.interfaces;

    public static class Helper
    {
        public static Node HomeNode
        {
            get
            {
                return GetNodeFromXpath("$currentPage/ancestor-or-self::*[@level=1]");
            }
        }

        public static Node CurrentLanguageNode
        {
            get
            {
                return HomeNode.GetChildNodeByNameIgnoreCase(LanguageName) as Node;
            }
        }

        public static List<INode> MainNavigationNodes
        {
            get
            {
                return CurrentLanguageNode.ChildrenAsList.Where(c => c.PropertyAsBool(Constants.MainContent.ShowInNavigation)).ToList();
            }
        } 

        private static string LanguageName
        {
            get
            {
                var lang = Language.GetByCultureCode(Thread.CurrentThread.CurrentUICulture.Name);
                return lang.CultureAlias.Substring(0, 2);
            }
        }

        public static Node GetNodeFromXpath(string xpath)
        {
            if (string.IsNullOrEmpty(xpath))
            {
                return null;
            }

            var list = new List<Node>();
            if (IsCurrentNodeAvailable())
            {
                xpath = xpath.Replace("$currentPage", "descendant::*[@id='" + Node.GetCurrent().Id.ToString(CultureInfo.InvariantCulture) + "']");
            }

            var iterator = content.Instance.XmlContent.CreateNavigator().Select(xpath);

            if (iterator.Count > 0)
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current == null)
                    {
                        continue;
                    }

                    var evaluate = iterator.Current.Evaluate("string(@id)");
                    if (evaluate == null)
                    {
                        continue;
                    }

                    var item = GetNode(evaluate.ToString());
                    if (item != null)
                    {
                        list.Add(item);
                    }
                }

                return list[0];
            }

            return null;
        }

        public static Node GetNode(string nodeId)
        {
            int num;
            Node node = null;
            if (int.TryParse(nodeId, out num))
            {
                node = new Node(num);
            }

            return node;
        }

        internal static bool IsCurrentNodeAvailable()
        {
            var flag = false;
            try
            {
                if (Node.GetCurrent() != null)
                {
                    flag = true;
                }
            }
            catch
            {
                flag = false;
            }

            return flag;
        }
    }
}