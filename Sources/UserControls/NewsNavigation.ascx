<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsNavigation" %>
<%@ Register TagPrefix="uc" Src="~/UserControls/NewsYear.ascx" TagName="NewsYear" %>
<%@ Register TagPrefix="uc" Src="~/UserControls/NewsArchive.ascx" TagName="NewsArchive" %>
<%@ Import Namespace="umbraco.NodeFactory" %>
<h2>
    <asp:Literal runat="server" ID="newsTitle"></asp:Literal></h2>
<asp:Repeater runat="server" ID="rptNewsNavigation">
    <HeaderTemplate>
        <ul class="menu">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="#">
            <%# ((Node)Container.DataItem).Name%></a>
            <uc:NewsYear DataSource="<%#Container.DataItem%>" runat="server"></uc:NewsYear>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<uc:NewsArchive runat="server"></uc:NewsArchive>
