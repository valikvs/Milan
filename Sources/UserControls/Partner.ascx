<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Partner.ascx.cs" Inherits="VSS.Milan.Web.UserControls.Partner" %>

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
    <asp:HyperLink runat="server" ID="hlUrl"></asp:HyperLink>
    </asp:PlaceHolder>
</p>
