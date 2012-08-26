<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainNavigation.ascx.cs"
    Inherits="VSS.Milan.Web.UserControls.MainNavigation" %>
<%@ Import Namespace="umbraco.NodeFactory" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%@ Import Namespace="VSS.Milan.Web.Core" %>
<asp:Repeater runat="server" ID="rptNavigation">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%# ((Node)Container.DataItem).Url%>"><%# ((Node)Container.DataItem).Property(Constants.BaseContent.NavigationTitle)%></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
