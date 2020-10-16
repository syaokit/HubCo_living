<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewBookingPage1.aspx.cs" Inherits="HubCo_living.viewBookingPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <style>
        .td1 {
            border: 2px solid red;
        }

        .td2 {
            border: 2px solid blue;
        }

        .tr1 td {
            border: 2px solid yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>View Booking Page 1</h1>

        <div>
            <table>
                <tr>
                    <td class="td1">

                        <table>
                            <asp:Repeater ID="rpt1" runat="server">
                                <ItemTemplate>
                                    <tr class="tr1">
                                        <td>
                                            <label>Booking ID : </label>
                                            <asp:Label ID="lblBookingID" runat="server" Text='<%#Eval("bookingID").ToString() %>' />

                                            <br />
                                            <label>Booking Date. : </label>
                                            <asp:Label ID="lblBookingDate" runat="server" Text='<%#Eval("bookingDate", "{0:dd/M/yyyy}")%>' />

                                            <br />
                                            <label>Room Name    : </label>
                                            <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("roomName") %>' />

                                        </td>

                                        <td>
                                            <asp:HiddenField ID="hdfBookingID" runat="server" Value='<%# Eval("bookingID") %>' />
                                            <asp:Button ID="viewBtn" runat="server" Text="View" OnClick="viewBtn_Click" />
                                        </td>

                                        <td>
                                            <asp:HiddenField ID="hdfBookingID2" runat="server" Value='<%# Eval("bookingID") %>' />
                                            <asp:HiddenField ID="hdfPaymentID" runat="server" Value='<%# Eval("paymentID") %>' />
                                            <asp:Button ID="delBtn" runat="server" Text="Delete" OnClick="delBtn_Click" OnClientClick="return confirm('Confirm to delete record?');" />
                                        </td>
                                    </tr>

                                    <br />
                                </ItemTemplate>

                            </asp:Repeater>
                        </table>

                    </td>

                    <td class="td2">



                        <label>Booking ID : </label>
                        <asp:Label ID="lblBookingID2" runat="server" Text="" />

                        <br />
                        <label>Booking Date. : </label>
                        <asp:Label ID="lblBookingDate2" runat="server" Text="" />

                        <br />
                        <label>Room Name    : </label>
                        <asp:Label ID="lblRoomName2" runat="server" Text="" />

                        <br />
                        <label>Start Date    : </label>
                        <asp:Label ID="lblStartDate" runat="server" Text="" />

                        <br />
                        <label>End Date    : </label>
                        <asp:Label ID="lblEndDate" runat="server" Text="" />

                        <br />
                        <label>Payment Amount    : </label>
                        <asp:Label ID="lblPaymentAmount" runat="server" Text="" />

                         <br /> <br />
                       
                        <asp:Button ID="reqBtn" runat="server" Text="Make Request" OnClick="reqBtn_Click" OnClientClick="return confirm('Confirm to make request?');" Enabled="false" />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
