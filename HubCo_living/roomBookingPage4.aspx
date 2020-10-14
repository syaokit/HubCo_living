<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomBookingPage4.aspx.cs" Inherits="HubCo_living.roomBookingPage4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Room Bookoing Page 4</h1>
        <div>                             
           
             
            <asp:Calendar ID="calendar" runat="server"  OnDayRender="calendar_DayRender" OnSelectionChanged="calendar_SelectionChanged" SelectionMode="Day"></asp:Calendar>
            <asp:Label ID="dateLbl" runat="server" Text=""></asp:Label>
                  
        </div>
    </form>
</body>
</html>
