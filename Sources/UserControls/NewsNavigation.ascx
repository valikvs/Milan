<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsNavigation.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsNavigation" %>
<h2>
    <asp:Literal runat="server" ID="newsTitle"></asp:Literal></h2>

<asp:Repeater runat="server" ID="rptNewsNavigation">
    <HeaderTemplate>
        <ul class="menu">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="#">2012</a>
        <ul>
            <li><a href="#">апрель</a></li>
            <li><a href="#">март</a></li>
            <li><a href="#">февраль</a></li>
        </ul>
    </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

