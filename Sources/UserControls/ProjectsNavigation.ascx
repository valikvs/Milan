<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.ProjectsNavigation" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<h2>
    <%=ProjectsTitle%></h2>
<% if (this.Sections.Count > 0) { %>
<ul class="menu">
    <% foreach (var section in this.Sections) { %>
    <li class="hasSubMenu<%if (NodeHelper.IsCurrentPath(section)) {%> expanded<% } %>"><a href="#"><%=section.Property(Fields.ProjectsSection.Title)%></a>
    <ul>
        <% foreach (var year in NodeHelper.GetSectionYears(section))
           { %>
        <%= HtmlHelper.ProjectsYear(this, year)%>
        <% } %>    </ul>
    </li>
    <li><a href="<%=section.Url%>"><%=ViewAllText%></a></li>
    <% } %>
</ul>
<% } %>
