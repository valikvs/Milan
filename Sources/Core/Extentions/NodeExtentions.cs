namespace VSS.Milan.Web.Core.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using umbraco.cms.businesslogic.media;
    using umbraco.interfaces;
    using umbraco.NodeFactory;

    public static class NodeExtensions
    {
        public static bool HasValue(this INode node, string propertyName)
        {
            if (node.GetProperty(propertyName) == null)
            {
                return false;
            }

            return !string.IsNullOrEmpty(node.GetProperty(propertyName).Value);
        }

        public static string Property(this INode node, string propertyName)
        {
            return !HasValue(node, propertyName) ? string.Empty : node.GetProperty(propertyName).Value;
        }

        public static int PropertyAsInt(this INode node, string propertyName)
        {
            var propValue = 0;
            if (!HasValue(node, propertyName))
            {
                return propValue;
            }

            int.TryParse(node.GetProperty(propertyName).Value, out propValue);

            return propValue;
        }

        public static bool PropertyAsBool(this INode node, string propertyName)
        {
            if (!HasValue(node, propertyName))
            {
                return false;
            }

            var intVlaue = PropertyAsInt(node, propertyName);

            return intVlaue > 0;
        }

        public static INode PropertyAsNode(this INode node, string propertyName)
        {
            int propValue;
            if (!HasValue(node, propertyName))
            {
                return null;
            }

            return !int.TryParse(node.GetProperty(propertyName).Value, out propValue) ? null : new Node(propValue);
        }

        public static Media PropertyAsMedia(this INode node, string propertyName)
        {
            int propValue;
            if (!HasValue(node, propertyName))
            {
                return null;
            }

            return !int.TryParse(node.GetProperty(propertyName).Value, out propValue) ? null : new Media(propValue);
        }

        public static DateTime PropertyAsDateTime(this INode node, string propertyName)
        {
            var propValue = DateTime.MinValue;
            if (!HasValue(node, propertyName))
            {
                return propValue;
            }

            DateTime.TryParse(node.GetProperty(propertyName).Value, out propValue);

            return propValue;
        }

        public static List<INode> MultiNodeProperty(this INode node, string propertyName)
        {
            var propValue = new List<INode>();
            var propertyData = node.GetRecursiveProperty(propertyName);
            if (!string.IsNullOrEmpty(propertyData))
            {
                var xml = XDocument.Parse(propertyData);
                propValue = xml.Descendants("nodeId").Select(x => new Node(int.Parse(x.Value)) as INode).ToList();
            }

            return propValue;
        }

        public static List<Media> MultiMediaProperty(this INode node, string propertyName)
        {
            var propValue = new List<Media>();
            var propertyData = node.GetRecursiveProperty(propertyName);
            if (!string.IsNullOrEmpty(propertyData))
            {
                var xml = XDocument.Parse(propertyData);
                propValue = xml.Descendants("nodeId").Select(x => new Media(int.Parse(x.Value))).ToList();
            }

            return propValue;
        }

        public static string GetRecursiveProperty(this INode node, string propertyAlias)
        {
            if (node.GetProperty(propertyAlias) != null && !string.IsNullOrEmpty(node.GetProperty(propertyAlias).Value))
            {
                return node.GetProperty(propertyAlias).Value;
            }

            return node.Parent != null ? GetRecursiveProperty(new Node(node.Parent.Id), propertyAlias) : string.Empty;
        }

        public static INode GetChildNodeByNameIgnoreCase(this INode parentNode, string nodeName)
        {
            return parentNode.ChildrenAsList.FirstOrDefault(node => node.Name.Equals(nodeName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}