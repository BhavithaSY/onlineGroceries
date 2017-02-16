<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accounts.aspx.cs" Inherits="Accounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:RadioButtonList ID="ne" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" OnSelectedIndexChanged="newpage" AutoPostBack="true">
        <asp:ListItem  Text="I have an existing account" selected="True" Value="exist"></asp:ListItem>
        <asp:ListItem Text="I don't have an existing account" Value="noexist" ></asp:ListItem>
    </asp:RadioButtonList>
    </div>
        <div>
            <fieldset>
                <legend>Existing Account</legend>
                EmailAddress<font color="red">*</font> : <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="email"  ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revemail" runat="server" Display="Dynamic" ErrorMessage="Please enter valid email" ControlToValidate="email" ForeColor="red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator><br />
                Access Code<font color="red">*</font>:<asp:TextBox TextMode="Password" ID="pass" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvpassword1" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="pass"  ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revpass" runat="server" Display="Dynamic" ErrorMessage="Please enter valid 6 digit accesscode" ControlToValidate="pass" ForeColor="red" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator><br />

<br/>
                <asp:HyperLink ID="forgetpass" NavigateUrl="Recover.aspx" Text="Forget Password" runat="server"></asp:HyperLink>
                <asp:Button ID="login" Text="LOG IN" runat="server" UseSubmitBehavior="true" OnClick="logon"></asp:Button>
            </fieldset>
        </div>
    </form>
</body>
</html>
