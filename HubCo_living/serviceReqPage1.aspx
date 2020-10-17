<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="serviceReqPage1.aspx.cs" Inherits="HubCo_living.serviceReqPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .txtDesc{
            height:200px;
            width:200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Service Request Page 1</h1>
        <div>
            <table>
                <tr>
                    <td>
                        Customer ID:
                    </td>
                     <td>
                         <asp:Label ID="lblCustomerID" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>
                        Booking ID:
                    </td>
                     <td>
                         <asp:Label ID="lblBookingID" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>


                   <tr>
                    <td>
                        Room Name:
                    </td>
                     <td>
                         <asp:Label ID="lblRoomName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                       <tr>
                    <td>
                        Request Type:
                    </td>
                     <td>
                         <asp:DropDownList ID="ddlRequestType" runat="server">
                             <asp:ListItem Text="Fixing"></asp:ListItem>
                             <asp:ListItem Text="Cleaning"></asp:ListItem>
                             <asp:ListItem Text="Complaints"></asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        Request Description:
                    </td>
                     <td>
                         <asp:TextBox ID="txtDesc" runat="server" CssClass="txtDesc"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click"  OnClientClick="return confirm('Confirm to make this request?');"/>
                    </td>
                     <td>
                         <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
