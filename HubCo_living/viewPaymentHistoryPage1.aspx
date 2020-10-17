<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPaymentHistoryPage1.aspx.cs" Inherits="HubCo_living.viewPaymentHistoryPage1" %>

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
        <h1>View Payment History Page 1</h1>
        <h3>Total Payment: RM <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></h3>
            <div>
            <table>
                <tr>
                    <td class="td1">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <asp:Repeater ID="rpt1" runat="server">
                                        <ItemTemplate>
                                            <tr class="tr1">
                                                <td>
                                                    <label>Payment ID : </label>
                                                    <asp:Label ID="lblPaymentID" runat="server" Text='<%#Eval("paymentID").ToString() %>' />
                                                  
                                                </td>

                                                <td>
                                                    <asp:HiddenField ID="hdfPaymentID" runat="server" Value='<%# Eval("paymentID") %>'/>
                                                    <asp:Button ID="viewBtn" runat="server" Text="View" OnClick="viewBtn_Click"  />
                                                </td>
                                            </tr>

                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>

                    <td class="td2">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>


                                <label>Payment ID : </label>
                                <asp:Label ID="lblPaymentID2" runat="server" Text="" />

                                <br />
                                <label>Payment Date. : </label>
                                <asp:Label ID="lblPaymentDate" runat="server" Text="" />

                                <br />
                                <label>Booking ID    : </label>
                                <asp:Label ID="lblBookingID" runat="server" Text="" />

                                <br />
                                <label>Room Name    : </label>
                                <asp:Label ID="lblRoomName" runat="server" Text="" />

                                <br />
                                <label>Payment Details    : </label>
                                <asp:Label ID="lblPayemntDetails" runat="server" Text="" />  

                                <br />
                                <label>Payment Amount    : </label>
                                <asp:Label ID="lblPaymentAmount" runat="server" Text="" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
