<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsArchive.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsArchive" %>
<%@ Import Namespace="umbraco.NodeFactory" %>

<ul class="menu">
    <li><a href="#"><asp:Literal runat="server" ID="archiveTitle"></asp:Literal></a>
    <ul>
<asp:Repeater runat="server" ID="rptArchive">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%=this.ArchiveUrl %>?archive=<%# ((Node)Container.DataItem).Name%>">
            <%# ((Node)Container.DataItem).Name%></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
</ul>
    </li>
</ul>

