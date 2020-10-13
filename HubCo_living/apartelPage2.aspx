<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apartelPage2.aspx.cs" Inherits="HubCo_living.apartelPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        table tr td{
            border:2px black solid;
        }

        .img1{
            width:200px;
            height:200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Room Apartel Page 2</h1>


        <table>
            <tr>
                <asp:Repeater ID="rpt1" runat="server">
                    <ItemTemplate>
                        <td>
                             <asp:Image ID="img" runat="server" CssClass="img1" ImageUrl='<%# GetImage(Eval("imageContent"))  %>' />  
                        </td>
                       
                    </ItemTemplate>
                </asp:Repeater>
            </tr>

            <tr>
                <td>
                   UnitNumber :  <asp:Label ID="unitNumberLbl" runat="server" Text=""></asp:Label><br />
                   Address       :<asp:Label ID="addressLbl" runat="server" Text=""></asp:Label><br />
                   Postcode      : <asp:Label ID="postcodeLbl" runat="server" Text=""></asp:Label><br />
                   City              :<asp:Label ID="cityLbl" runat="server" Text=""></asp:Label><br />
                   State           :<asp:Label ID="stateLbl" runat="server" Text=""></asp:Label><br /> 
                   Status          :<asp:Label ID="statusLbl" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
