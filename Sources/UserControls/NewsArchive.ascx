<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsArchive.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsArchive" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>

<% if (NodeHelper.ArchiveNewsYears.Count > 0) { %>
<ul class="menu">
    <li class="hasSubMenu"><a href="#"><asp:Literal runat="server" ID="archiveTitle"></asp:Literal></a>
        <ul>
        <% foreach (var year in NodeHelper.ArchiveNewsYears) { %>
            <li><a href="<%=this.ArchiveUrl %>?archive=<%= year.Name%>">
                <%= year.Name%></a></li>
        <% } %>
        </ul>
    </li>
</ul>
<% } %>

