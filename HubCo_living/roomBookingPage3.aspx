<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomBookingPage3.aspx.cs" Inherits="HubCo_living.roomBookingPage3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        table tr td {
            border: 2px black solid;
        }

        .img1 {
            width: 200px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Room Apartel Page 3</h1>


        <table>
            <tr>
                <asp:Repeater ID="rpt1" runat="server">
                    <ItemTemplate>
                        <td>
                            <asp:Image ID="img" runat="server" CssClass="img1" ImageUrl='<%#GetImage(Eval("imageContent"))  %>' />
                        </td>

                    </ItemTemplate>
                </asp:Repeater>
            </tr>

            <tr>
                <td>UnitNumber : 
                    <asp:Label ID="unitNumberLbl" runat="server" Text=""></asp:Label><br />
                    Address       :<asp:Label ID="addressLbl" runat="server" Text=""></asp:Label><br />
                    Postcode      :
                    <asp:Label ID="postcodeLbl" runat="server" Text=""></asp:Label><br />
                    City              :<asp:Label ID="cityLbl" runat="server" Text=""></asp:Label><br />
                    State           :<asp:Label ID="stateLbl" runat="server" Text=""></asp:Label><br />
                    Status          :<asp:Label ID="statusLbl" runat="server" Text=""></asp:Label><br />
                    Price          :<asp:Label ID="priceLbl" runat="server" Text=""></asp:Label>
                </td>

                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="calendar" runat="server" OnDayRender="calendar_DayRender" OnSelectionChanged="calendar_SelectionChanged" SelectionMode="Day"></asp:Calendar>

                            <br />
                            Start date : 
                            <asp:Label ID="startDateLbl" runat="server" Text=""></asp:Label><br />
                            Duration         : 
                            <asp:TextBox ID="durationTxt" runat="server" TextMode="Number" OnTextChanged="durationTxt_TextChanged" AutoPostBack="true" Width="100px"></asp:TextBox><br />
                            End Date        :  
                            <asp:Label ID="endDateLbl" runat="server" Text="" Enabled="false"></asp:Label><br />
                             Result           :  
                            <asp:Label ID="resultLbl" runat="server" Text="" Enabled="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>

            </tr>


        </table>
        <asp:Button ID="proceedBtn" runat="server" Text="Proceed" OnClick="proceedBtn_Click" />


    </form>
</body>
</html>
