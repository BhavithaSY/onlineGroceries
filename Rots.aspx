<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rots.aspx.cs" Inherits="Rots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" Interval="2000" runat="server"></asp:Timer>
        <asp:UpdatePanel ID="up" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/Transportadd.xml" />
            </ContentTemplate>
        </asp:UpdatePanel>
        
    
    </div>
    </form>
</body>
</html>
