<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomBookingPage2.aspx.cs" Inherits="HubCo_living.roomBookingPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        table tr td{
            width:200px;
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
            <h1>Room Booking Page 2</h1>

            <h3>Location : </h3>
            <asp:Label ID="locationLbl" runat="server" Text=""></asp:Label>
            <asp:Repeater ID="rpt1" runat="server">
                <ItemTemplate>
                    
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

                   
                    <br />
                </ItemTemplate>
                
            </asp:Repeater>
           
        </div>
    </form>
</body>
</html>
