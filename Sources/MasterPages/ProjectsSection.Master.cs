namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Utils;

    public partial class ProjectsSection : System.Web.UI.MasterPage
    {
        private List<Node> projects;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected List<Node> Projects
        {
            get
            {
                return this.projects ?? (this.projects = NodeHelper.GetSectionProjects(CurrentNode));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }
        }
    }
}