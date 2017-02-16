<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Serviceareas.aspx.cs" Inherits="Serviceareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        table,td
        {
       
        }
        td
        {
            width:30%;
            padding:5px;
            color:maroon;
        }
        tr
        {
            border-collapse:collapse;
        }
    </style>
</head>
    <script type="text/javascript">
var xmlDoc;
var xmlhttp;
function loadXMLDoc()
{
	xmlhttp=new XMLHttpRequest();
	
	xmlhttp.onreadystatechange=readData;
	
	xmlhttp.open("GET","inf.xml",true);

	xmlhttp.send();
	
}
function readData()
{

	if(xmlhttp.readyState==4||xmlhttp.readyState==200)
	{
		var xmlDoc=xmlhttp.responseXML;
		
		 items= xmlDoc.getElementsByTagName("but");
		
		var len=items[0].attributes.length;
		
		var bull = document.getElementById("blue");
        var pig=document.getElementById("red")
        var c=[];
        var p=[];
        for(var next=1;next<=len;next++)
		{
		    
		   
		        var city = items[0].getAttribute("city" + next);
		         c[next]=city;
		        var num = items[0].getAttribute("city" + next + "phone");
		        p[next] = num;
		    }
		   
        
        var d = document.getElementById("row1");
        for(var i=1;i<=3;i++)
            d.innerHTML = d.innerHTML + "<td>" + c[i] + "</td>";
        var d = document.getElementById("row2");
        for (var i = 1; i <= 3; i++)
            d.innerHTML = d.innerHTML + "<td><u>" + p[i] + "</u></td>";
        var d = document.getElementById("row3");
        for (var i = 4; i <= 6; i++)
            d.innerHTML = d.innerHTML + "<td>" + c[i] + "</td>";
        var d = document.getElementById("row4");
        for (var i = 4; i <= 6; i++)
            d.innerHTML = d.innerHTML + "<td><u>" + p[i] + "</u></td>";
        var d = document.getElementById("row5");
        for (var i = 7; i <= 9; i++)
            d.innerHTML = d.innerHTML + "<td>" + c[i] + "</td>";
        var d = document.getElementById("row6");
        for (var i = 7; i <= 9; i++)
            d.innerHTML = d.innerHTML + "<td><u>" + p[i] + "</u></td>";

        
	}
}

</script>
<body onload="loadXMLDoc()">
    <form id="form1" runat="server">
   <h1><font color="#ff00ff">SERVICE AREAS</font></h1>
<p><font color="maroon" size="3">Texans' Store to Door Delivary Service is your on Demand Specialist and your Instant solution to your same day shipping needs.We are the choice of hundreds of customers around the city and around the state-let us be your choice.LET US show you why,"You Can Contact On Us -- We're Texans Serving Texans 24 Hours a Day!!".</font></p>
<h4><font color="#ff00ff">We serve the following areas</font></h4>
 
<table width="100%">
    <tr id="row1"></tr>
    <tr id="row2"></tr>
    <tr id="row3"></tr>
    <tr id="row4"></tr>
    <tr id="row5"></tr>
    <tr id="row6"></tr>
</table>
    </form>
</body>
</html>
