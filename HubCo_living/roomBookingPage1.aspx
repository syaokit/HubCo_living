<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomBookingPage1.aspx.cs" Inherits="HubCo_living.roomBookingPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Room Booking Page 1</h1>

            <table>
                <tr>
                    <td>
                        Location
                    </td>
                    <td>
                        <asp:TextBox ID="locationTxt" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        Room Type
                    </td>
                    <td>
                        <asp:DropDownList ID="roomTypeDdl" runat="server">
                            <asp:ListItem Value="Apartel" Text="Apartel"></asp:ListItem>
                            <asp:ListItem Value="Coliving" Text="Coliving"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

            <asp:Button ID="searchBtn" runat="server" Text="Search"  OnClick="searchBtn_Click"/> 
            
        </div>
    </form>
</body>
</html>
