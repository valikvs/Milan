<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sharing.ascx.cs" Inherits="VSS.Milan.Web.UserControls.Sharing" %>

<div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>

<div class="social">
    <div class="fb-like" data-send="false" data-layout="button_count" data-width="450" data-show-faces="false"></div>
</div>