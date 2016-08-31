var sLastSelect;
var lastStrokeColor="black"; 
function getID(evt)
{
    var sID = evt.target.getAttribute("id"); 
    if(sLastSelect!=null)
    {
		if(lastStrokeColor!=null)
		{
         sLastSelect.setAttribute('stroke',lastStrokeColor);
		}
	    else
		{
			 sLastSelect.setAttribute('stroke',"black");
		}
    }
	
    sLastSelect=evt.target; 
    var strokeColor=evt.target.getAttribute("stroke");
    lastStrokeColor=strokeColor; 
    if(strokeColor!="red") 
    {
        strokeColor="red";
    }
    else 
    {
        strokeColor="black";
    }  
    evt.target.setAttribute('stroke',strokeColor);
    evt.target.setAttribute("style",'stroke-width:2');
    return window.external.ShowMessage(sID);
}