namespace VSS.Milan.Web.MasterPages
{
    using System;
    using umbraco.NodeFactory;
    using VSS.Milan.Web.Core.Constants;
    using VSS.Milan.Web.Core.Extentions;

    public partial class ProjectsOverview : System.Web.UI.MasterPage
    {
        protected static Node CurrentNode
        {
            get
            {
                return Node.GetCurrent();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var startNode = CurrentNode.PropertyAsNode(Fields.ProjectsOverview.StartProject);
            if (startNode != null && startNode.Id != CurrentNode.Id)
            {
                var url = startNode.Url;
                if (!string.IsNullOrEmpty(url))
                {
                    Response.Redirect(url, true);
                }
            }
        }
    }
}