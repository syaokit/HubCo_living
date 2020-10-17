<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomBookingPage4.aspx.cs" Inherits="HubCo_living.roomBookingPage4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .txtBox{
            width:80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Room Bookoing Page 4</h1>
        <div>
            <h3>
                <asp:Label ID="amountLbl" runat="server" Text=""></asp:Label>
            </h3>
            <table>
                <tr>
                    <td>Card Name:
                    </td>
                    <td>
                        <asp:TextBox ID="cardNameTxt" runat="server" CssClass="txtBox"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ForeColor="Red" ControlToValidate="cardNameTxt" ></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Card Number:
                    </td>
                    <td>
                        <asp:TextBox ID="cardNumTxt1" runat="server"  CssClass="txtBox"></asp:TextBox>
                        - 
                         <asp:TextBox ID="cardNumTxt2" runat="server"  CssClass="txtBox"></asp:TextBox>
                        -
                         <asp:TextBox ID="cardNumTxt3" runat="server"  CssClass="txtBox"></asp:TextBox>
                        -
                         <asp:TextBox ID="cardNumTxt4" runat="server" CssClass="txtBox"></asp:TextBox>

                        <asp:CustomValidator runat="server" ID="cusCustom3" Display="Dynamic" OnServerValidate="cusCustom3_ServerValidate" Text="*" ForeColor="Red" />

                        <asp:CustomValidator runat="server" ID="cusCustom1" Display="None" OnServerValidate="cusCustom_ServerValidate" ErrorMessage="Error Card Number" />
                    </td>
                </tr>

                <tr>
                    <td>Expired Date:
                    </td>
                    <td>
                        <asp:DropDownList ID="expDDL1" runat="server"></asp:DropDownList>
                        /
                         <asp:DropDownList ID="expDDL2" runat="server"></asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <td>CCV:
                    </td>
                    <td>
                        <asp:TextBox ID="ccvTxt" runat="server" CssClass="txtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*" ForeColor="Red" ControlToValidate="ccvTxt"></asp:RequiredFieldValidator>

                        <asp:CustomValidator runat="server" ID="cusCustom2" Display="None" OnServerValidate="cusCustom2_ServerValidate" ErrorMessage="Error CCV Number" />
                    </td>
                </tr>

            </table>



            <asp:Button ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click"  />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" DisplayMode="BulletList" />
        </div>
    </form>
</body>
</html>
