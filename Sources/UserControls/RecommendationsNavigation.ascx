<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendationsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.RecommendationsNavigation" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%=HtmlHelper.LeftNavigationItem(this.RecommendationsNode)%>
<% if (NodeHelper.AllRecommendations.Count > 0)
   { %>
<ul class="menu">
    <% foreach (var recommendation in NodeHelper.AllRecommendations) { %>
    <% if (NodeHelper.IsCurrentNode(recommendation)) { %>
    <li class="cur">
    <% } else { %>
    <li>
    <% } %>
        <a href="<%=recommendation.Url%>"><%=recommendation.Property(Fields.BaseContent.NavigationTitle)%></a>
    </li>
    <% } %>
    <% if (NodeHelper.IsCurrentNode(this.RecommendationsNode)) { %>
    <li class="cur">
    <% } else { %>
    <li>
    <% } %>
        <a href="<%=this.RecommendationsNode.Url%>"><%=this.RecommendationsNode.Property(Fields.Recommendations.ViewAllText)%></a>
    </li>
</ul>
<% } %>

