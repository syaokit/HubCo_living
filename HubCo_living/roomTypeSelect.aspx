<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomTypeSelect.aspx.cs" Inherits="HubCo_living.roomTypeSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        form{
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Room Type Select</h1>
            <asp:Button ID="ApartelBtn" runat="server" Text="Apartel"  OnClick="ApartelBtn_Click"/> 
            <asp:Button ID="ColivingBtn" runat="server" Text="Coliving" OnClick="ColivingBtn_Click" />
        </div>
    </form>
</body>
</html>
