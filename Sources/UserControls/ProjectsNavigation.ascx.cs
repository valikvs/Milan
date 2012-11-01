namespace VSS.Milan.Web.UserControls
{
    using System;
    using System.Collections.Generic;

    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;
    using VSS.Milan.Web.Core.Utils;

    public partial class ProjectsNavigation : System.Web.UI.UserControl
    {
        private Node projectsOverview;
        private List<Node> sections;
        private string viewAllText;
        private string projectsTitle;

        protected Node ProjectsOverview
        {
            get
            {
                return this.projectsOverview ?? (this.projectsOverview = NodeHelper.ProjectsOverviewNode);
            }
        }

        protected List<Node> Sections
        {
            get
            {
                return this.sections ?? (this.sections = NodeHelper.ProjectsSections);
            }
        }

        protected string ViewAllText
        {
            get
            {
                return this.viewAllText ?? (this.viewAllText = this.ProjectsOverview != null ?
                                                this.ProjectsOverview.Property(Fields.ProjectsOverview.ViewAllText) : 
                                                string.Empty);
            }
        }

        protected string ProjectsTitle
        {
            get
            {
                return this.projectsTitle ?? (this.projectsTitle = this.ProjectsOverview != null ?
                                                this.ProjectsOverview.Property(Fields.BaseContent.NavigationTitle) :
                                                string.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            if (this.ProjectsOverview == null)
            {
                this.Visible = false;
            }
        }
    }
}