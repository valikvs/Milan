<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactForm.ascx.cs" Inherits="VSS.Milan.Web.UserControls.ContactForm" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Utils" %>
<div class="form">
    <h3>
        <%=CurrentNode.Property(Fields.Contact.FormTitle)%>
    </h3>
    <div class="row clearfix">
        <label class="<%=this.IsEmailValid.RenderError()%>">
            <%=CurrentNode.Property(Fields.Contact.EmailText)%>*</label>
        <asp:TextBox alt="" ID="txtEmail" runat="server" MaxLength="255" />
        <asp:CustomValidator ID="cvEmailRequired" runat="server" ControlToValidate="txtEmail" OnServerValidate="CvInputRequiredValidate" Display="None" ValidateEmptyText="true" ValidationGroup="vgContactForm"/>
		<asp:CustomValidator ID="cvEmailValid" runat="server" ControlToValidate="txtEmail" OnServerValidate="CvEmailValidate" Display="None" ValidateEmptyText="false" ValidationGroup="vgContactForm"/>
    </div>
    <div class="row clearfix">
        <label class="<%=this.IsNameValid.RenderError()%>">
            <%=CurrentNode.Property(Fields.Contact.NameText)%>*</label>
        <asp:TextBox alt="" ID="txtName" runat="server" MaxLength="255" />
        <asp:CustomValidator ID="cvName" runat="server" ControlToValidate="txtName" OnServerValidate="CvInputRequiredValidate" Display="None" ValidateEmptyText="true" ValidationGroup="vgContactForm"/>
    </div>
    <div class="row clearfix">
        <label>
            <%=CurrentNode.Property(Fields.Contact.PhoneText)%></label>
        <asp:TextBox alt="" ID="txtPhone" runat="server" MaxLength="255" />
    </div>
    <div class="row clearfix">
        <label>
            <%=CurrentNode.Property(Fields.Contact.SubjectText)%></label>
        <asp:TextBox alt="" ID="txtSubject" runat="server" MaxLength="255" />
    </div>
    <div class="row clearfix">
        <label class="<%=this.IsMessageValid.RenderError()%>">
            <%=CurrentNode.Property(Fields.Contact.MessageText)%>*</label>
        <asp:TextBox alt="" ID="txtMessage" runat="server" MaxLength="2000" TextMode="MultiLine" />
        <asp:CustomValidator ID="cvMessage" runat="server" ControlToValidate="txtMessage" OnServerValidate="CvInputRequiredValidate" Display="None" ValidateEmptyText="true" ValidationGroup="vgContactForm"/>
    </div>
    <div class="row clearfix">
        <label>
        </label>
        <asp:LinkButton runat="server" ID="btnSend" onclick="BtnSendClick" ValidationGroup="vgContactForm" CausesValidation="True" />
    </div>
    <p>
        <%=CurrentNode.Property(Fields.Contact.RequiredText)%>
    </p>
    <asp:PlaceHolder runat="server" ID="plhResult" Visible="False">
        <p class="result">
            <%=Result%>
        </p>
    </asp:PlaceHolder>
</div>
