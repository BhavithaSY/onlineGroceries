<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        h3.a {
            text-align: center;
            padding: 0px;
            background-color: #43c6db;
            color: white;
        }

        .b {
            text-align: center;
            color: #43c6db;
        }
        #he
        {
             text-align: center;
            color: #43c6db;
        }
        #put
        {
             text-align: center;
            color: #43c6db;
        }
        #she,#def,#dumb {
            text-align: center;
            color: #43c6db;
        }
        body{
            overflow:hidden;
            }
        p{
            padding: 0;
            margin:0;
        }
      
    </style>
</head>
    <script type="text/javascript">
    var xmlDoc;
    var xmlhttp;
    function loadXMLDoc() {
        xmlhttp = new XMLHttpRequest();

        xmlhttp.onreadystatechange = readData;

        xmlhttp.open("GET", "inf.xml", true);

        xmlhttp.send();

    }
    function readData() {

        if (xmlhttp.readyState == 4 || xmlhttp.readyState == 200) {
            var xmlDoc = xmlhttp.responseXML;
            
            items = xmlDoc.getElementsByTagName("but");
            
            var len = items[0].attributes.length;
            
            var bull = document.getElementById("he");
            var dog = document.getElementById("put");
            
            var num = items[0].getAttribute("toll-free-phone");
            
            bull.innerHTML =bull.innerHTML+ num;
            var mai = items[0].getAttribute("contact-email");
            dog.innerHTML = dog.innerHTML + mai;
           


                var city = items[0].getAttribute("city1" );
               var c = city;
                var num = items[0].getAttribute("city1phone");
                var p = num;
                dumb.innerHTML =  c;
                def.innerHTML =  p;
            

            
            
        }
    }

    </script>
<body onload="loadXMLDoc()">
    <form id="form1" runat="server">
    <h3 class="a">CONTACT US</h3>
    <p class="b"> <b>WE SERVE 24/7</b></br></br>Toll Free Number:</br></p>
        <p id="he"></p>
    <p id="dumb"></p><p id="def"></p>
    <p id="she">Email:</br></p>
    <p id="put"><u></u></p>
    </form>
</body>
</html>
