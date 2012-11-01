<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectsYear.ascx.cs" Inherits="VSS.Milan.Web.UserControls.ProjectsYear" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>

<li class="hasSubMenu<%if (NodeHelper.IsCurrentPath(this.YearNode)) {%> expanded<% } %>"><a href="#"><%=this.YearNode.Name %></a>
    <ul>
        <% foreach (var project in NodeHelper.GetYearProjects(this.YearNode)) { %>
            <li<%if (NodeHelper.IsCurrentNode(project)) {%> class="cur"<% } %>><a href="<%=project.Url%>"><%=project.Property(Fields.BaseContent.NavigationTitle)%></a></li>
        <% } %>
    </ul>
</li>