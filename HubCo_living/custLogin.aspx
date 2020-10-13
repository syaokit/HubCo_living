<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custLogin.aspx.cs" Inherits="HubCo_living.custLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Customer Login</h1>

            <table>
                <tr>
                    <th><asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label></th>
                    <td><asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <th> <asp:Label ID="lblPass" runat="server" Text="Password : "></asp:Label></th>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Login" />
        
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        
        </div>
    </form>
</body>
</html>
 