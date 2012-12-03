<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaPartners.ascx.cs" Inherits="VSS.Milan.Web.UserControls.MediaPartners" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%@ Import Namespace="umbraco.NodeFactory" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<div class="partners">
    <h2>
        <asp:Literal runat="server" ID="partnersTitle"></asp:Literal>
    </h2>
    <asp:Repeater runat="server" ID="rptPartners">
        <ItemTemplate>
            <p>
                <%# ((Node)Container.DataItem).Property(Fields.MediaPartner.Title)%><br>
                <a href="<%# ((Node)Container.DataItem).Property(Fields.MediaPartner.Url)%>" target="_blank"><%# ((Node)Container.DataItem).Property(Fields.MediaPartner.Url).UrlHost()%></a></p>
        </ItemTemplate>
    </asp:Repeater>
</div>
