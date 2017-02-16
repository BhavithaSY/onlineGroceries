<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Userhomepage.aspx.cs" Inherits="Userhomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #he{
            display:table
        }
    </style>
</head>
    
<body>
    <form id="form1" runat="server">
    <div>
   <p2>Welcome </p2><asp:label ID="name" Text="firstname" runat="server" ></asp:label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<p1><asp:Button ID="logout"  Text="Log Out" runat="server" OnClick="logoutof"></asp:Button></p1>
         <asp:RadioButtonList ID="da" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" >
        <asp:ListItem  Text="New delivaey request" selected="True" Value="exist"  ></asp:ListItem>
        <asp:ListItem Text="view my account details" Value="noexist"></asp:ListItem>
    </asp:RadioButtonList>
    </div>
        <div>
            <fieldset>
                <legend>New delivary details</legend>
                <p1>Please enter delivary details</p1></br>
                <div >
                    <table>
                        <tr>

                <td>Pick up address* :</td>
                            <td><asp:TextBox ID="add" MaxLength="50" runat="server" ></asp:TextBox></td>
                                </tr>
                        <tr>
                <td>Recipient Address* :</td><td><asp:TextBox ID="radd" MaxLength="50" runat="server"></asp:TextBox ></td></tr>
               <tr> <td>Recipient Phone* :</td><td><asp:TextBox  ID="phone" MaxLength="50" runat="server" ></asp:TextBox></td> </tr>
               <tr> <td>Provide a description
               (list items to deliver)* :</td><td><asp:TextBox TextMode="MultiLine" ID="items" runat="server" ></asp:TextBox ></td> </tr>
                    </table>
                         <asp:Button ID="order" Text="Submit Request" runat="server" OnClick="swap"/>
                   
                </div>     
                
                
            </fieldset>
        </div>
        
    </form>
</body>
</html>
