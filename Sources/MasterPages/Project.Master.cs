namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Utils;

    public partial class Project : System.Web.UI.MasterPage
    {
        private Node previousProject;
        private Node nextProject;
        private Node projectsOverview;

        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected Node PreviousProject
        {
            get
            {
                return this.previousProject ?? (this.previousProject = NodeHelper.GetPreviousProject(CurrentNode));
            }
        }

        protected Node NextProject
        {
            get
            {
                return this.nextProject ?? (this.nextProject = NodeHelper.GetNextProject(CurrentNode));
            }
        }

        protected Node ProjectsOverview
        {
            get
            {
                return this.projectsOverview ?? (this.projectsOverview = NodeHelper.ProjectsOverviewNode);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var index = NodeHelper.GetNextProject(CurrentNode);
        }
    }
}