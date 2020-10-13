<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custProfile.aspx.cs" Inherits="HubCo_living.custProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Profile</h1>
        <div>
            <table>
                <tr>
                    <td>Full Name :</td>
                    <td>
                        <asp:Label ID="fullNameLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>Email :</td>
                    <td>
                        <asp:Label ID="emailLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td>Contact No :</td>
                    <td>
                        <asp:Label ID="contactNo" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                  <tr>
                    <td>Gender :</td>
                    <td>
                        <asp:Label ID="genderLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                  <tr>
                    <td>D.O.B :</td>
                    <td>
                        <asp:Label ID="dobLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                  <tr>
                    <td>Password :</td>
                    <td>
                        <asp:Label ID="passwordLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

        <asp:Button ID="chgPassBtn" runat="server" Text="Change Password"  OnClick="chgPassBtn_Click"/>
        <asp:Button ID="modifyBtn" runat="server" Text="Modify Profile" OnClick="modifyBtn_Click"/> 
    </form>
</body>
</html>
