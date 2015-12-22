function canvasApp(){
	
	var theCanvas = document.getElementById("img");
	var context = theCanvas.getContext("2d");
	if(!theCanvas || !theCanvas.getContext)
		return;
	drawScreen();
	function drawScreen(){
		context.fillStyle = "#ff0000";
		context.font = "22px Arial";
		context.textBaseline = "top";
		context.stroceStyle = "#ff0000";
		context.strokeRect(5, 5 , 420, 330);
		var helloWorldImage = new Image();
		helloWorldImage.onload = function(){
			context.drawImage(helloWorldImage, 15,15);	
		}
		helloWorldImage.src = "1.jpg";
		context.fillText("Dovbniya D.", 150 , 300);

	}
}
window.onload = canvasApp;