<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custEventPage1.aspx.cs" Inherits="HubCo_living.custEventPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .td1 {
            border: 2px solid red;
        }

        .td2 {
            width:300px;
            border: 2px solid blue;
        }

        .td3 {
            border: 2px solid purple;
        }

        .tr1 td {
            border: 2px solid yellow;
        }

        .table1 {
            border: 2px solid lightgreen;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Customer Events Page 1</h1>
        <div>
            <table>
                <tr>
                    <td class="td1">Calendar</td>
                    <td class="td2">Available events</td>
                    <td class="td3">Create events</td>
                </tr>
                <tr>
                    <td class="td1">
                        <asp:Calendar ID="calendar" runat="server" OnDayRender="calendar_DayRender" OnSelectionChanged="calendar_SelectionChanged" SelectionMode="Day"></asp:Calendar>
                    </td>

                    <td class="td2">

                        <asp:Repeater ID="rpt1" runat="server">
                            <ItemTemplate>
                                <table class="table1">
                                    <tr>
                                        <td>Event Name  :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEventName" runat="server" Text='<%#Eval("eventName")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Creator  :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCreator" runat="server" Text='<%#Eval("creator")  %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Date  :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("date","{0:dd/M/yyyy}")  %>'></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Time  :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTime" runat="server" Text='<%#Eval("time")  %>'></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Event Content  :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblContent" runat="server" Text='<%#Eval("content")  %>'></asp:Label>
                                        </td>
                                    </tr>


                                </table>

                            </ItemTemplate>
                        </asp:Repeater>
                    </td>

                    <td class="td3">

                        <table>
                            <tr>
                                <td>Event Name  :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEventName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Creator  :
                                </td>
                                <td>
                                    <asp:Label ID="lblCreator2" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Date  :
                                </td>
                                <td>
                                    <asp:Label ID="lblDate2" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>Time  :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTime" runat="server" TextMode="Time"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>Event Content  :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContent" runat="server" Width="200px" Height="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtContent"></asp:RequiredFieldValidator>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" />
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
