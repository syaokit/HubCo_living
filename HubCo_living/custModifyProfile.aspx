<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custModifyProfile.aspx.cs" Inherits="HubCo_living.custModifyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Modify Profile</h1>
       <div>
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
                    <asp:TextBox ID="dobTxt" runat="server" TextMode="Date" ></asp:TextBox>
                     
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
