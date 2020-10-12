<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custRegister.aspx.cs" Inherits="HubCo_living.custRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style> 
        table tr td{

            border:2px black solid;
        }
         
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Register</h1>
         
       <asp:Panel runat="server" ID="panel">
        <table>

            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="emailTxt" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td>Full Name</td>
                <td>
                    <asp:TextBox ID="fullNameTxt" runat="server" ></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td>Contact No</td>
                <td>
                    <asp:TextBox ID="contactNoTxt" runat="server" ></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td>Gender</td>
                <td>
         <asp:RadioButton runat="server" Text="Male" GroupName="gender"   ID ="gender1"></asp:RadioButton>
         <asp:RadioButton runat="server" Text="Female" GroupName="gender" ID="gender2"></asp:RadioButton> 
                </td>
            </tr>

              <tr>
                <td>IC Number</td>
                <td>
                    <asp:TextBox ID="icNumberTxt" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>D.O.B</td>
                <td>
                    <asp:TextBox ID="dobTxt" runat="server" TextMode="Date"></asp:TextBox>
                     
                </td>
            </tr>

            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td>Re-Enter Password</td>
                <td>
                    <asp:TextBox ID="rePasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
           </asp:Panel>
        <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click"/>
        <asp:Button ID="clearBtn" runat="server" Text="Clear"  OnClick="clearBtn_Click"/>


          
        <br />
        <asp:Label ID="errList" runat="server" Text="error"></asp:Label>
    </form>
</body>
</html>
