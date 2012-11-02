namespace VSS.Milan.Web.MasterPages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using umbraco.cms.businesslogic.media;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class Project : System.Web.UI.MasterPage
    {
        private Node previousProject;
        private Node nextProject;
        private Node projectsOverview;
        private Media imageFolder;
        private List<Media> images;

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

        protected Media ImageFolder
        {
            get
            {
                return this.imageFolder ?? (this.imageFolder = CurrentNode.PropertyAsMediaFolder(Fields.Project.ImageFolder));
            }
        }

        protected List<Media> Images
        {
            get
            {
                return this.images ?? (this.ImageFolder != null ? this.ImageFolder.Children.ToList() : new List<Media>());
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