function tree(){
	var n ;
	var color;
	var hk;
	var vk;
	var wk;
	var sw;
	var str;
	var nk;
	function read_info(n_, colors, horizontal_krok, vertikal_krok, width_krok,  naklon,stroke_width){
		this.n = n_;
		
		this.color = colors;
		this.hk =  horizontal_krok;
		this.vk = vertikal_krok;
		this.wk = width_krok;
		this.sw = stroke_width;
		this.nk = naklon;
		this.start_y = 50;
		this.start_x = 400;
	}
	function new_tree(){
		
		var all; 
		all = "<svg height='4000' width='4500'>"; 
		all += " <path d='M " + this.start_x + " " +this.start_y; 
		for(var i = 0; i < this.n; i++) 
			all += " q -"+this.wk+" "+this.nk+" -"+this.hk + " "+ this.vk; 
		
		all += "' stroke="+this.color+" stroke-width='"+this.sw+"' fill='none' />"; 
		
		all += " <path d='M " + this.start_x + " " +this.start_y; 
		for(var k = 0; k < this.n; k++) 
		{ 
		all += " q "+this.wk+" "+this.nk+" "+ this.hk + " " + this.vk; 
		} 
		all += "' stroke="+this.color+" stroke-width='"+this.sw+"' fill='none' />"; 
		
		all +=" <path d='M "+ this.start_x + " "; 
		all += this.vk*(this.n) + this.start_y; 
		all += " q 0 0 "; 
		all += this.hk*(this.n) +1; 
		all += " 0' stroke="+this.color+" stroke-width='"+this.sw+"' fill='none' />"; 
		
		all +=" <path d='M "+ this.start_x + " "; 
		all += this.vk*(this.n) + this.start_y; 
		all += " q 0 0 -"; 
		all += this.hk*(this.n) + 1; 
		all += " 0' stroke="+this.color+" stroke-width='"+this.sw+"' fill='none' />"; 
		//пеньок
		all +=" <path d='M "+ (this.start_x - 15)+ " "; 
		all += this.vk*(this.n) + this.start_y; 
		all += "l 0 40 l 30 0 l 0 -40 l -15 0 Z"; 
		all += " ' stroke='brown' stroke-width='"+this.sw+"' fill='brown' />"; 
		
		document.getElementById("img").innerHTML = all;	
//		this.str = all;
	}
	/*function write_tree(){
		new_tree();
	}*/
	return{
		read: read_info,
		print_tree : new_tree
	};
		
}
var t = new tree();
t.read(5,"#0f0", 20,80,40,80,8); //елка
//t.read(5,"#0f0", 0,60,100,-100,8);
//t.read(5,"#0f0", 20,50,50,50,8);
t.print_tree();
//n_, color, horizontal_krok, vertikal_krok, width_krok, stroke_width
