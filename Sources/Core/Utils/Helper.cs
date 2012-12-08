namespace VSS.Milan.Web.Core.Utils
{
    using System.Collections.Generic;
    using System.Globalization;
    using umbraco;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Enums;
    using VSS.Milan.Web.Core.Extentions;

    public static class Helper
    {
        public static Node HomeNode
        {
            get
            {
                return GetNodeFromXpath("$currentPage/ancestor-or-self::*[@level=1]");
            }
        }

        public static Effect SiteEffect
        {
            get
            {
                var effect = HomeNode.Property(Fields.Home.Effects).ToLower();
                switch (effect)
                {
                    case Parameters.Home.Snow:
                        return Effect.Snow;
                    case Parameters.Home.Flowers:
                        return Effect.Flowers;
                }

                return Effect.None;
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