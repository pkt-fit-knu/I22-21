function Animation(){
	var time;
	time = 40;
	var radius;
	var delay;
	var img = Array();
	var intervalID;
	function random_color(){
		return "rgb("+Math.floor(Math.random() * (255 + 1)) + ","+Math.floor(Math.random() * (255 + 1))+","+Math.floor(Math.random() * (255 + 1))+")";
	}
	function read_img(id_pole,n, x0, y0, r, coefficient){
		for(var i = 0; i < n; i++){
			var id = "object_"+i;
			document.getElementById(id_pole).innerHTML += "<div id="+id+" class='circle' style='background:"+random_color()+";'></div>";
			img[i] = { 
				id : id,
				x0 : x0,
				y0 : y0,
				fi : (Math.PI*2*i)/n
				};
			document.getElementById(id).style.left = x0 + "px";
			document.getElementById(id).style.top = y0 + "px";
		}
		time = coefficient;	
		radius = r;	
	}

	delay = 90;
	var delta = (1/time);
	function spead(start,position,i,p){
		if(p === "x"){
			s = radius*Math.cos(img[i].fi);
		}
		else{
			s = radius*Math.sin(img[i].fi);
		}
		return s;
	}
	function tr(){
		//console.log(obj.style.left);
		for(var j = 0 in img){
			var obj = document.getElementById(img[j].id);
			obj.style.left = img[j].x0 + spead(img[j].x0, parseFloat(obj.style.top), j, "x") + "px";	
			obj.style.top = img[j].y0 + spead(img[j].y0,  parseFloat(obj.style.top), j, "y") + "px";
			if(parseFloat(obj.style.top) > img[j].y0){
				img[j].fi += delta * 2;
				
			}
			else
				img[j].fi += delta;		
		}
	}
	function start(){
		clearInterval(intervalID);
		intervalID=setInterval(tr,1000/30);
	}
	function stop_animation(){
		clearInterval(intervalID);
	}
		//setInterval(tr, 20);
	return{
		read : read_img	,
		start : start,
		stop_a : stop_animation
	};
}


