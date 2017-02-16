<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
			ul
				{
					list-style-type:none;
					margin:0;
					padding:0;
					overflow:hidden;
					background-color:#43c6db;
					
					
				}
			li
				{
					float:left;
				}
			li a
				{
					display:inline-block;
					color:white;
					text-align:center;
					padding:3px 22px;
					text-decoration:none;
					font-family:arial black;
				
				}
			li a:hover
				{
					background-color:#4ee2ec;
					
			
				}
		</style>
</head>
<body>
    <form id="form1" runat="server">
    <ul>
			<li><a class="active" href="Start.html" target="_parent">Home</a></li>
			<li><a href="About.aspx" target="_parent">About Us</a></li>
			<li><a href="Service.aspx" target="res">Service</a></li>
			<li><a href="Accounts.aspx" target="res">Accounts</a></li>
			<li><a href="Contactus.aspx" target="res">Contact Us</a></li>
			<li><a href="Resources.aspx"target="res">Resources</a></li>
            <li><a href="Serviceareas.aspx" target="res">Service Areas</a></li>
		</ul>
    </form>
</body>
</html>
