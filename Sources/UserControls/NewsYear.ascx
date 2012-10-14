<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsYear.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsYear" %>

<% if (Months.Count > 0) { %>
<% if (this.IsCurrentYear) { %>
<ul style="display: block;">
<% } else { %>
<ul>
<% } %>
<% foreach (var month in Months) { %>
    <li class="expanded">
        <a href="<%=this.NewsUrl %>&m=<%= month.Number%>">
            <%= month.Title%></a>
    </li>
    <% } %>
</ul>
<% } %>
