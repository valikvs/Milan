$(document).ready(function () {

	$(".sideCol .menu > li > a").click(function() {
		$(this).parent().toggleClass("expanded");
		$(this).parent().children("ul").toggle("fast");
		return false
	});
	
})
