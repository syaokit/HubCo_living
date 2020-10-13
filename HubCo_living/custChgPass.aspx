<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custChgPass.aspx.cs" Inherits="HubCo_living.custChgPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Change Password</h1>
        <div>
            <table>
                <tr>
                    <td>Old Password</td>
                    <td>
                         <asp:TextBox ID="oldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                   
                </tr>

                 <tr>
                    <td>New Password</td>
                    <td>
                         <asp:TextBox ID="newPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                   
                </tr>

                 <tr>
                    <td>Re-enter New Password</td>
                    <td>
                         <asp:TextBox ID="renewPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                   
                </tr>
            </table>

            <asp:Label ID="errList" runat="server" Text=""></asp:Label><br />

            <asp:Button ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click" />
            <asp:Button ID="clearBtn" runat="server" Text="Clear" OnClick="clearBtn_Click" />
        </div>
    </form>
</body>
</html>
