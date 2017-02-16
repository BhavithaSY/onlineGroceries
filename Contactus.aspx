<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contactus.aspx.cs" Inherits="Contactus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 107px;
            width: 509px;
        }
    </style>
</head>
<body style="background-color:cadetblue">
    <form id="form1" runat="server">
       Enter your Email Address<font color="red">*</font> :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="TextBox1"  ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revemail" runat="server" Display="Dynamic" ErrorMessage="Please enter valid email" ControlToValidate="TextBox1" ForeColor="red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
    <div>
    
        <textarea id="TextArea1" name="S1" placeholder="Enter Your message here"></textarea><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit mail" />
    
    </div>
    </form>
</body>
</html>
