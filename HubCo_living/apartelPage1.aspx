<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apartelPage1.aspx.cs" Inherits="HubCo_living.apartelPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table tr td{
            border:2px black solid;
        }

        .img1{
            width:100px;
            height:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Room Apartel Page 1</h1>

            <asp:Repeater ID="rpt1" runat="server">
                <ItemTemplate>
                    <div style="border:1px solid #ff0000 ; display:inline-block ; width:70%">
                        <table>
                            <tr>
                                <td colspan="2">

                                    <asp:ImageButton ID="propImage" CssClass="img1" runat="server" ImageUrl='<%# GetImage(Eval("imageContent"))  %>'  />
                                    
                                </td>
                                <td>
                                    <label>Address : </label>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("address").ToString() + ", " + Eval("postcode").ToString() + " " + Eval("city").ToString() + ", " + Eval("state").ToString()%>' />
                                   
                                    <br />
                                    <label>Unit No. : </label>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("unitNumber") %>' />

                                    <br />
                                    <label>Type    : </label>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("roomType") %>' />

                                    <br />
                                    <label>Status : </label>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status") %>' />

                                </td>
                                
                                <td>
                                     
                                <asp:Button ID="viewBtn" runat="server" Text="View" OnCommand="viewBtn_Click" CommandArgument='<%# Eval("roomID") %>'/>
                                </td>
                            </tr>
                        </table>

                    </div>
                    <br />
                </ItemTemplate>
                
            </asp:Repeater>
           
        </div>
    </form>
</body>
</html>
