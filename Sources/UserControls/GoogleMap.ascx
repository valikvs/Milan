<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoogleMap.ascx.cs" Inherits="VSS.Milan.Web.UserControls.GoogleMap" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Constants" %>
<%@ Import Namespace="VSS.Milan.Web.Core.Extentions" %>

<div id="map_canvas" class="map"></div>

<script type="text/javaScript" src="/scripts/jquery.ui.map.js"></script>
<script type="text/javascript">
    $(function () {
        $('#map_canvas').gmap({ 'center': '<%=CurrentNode.Property(Fields.Contact.Map)%>', 'zoom': 15, 'disableDefaultUI': true, 'callback': function () {
            var self = this;
            self.addMarker({ 'position': this.get('map').getCenter() }).click(function () {
                self.openInfoWindow({ 'content': '<%=CurrentNode.Property(Fields.Contact.MarkerText)%>' }, this);
            });
        }
        });
    });
</script>
