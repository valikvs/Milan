<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsYear.ascx.cs" Inherits="VSS.Milan.Web.UserControls.NewsYear" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Data" %>
<asp:Repeater runat="server" ID="rptMonths">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%=this.NewsUrl %>&m=<%# ((Month)Container.DataItem).Number%>">
            <%# ((Month)Container.DataItem).Title%></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
