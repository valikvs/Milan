<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsNavigation" %>
<%@ Register TagPrefix="uc" Src="~/UserControls/NewsArchive.ascx" TagName="NewsArchive" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<h2>
    <asp:Literal runat="server" ID="newsTitle"></asp:Literal></h2>
<% if (NodeHelper.NewsYears.Count > 0)
   { %>
<ul class="menu">
    <% foreach (var year in NodeHelper.NewsYears) { %>
    <% if (this.IsCurrentYear(year)) { %>
    <li class="expanded">
    <% } else { %>
    <li>
    <% } %>
        <a href="#"><%= year.Name%></a>
        <%= HtmlHelper.NewsYear(this, year, this.IsCurrentYear(year))%>
    </li>
    <% } %>
</ul>
<% } %>
<uc:NewsArchive runat="server"></uc:NewsArchive>
