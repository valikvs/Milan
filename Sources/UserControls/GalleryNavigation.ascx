<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.GalleryNavigation" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%=HtmlHelper.LeftNavigationItem(GalleryNode)%>
<% if (this.Sections.Count > 0) { %>
    <% foreach (var section in this.Sections) { %>
    <ul class="menu">
        <li class="hasSubMenu<%if (NodeHelper.IsCurrentPath(section)) {%> expanded<% } %>"><a href="#"><%=section.Property(Fields.BaseContent.NavigationTitle)%></a>
        <ul>
            <% foreach (var year in NodeHelper.GetGalleryYears(section))
               { %>
            <%= HtmlHelper.GalleryYear(this, year)%>
            <% } %>
        </ul>
        </li>
        <li<%if (NodeHelper.IsCurrentNode(section)) {%> class="cur"<% } %>><a href="<%=section.Url%>"><%=ViewAllText%></a></li>
    </ul>
    <% } %>
<% } %>
