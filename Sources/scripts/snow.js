var container,
	snow_intensive,
	snow_speed,
	snow_src; 

function snow_start() { 
	snow_id=1; 
	snow_y=container.height()-30; 
	setInterval(function() { 
		snow_x=Math.random()*document.body.offsetWidth-100; 
		snow_img=(snow_src instanceof Array ? snow_src[Math.floor(Math.random()*snow_src.length)] : snow_src); 
		snow_elem='<img class="png" id="snow'+snow_id+'" style="position:absolute; left:'+snow_x+'px; top:0;z-index:10000" src="'+snow_img+'">'; 
		container.append(snow_elem); 
		snow_move(snow_id); 
		snow_id++; 
	},snow_intensive);
} 
		
function snow_move(id) { 
	$('#snow'+id).animate({top:snow_y,left:"+="+Math.random()*100},snow_speed,function() { 
	$(this).empty().remove(); 
});} 