<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsNavigation" %>
<%@ Register TagPrefix="uc" Src="~/UserControls/NewsArchive.ascx" TagName="NewsArchive" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%=HtmlHelper.LeftNavigationItem(NodeHelper.NewsOverviewNode)%>
<% if (NodeHelper.NewsYears.Count > 0)
   { %>
<ul class="menu">
    <% foreach (var year in NodeHelper.NewsYears) { %>
    <% if (this.IsCurrentYear(year)) { %>
    <li class="hasSubMenu cur expanded">
    <% } else { %>
    <li class="hasSubMenu">
    <% } %>
        <a href="#"><%= year.Name%></a>
        <%= HtmlHelper.NewsYear(this, year, this.IsCurrentYear(year))%>
    </li>
    <% } %>
</ul>
<% } %>
<uc:NewsArchive runat="server"></uc:NewsArchive>
