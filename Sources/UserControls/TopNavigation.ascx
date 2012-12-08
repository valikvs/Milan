<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavigation.ascx.cs"
    Inherits="VSS.Milan.Web.UserControls.TopNavigation" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%@ Import Namespace="umbraco.NodeFactory" %>
<asp:Repeater runat="server" ID="rptNavigation">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%# ((Node)Container.DataItem).Url%>"><%# ((Node)Container.DataItem).Property(Fields.BaseContent.NavigationTitle)%></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
