<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Partner.ascx.cs" Inherits="VSS.Milan.Web.UserControls.Partner" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<p>
    <asp:PlaceHolder runat="server" ID="plhTitle">
    <%=Title%><br />
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="plhAddress">
    <%=Address%><br />
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="plhPhone">
    <%=Phone%><br />
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="plhUrl">
    <a href="<%=Url%>" target="_blank"><%=Url.UrlHost()%></a>
    </asp:PlaceHolder>
</p>
