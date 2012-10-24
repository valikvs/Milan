<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendationsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.RecommendationsNavigation" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<h2>
    <asp:Literal runat="server" ID="recommendationsTitle"></asp:Literal></h2>
<% if (NodeHelper.AllRecommendations.Count > 0)
   { %>
<ul class="menu">
    <% foreach (var recommendation in NodeHelper.AllRecommendations) { %>
    <% if (this.IsCurrentNode(recommendation)) { %>
    <li class="cur">
    <% } else { %>
    <li>
    <% } %>
        <a href="<%=recommendation.Url%>"><%=recommendation.Property(Fields.Recommendation.Title)%></a>
    </li>
    <% } %>
    <% if (this.IsCurrentNode(NodeHelper.RecommendationsNode)) { %>
    <li class="cur">
    <% } else { %>
    <li>
    <% } %>
        <a href="<%=NodeHelper.RecommendationsNode.Url%>"><asp:Literal runat="server" ID="viewAllText"></asp:Literal> </a>
    </li>
</ul>
<% } %>

