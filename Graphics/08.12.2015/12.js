function tree() {
	var id;
	function rand(min_, max_) {
		return Math.random() * (max_ - min_) + min_;
	}
	function read_info(kol, n_, colors, horizontal_krok, vertikal_krok, width_krok, stroke_width, id_, line_width) {
		id = id_;
		this.n = Array();
		this.color = Array();
		this.hk = Array();
		this.vk = Array();
		this.wk = Array();
		this.sw = Array();
		this.start_y = Array();
		this.start_x = Array();
		this.w_p = Array();
		this.h_p = Array();
		this.l_w = line_width;
		this.max_tree = kol;
		for (var j = 0; j < kol; j++) {
			this.n[j] = parseInt(rand(n_[0], n_[1]));
			this.hk[j] = rand(horizontal_krok[0], horizontal_krok[1]);
			this.vk[j] = rand(vertikal_krok[0], vertikal_krok[1]);
			this.wk[j] = rand(width_krok[0], width_krok[1]);
			this.sw[j] = rand(stroke_width[0], stroke_width[1]);
			this.start_y[j] = rand(0, 100);
			this.start_x[j] = 200 + 100 * j * 2 + rand( - 100, 100);
			this.w_p[j] = rand(20, 30) / 2;
			this.h_p[j] = rand(20, 30);
		}
		this.color = Array(colors[0], colors[1], colors[2]);
	}
	function new_tree() {
		var example = document.getElementById(id);
		var ctx = example.getContext('2d');
		example.height = 500;
		example.width = 1320;
		ctx.fillStyle = "#ff0000";
		ctx.font = "22px Arial";
		ctx.fillText("By, Dovbnia D.", 1000, 400);
		for (var j = 0; j < this.max_tree; j++) {
			ctx.beginPath();
			ctx.strokeStyle = this.color[0];
			ctx.lineWidth = this.l_w;
			ctx.moveTo(this.start_x[j], this.start_y[j]);
			for (var i = 1; i <= this.n[j]; i++) {
				ctx.quadraticCurveTo(this.start_x[j] - (this.hk[j]) * i - this.sw[j], this.start_y[j] + (this.vk[j]) * i, this.start_x[j] - (this.hk[j]) * i, this.start_y[j] + (this.vk[j]) * i);
				if (i === this.n[j]) {
					ctx.lineTo(this.start_x[j], this.start_y[j] + (this.vk[j]) * i);
				}
			}
			ctx.moveTo(this.start_x[j], this.start_y[j]);
			for (i = 1; i <= this.n[j]; i++) {
				ctx.quadraticCurveTo(this.start_x[j] + (this.hk[j]) * i + this.sw[j], this.start_y[j] + (this.vk[j]) * i, this.start_x[j] + (this.hk[j]) * i, this.start_y[j] + (this.vk[j]) * i);
				if (i === this.n[j]) {
					ctx.lineTo(this.start_x[j], this.start_y[j] + (this.vk[j]) * i);
				}
			}
			ctx.fillStyle = this.color[1];
			ctx.fill();
			ctx.stroke();
			ctx.beginPath();
			ctx.strokeStyle = this.color[2];
			ctx.moveTo(this.start_x[j] - this.w_p[j], this.start_y[j] + this.l_w / 2 + (this.vk[j]) * this.n[j]);
			ctx.lineTo(this.start_x[j] - this.w_p[j], this.start_y[j] + this.l_w / 2 + (this.vk[j]) * this.n[j] + this.h_p[j]);
			ctx.lineTo(this.start_x[j] + this.w_p[j], this.start_y[j] + this.l_w / 2 + (this.vk[j]) * this.n[j] + this.h_p[j]);
			ctx.lineTo(this.start_x[j] + this.w_p[j], this.start_y[j] + this.l_w / 2 + (this.vk[j]) * this.n[j]);
			ctx.fillStyle = this.color[2];
			ctx.fill();
			ctx.stroke();
		}
	}
	function delete_tree() {
		var example = document.getElementById(id);
		example.height = 500;
		example.width = 1320;
	}
	return {
		read: read_info,
		print_tree: new_tree,
		clean: delete_tree
	};
}
var t = new tree();
function reset_(){
	t.read(5, [2, 6], ["#264a1b", "#0f0", "brown"], [15, 30], [20, 40], [40, 60], [50, 70], "img", 5);
	t.print_tree();
}
window.onload = reset_;