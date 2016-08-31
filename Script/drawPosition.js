
function onmouseOver(evt){currentX = evt.clientX;
currentY = evt.clientY;
var svg = document.getElementsByTagName('svg')[0];
var newElement = document.getElementById('idX'); 
newElement.setAttribute("d","M"+ currentX.toString()+ " 0 v 5000 "); 
newElement.style.stroke = "red"; 
newElement.style.strokeWidth = "5px"; 
svg.appendChild(newElement);
var newElement2 = document.getElementById('idY'); 
newElement2.setAttribute("d","M 0 "+ currentY.toString()+" h 3000"); 
newElement2.style.stroke = "red"; 
newElement2.style.strokeWidth = "5px"; 
svg.appendChild(newElement2);}
 
