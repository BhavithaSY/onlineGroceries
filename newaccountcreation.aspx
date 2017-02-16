<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newaccountcreation.aspx.cs" Inherits="newaccountcreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <asp:RadioButtonList ID="ne" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" OnSelectedIndexChanged="accpage" AutoPostBack="true">
        <asp:ListItem  Text="I have an existing account"  Value="exist"></asp:ListItem>
        <asp:ListItem Text="I don't have an existing account" selected="True" Value="noexist" ></asp:ListItem>
    </asp:RadioButtonList>
    </div>
        <div>
            <fieldset>
                <legend>Create new Account</legend>
                <p>Apply online to open a new account with us</p><br />
                <p>To complete the online application please fill in the following details and predd the create account button</p>
                <asp:Label ID="test" runat="server" Text="wow!!"></asp:Label>
                <table>
                    <tr>
                        <td>Full name<font color="red">*</font></td>
                        <td><asp:TextBox ID="name" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="name"  ForeColor="red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revname" runat="server" Display="Dynamic" ErrorMessage="Please enter valid name" ControlToValidate="name" ForeColor="red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Company
                        </td>
                        <td><asp:TextBox ID="company" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            Mailing Address<font color="red">*</font>
                        </td>
                        <td>
                            <asp:TextBox ID="maddress" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvmaddress" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="maddress"  ForeColor="red"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>phone number<font color="red">*</font></td>
                        <td><asp:TextBox ID="phonenum" runat="server"  ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvphone" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="phonenum"  ForeColor="red"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="revphone" runat="server" Display="Dynamic" ErrorMessage="Please enter valid phone number" ControlToValidate="phonenum" ForeColor="red" ValidationExpression="^[0-9]{3}-[0-9]{3}-[0-9]{4}$"></asp:RegularExpressionValidator>


                            </td>
                    </tr>
                    <tr>
                        <td>Email address<font color="red">*</font></td>
                        <td><asp:TextBox ID="email" runat="server" TextMode="Email" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvemail" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="email"  ForeColor="red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revemail" runat="server" Display="Dynamic" ErrorMessage="Please enter valid email" ControlToValidate="email" ForeColor="red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                   </td>
                             </tr>
                    <tr>
                        <td>
                            Access Code
                        </td>
                        <td><asp:TextBox ID="code" runat="server" Enabled="false" Width="50" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            Enter access code<font color="red">*</font>
                        </td>
                        <td><asp:TextBox ID="codecheck" runat="server" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvcodecheck" runat="server" ErrorMessage="please fill fields with *" Display="Dynamic" ControlToValidate="codecheck"  ForeColor="red"></asp:RequiredFieldValidator>
                         <asp:CompareValidator runat="server" id="cmpNumbers" controltovalidate="codecheck" controltocompare="code" operator="Equal"  errormessage="The  number should be same as given access code!" /><br />

                        </td>
                    </tr>
                    
                </table>
                <asp:Button ID="acccreate" Text="Create Account" runat="server" OnClick="sweat" />
                <asp:Button ID="goback" Text="Back To Accounts" OnClick="hasgone" runat="server" CausesValidation="false" />
            </fieldset>
        </div>
    </form>
</body>
</html>
