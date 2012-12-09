<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryYear.ascx.cs" Inherits="VSS.Milan.Web.UserControls.GalleryYear" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>

<li class="hasSubMenu<%if (NodeHelper.IsCurrentPath(this.YearNode)) {%> expanded<% } %>"><a href="#"><%=this.YearNode.Name %></a>
    <ul>
        <% foreach (var item in NodeHelper.GetGalleryItems(this.YearNode)) { %>
            <li<%if (NodeHelper.IsCurrentNode(item)) {%> class="cur"<% } %>><a href="<%=item.Url%>"><%=item.Property(Fields.BaseContent.NavigationTitle)%></a></li>
        <% } %>
    </ul>
</li>