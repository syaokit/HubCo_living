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
             
            <table>
                <tr>
                    <td>
                        Card Name:
                    </td>
                     <td>
                         <asp:TextBox ID="cardNameTxt" runat="server"></asp:TextBox> 
                    </td>
                </tr>

                 <tr>
                    <td>
                        Card Number:
                    </td>
                     <td>
                         <asp:TextBox ID="cardNumTxt1" runat="server" ></asp:TextBox> - 
                         <asp:TextBox ID="cardNumTxt2" runat="server" ></asp:TextBox>  -
                         <asp:TextBox ID="cardNumTxt3" runat="server" ></asp:TextBox> -
                         <asp:TextBox ID="cardNumTxt4" runat="server"></asp:TextBox> 

                         <asp:CustomValidator runat="server" id="cusCustom"     onservervalidate="cusCustom_ServerValidate" errormessage="Error Card Number" />
                    </td>
                </tr>

                        <tr>
                    <td>
                        Expired Date:
                    </td>
                     <td>
                         <asp:DropDownList ID="expDDL1" runat="server"></asp:DropDownList>
                         /
                         <asp:DropDownList ID="expDDL2" runat="server"></asp:DropDownList>
                       
                    </td>
                </tr>

                    <tr>
                    <td>
                        CCV:
                    </td>
                     <td>
                         <asp:TextBox ID="ccvTxt" runat="server"></asp:TextBox> 
                    </td>
                </tr>

            </table>



            <asp:Button ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click"   />
            
        </div>
    </form>
</body>
</html>
