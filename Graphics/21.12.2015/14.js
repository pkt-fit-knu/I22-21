function Animation(){
	var time;
	time = 40;
	var radius;
	var delay;
	var img = Array();
	var intervalID;
	var g;
	var m;
	var E = 2200;
	var t ;
	function random_color(){
		return "rgb("+Math.floor(Math.random() * (255 + 1)) + ","+Math.floor(Math.random() * (255 + 1))+","+Math.floor(Math.random() * (255 + 1))+")";
	}
	var theCanvas ;
	var context;
	//	("img",1,100,200,30,1000,200,2200,10,1,10);
	function read_img(id_pole, n, x0, y0, coefficient, time_coef, h,energy, gravitacion,masa,R){
		t = time_coef;
		for(var i = 0; i < n; i++){
			var id = "object_"+i;
			document.getElementById(id_pole).innerHTML += "<div id="+id+" class='circle' style='background:"+random_color()+";'></div>";
			img[i] = { 
				id : id,
				x0 : x0,
				y0 : y0,
				fi : 10,
				k :1,
				h0 : h,
				e : 10
				};
			document.getElementById(id).style.left = x0 + "px";
			document.getElementById(id).style.top = y0 + "px";
		}
		time = coefficient;	
		radius = R;
		g = gravitacion;	
		m = masa;
		E = energy;

		theCanvas = document.getElementById("myCanvas");
		context = theCanvas.getContext("2d");  
		context.beginPath();
		context.moveTo(x0, y0);
		var delay;
		var intervalID;
		var t ;
	}
			


	delay = 1;
	var delta = 2;
	function traektoria(start,position,i,p){
		var s;
		if(p === "x"){
			s = position-start+1;
			//if((position) % 100 == 0) {img[i].k++;}
		}
		else{
			//console.log(img[i].fi);
			if((img[i].fi % (360)) === 0) {//img[i].k+=1;
				//console.log(img[i].k);
			}		
			s = radius*Math.sin(img[i].fi/(Math.PI*2*10))*img[i].k;
			//console.log(radius*Math.sin(img[i].fi/(Math.PI*2*10)+90)*img[i].k);
		}
		return s;
	}
	function spead(i){
		//E=(mw^2)/2
		/*
		2e/m=v2
		*/
		//E=mgh
		var v = 0;
		if(2 * img[i].e / m <= 0){
			stop_animation();
			return 0;
		}
		v = Math.sqrt(2 * img[i].e / m);
		
		console.log(img[i].e + "|" +v);		

		if(v<0)	{	return 0;}
		else	{	return v;}
		
		
	}
	function traectoria(){
		//console.log(obj.style.left);
		for(var j = 0 in img){
			var obj = document.getElementById(img[j].id);

			if(radius*Math.sin(img[j].fi/(Math.PI*2*10)*img[j].k+90) > 0){
				img[j].e = E - m * g * (radius + img[j].y0 - parseFloat(obj.style.top));
				img[j].fi += spead(j)/30;
			}
			else{	
				img[j].e = E - m * g * (radius + img[j].y0 - parseFloat(obj.style.top));
				console.log( m * g * (radius + img[j].y0 - parseFloat(obj.style.top)));
				img[j].fi += spead(j)/30;	
			}

			obj.style.left = img[j].x0 + traektoria(img[j].x0, parseFloat(obj.style.left), j, "x") + "px";	
			obj.style.top = img[j].y0 + traektoria(img[j].y0,  parseFloat(obj.style.top), j, "y") + "px";
			context.lineTo(parseFloat(obj.style.left), parseFloat(obj.style.top));  

		}
	}
	function start(){
		clearInterval(intervalID);
		intervalID=setInterval(traectoria,1);
	}
	function stop_animation(){
		clearInterval(intervalID);
		context.lineWidth = 5;
		context.strokeStyle = 'blue';
		context.stroke();		
	}
	return{
		read : read_img	,
		start : start,
		stop_a : stop_animation
	};
}
