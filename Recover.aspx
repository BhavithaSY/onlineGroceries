<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="Recover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend>Recover Password</legend>
         EmailAddress<font color="red">*</font> : <asp:TextBox ID="email" runat="server" TextMode="Email" AutoPostBack="true" OnTextChanged="textchange"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="email"  ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revemail" runat="server" Display="Dynamic" ErrorMessage="Please enter valid email" ControlToValidate="email" ForeColor="red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                <asp:Button ID="recover" runat="server" Text="Recover Password" OnClick="recoverbutton" /><br />
       <asp:HyperLink ID="gobacktoaccountspage" Text="Go Back To Accounts Page" runat="server" NavigateUrl="Accounts.aspx" />
    </fieldset>
    </div>
    </form>
</body>
</html>
