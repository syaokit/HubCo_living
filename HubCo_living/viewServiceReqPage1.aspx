<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewServiceReqPage1.aspx.cs" Inherits="HubCo_living.viewServiceReqPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .td1 {
            border: 2px solid red;
        }

        .td2 {
            width: 300px;
            border: 2px solid blue;
        }

        .tr1 td {
            border: 2px solid yellow;
        }

        .tr2 td {
            border: 2px solid lightgreen;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>View Service Request Page 1</h1>

        <table>
            <tr>
                <td class="td1">Unhandle Request
                </td>
                <td class="td2">Handled Request
                </td>
            </tr>
            <tr>
                <td class="td1">

                    <table>
                        <asp:Repeater ID="rpt1" runat="server">
                            <ItemTemplate>
                                <tr class="tr1">
                                    <td>
                                        <label>Service Request ID : </label>
                                        <asp:Label ID="lblServiceReqID" runat="server" Text='<%#Eval("serviceReqID").ToString() %>' />

                                        <br />
                                        <label>Room ID. : </label>
                                        <asp:Label ID="lblRoomID" runat="server" Text='<%#Eval("roomID").ToString() %>' />

                                        <br />
                                        <label>Room Name    : </label>
                                        <asp:Label ID="lblRoomName" runat="server" Text='<%#Eval("roomName") %>' />

                                        <br />
                                        <label>Request Type    : </label>
                                        <asp:Label ID="lblReqType" runat="server" Text='<%#Eval("requestType") %>' />

                                        <br />
                                        <label>Request Date    : </label>
                                        <asp:Label ID="lblReqDate" runat="server" Text='<%#Eval("requestDate", "{0:dd/M/yyyy}") %>' />

                                        <br />
                                        <label>Status    : </label>
                                        <asp:Label ID="lblAction" runat="server" Text='<%#Eval("actions") %>' />

                                    </td>


                                    <td>
                                        <asp:HiddenField ID="hdfserviceReqID" runat="server" Value='<%# Eval("serviceReqID") %>' />
                                        
                                        <asp:Button ID="delBtn" runat="server" Text="Delete" OnClick="delBtn_Click" OnClientClick="return confirm('Confirm to delete request?');" />
                                    </td>
                                </tr>

                                <br />
                            </ItemTemplate>

                        </asp:Repeater>
                    </table>

                </td>

                <td class="td2">

                    <table>
                        <asp:Repeater ID="rpt2" runat="server">
                            <ItemTemplate>
                                <tr class="tr2">
                                    <td>
                                        <label>Service Record ID : </label>
                                        <asp:Label ID="lblServiceRecord" runat="server" Text='<%#Eval("serviceRecordID").ToString() %>' />

                                        <br />
                                        <label>Service Request ID : </label>
                                        <asp:Label ID="lblServiceReqID2" runat="server" Text='<%#Eval("serviceReqID").ToString() %>' />

                                        <br />
                                        <label>Room ID. : </label>
                                        <asp:Label ID="lblRoomID2" runat="server" Text='<%#Eval("roomID").ToString() %>' />

                                        <br />
                                        <label>Room Name    : </label>
                                        <asp:Label ID="lblRoomName2" runat="server" Text='<%#Eval("roomName") %>' />

                                        <br />
                                        <label>Request Type    : </label>
                                        <asp:Label ID="lblReqType2" runat="server" Text='<%#Eval("requestType") %>' />

                                        <br />
                                        <label>Service Date    : </label>
                                        <asp:Label ID="lblServiceDate" runat="server" Text='<%#Eval("date","{0:dd/M/yyyy}") %>' />

                                        <br />
                                        <label>Service Time    : </label>
                                        <asp:Label ID="lblServiceTime" runat="server" Text='<%#Eval("time") %>' />

                                        <br />
                                        <label>Service Cost    : </label>
                                        <asp:Label ID="lblServiceCost" runat="server" Text='<%#Eval("cost") %>' />

                                    </td>
                                </tr>

                                <br />
                            </ItemTemplate>

                        </asp:Repeater>
                    </table>
                </td>
            </tr>

        </table>
    </form>
</body>
</html>
