function Animation(){
	var time;
	time = 20;
	var delay;
	var img = Array();
	function read_img(id_obj, x1, y1, x2, y2, coefficient){
		for(var i = 0 in id_obj){
			img[i] = { 
				id : id_obj[i],
				x1 : x1[i],
				x2 : x2[i],
				y1 : y1[i],
				y2 : y2[i],
				spead_x : 0,
				spead_y : 0
				};
			document.getElementById(id_obj[i]).style.left = x1[i] + "px";
			document.getElementById(id_obj[i]).style.top = y1[i] + "px";
		}
		time = coefficient;		
	}

	delay = 30;
	function spead(start, finish,position,i,p){
		var s;
		var delta = (((finish-start))/(time*delay));
		//console.log("Delta: "+delta + "|" + ((finish-start)) + "|"+(Math.abs(finish-start)) );
		if(position === finish){		return 0;	}
		else if(start > finish && position < finish){	return 0;	}
		else if(start < finish && position > finish){	return 0;	}
		else if((start < finish && position - start <= (finish - start)/2) || 
				(start > finish && position - start >= (finish - start)/2)){
				//500		0			-100				-500	2			
			//ускоряем	
			if(p === "x"){			
				img[i].spead_x += delta;
				s = ((finish-start)/(time*delay))+img[i].spead_x;
			}
			else{
				img[i].spead_y += delta;
				s = ((finish-start)/(time*delay))+img[i].spead_y;
			}
			//console.log(s);
			return s;
		}
		else{
			//Замедляем			
			if(p === "x"){	
				if((start < finish && img[i].spead_x > 0) || (start > finish && img[i].spead_x < 0))		
					img[i].spead_x  -= delta;
				s = ((finish-start)/(time*delay))+img[i].spead_x;
			}
			else{
				if((start < finish && img[i].spead_y > 0) || (start > finish && img[i].spead_y < 0))		
					img[i].spead_y -= delta;
				s = ((finish-start)/(time*delay))+img[i].spead_y;
			}
			//console.log(s);
			return s;
		}
	}
	function tr(){
		//console.log(obj.style.left);
		for(var j = 0 in img){
			var obj = document.getElementById(img[j].id);
			obj.style.left = parseFloat(obj.style.left) + spead(img[j].x1, img[j].x2, parseFloat(obj.style.left), j, "x") + "px";	
			obj.style.top = parseFloat(obj.style.top) + spead(img[j].y1, img[j].y2, parseFloat(obj.style.top), j, "y") + "px";
					
			if((img[j].x1 < img[j].x2 && parseFloat(document.getElementById(img[j].id).style.left,10) >= img[j].x2) ||
				 (img[j].x1 > img[j].x2 && parseFloat(document.getElementById(img[j].id).style.left,10) <= img[j].x2))
			{
				console.log(document.getElementById(img[0].id).style.left + "x="+ img[0].x2);
				console.log(document.getElementById(img[0].id).style.top + "y=" +img[0].y2);
				console.log(document.getElementById(img[1].id).style.left + "x="+ img[1].x2);
				console.log(document.getElementById(img[1].id).style.left + "x="+ img[1].x2);
				console.log(document.getElementById(img[2].id).style.top + "y="+ img[2].y2);				
				console.log(document.getElementById(img[2].id).style.top + "y="+  img[2].y2);				
					console.log("Stop");
				clearInterval(intervalID);
			}			
		}
	}
	function start(){
		intervalID=setInterval(tr,1000/delay);
	}
		//setInterval(tr, 20);
	return{
		read : read_img	,
		start : start
	};
}

var n = Animation();
n.read(["img_1", "img_2","img_3"],[500,100,0],[500,100,0],[100,500,700],[0,200,500],30);
n.start();
//var ob = ["img_1"];
//window.onload = start(ob,[0],[100],[1000],[200],5);
