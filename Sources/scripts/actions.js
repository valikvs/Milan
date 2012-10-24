$(document).ready(function () {

	$(".sideCol .menu .hasSubMenu > a").click(function() {
		$(this).parent().children("ul").toggle("fast");
		$(this).parent().toggleClass("expanded");
		return false
	});
	
})
