namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Enums;
    using VSS.Milan.Web.Core.Utils;

    public partial class Home : System.Web.UI.MasterPage
    {
        private static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected string BodyClass
        {
            get
            {
                var bodyCss = "splash";

                var effect = Helper.SiteEffect;
                switch (effect)
                {
                    case Effects.Snow:
                        bodyCss += " snowMode";
                        break;
                    case Effects.Flowers:
                        bodyCss += " flowersMode";
                        break;
                }

                return bodyCss;
            }
        }

        protected string RussianUrl
        {
            get
            {
                var russianNode = CurrentNode.PropertyAsNode(Fields.Home.RussianNode);
                if (russianNode != null)
                {
                    return russianNode.Url;
                }

                return string.Empty;
            }
        }

        protected string EnglishUrl
        {
            get
            {
                var englishNode = CurrentNode.PropertyAsNode(Fields.Home.EnglishNode);
                if (englishNode != null)
                {
                    return englishNode.Url;
                }

                return string.Empty;
            }
        }

        protected string FooterTopText
        {
            get
            {
                return CurrentNode.Property(Fields.Home.FooterTopText);
            }
        }

        protected string FooterBottomText
        {
            get
            {
                return CurrentNode.Property(Fields.Home.FooterBottomText);
            }
        }
    }
}