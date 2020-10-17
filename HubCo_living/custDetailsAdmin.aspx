<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custDetailsAdmin.aspx.cs" Inherits="HubCo_living.custDetailsAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
            function onlyDotsAndNumbers(txt, event) {
                var charCode = (event.which) ? event.which : event.keyCode
                if (charCode == 46) {
                    if (txt.value.indexOf(".") < 0)
                        return true;
                    else
                        return false;
                }

                if (txt.value.indexOf(".") > 0) {
                    var txtlen = txt.value.length;
                    var dotpos = txt.value.indexOf(".");
                    //Change the number here to allow more decimal points than 2
                    if ((txtlen - dotpos) > 2)
                        return false;
                }

                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }
    </script>
    <style>
        table td{
            text-align:left;
            width:200px;
        }
        .view{
            margin-left:20px;
        }

        .modalBackground{
            background-color:black;
            filter:alpha(opacity=90) !important;
            opacity: 0.6 !important;
            z-index:20;
        }

        .modalpopup{
            padding: 20px 0px 24px 10px;
            position:relative;
            width:450px;
            height:280px;
            background-color:white;
            border:1px solid black;
        }

        .modalpopup2{
            padding: 20px 0px 24px 10px;
            position:relative;
            width:450px;
            height:180px;
            background-color:white;
            border:1px solid black;
        }

        .search{
            margin-left:800px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Customer Details</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>Customer ID :</td>
                    <td># <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Full Name :</td>
                    <td><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Email :</td>
                    <td><asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Contact No. :</td>
                    <td><asp:Label ID="lblContact" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Gender :</td>
                    <td ><asp:Label ID="lblGender" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>IC Number :</td>
                    <td><asp:Label ID="lblIC" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Date of Birth :</td>
                    <td ><asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label></td>
                </tr>
               
            </table>
            <br />
        </div>

        <h3>Pending Requests</h3>
        <asp:Label id="lblPendingText" runat="server" Text="No. of Pending Requests: "></asp:Label><asp:Label ID="lblPending" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="serviceReqID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="serviceReqID" HeaderText="serviceReqID" InsertVisible="False" ReadOnly="True" SortExpression="serviceReqID" />
                <asp:BoundField DataField="roomID" HeaderText="roomID" SortExpression="roomID" />
                <asp:BoundField DataField="requestType" HeaderText="requestType" SortExpression="requestType" />
                <asp:BoundField DataField="requestDate" HeaderText="requestDate" SortExpression="requestDate" />
                <asp:BoundField DataField="actions" HeaderText="actions" SortExpression="actions" />
            </Columns>
        </asp:GridView>
        <br />

        <br />
        <h3>Previous Service Records</h3>
        <div class="search">
            <label>Search Room ID : </label>
            <asp:TextBox ID="txtSearch" runat="server" Text="" ></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  />
        </div>
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="serviceRecordID" HeaderText="serviceRecordID" InsertVisible="False" ReadOnly="True" SortExpression="serviceRecordID" />
                <asp:BoundField DataField="serviceReqID" HeaderText="serviceReqID" SortExpression="serviceReqID" />
                <asp:BoundField DataField="Request Type" HeaderText="Request Type" SortExpression="Request Type" />
                <asp:BoundField DataField="Request Descripion" HeaderText="Request Descripion" SortExpression="Request Descripion" />
                <asp:BoundField DataField="Request Date" HeaderText="Request Date" SortExpression="Request Date" />
                <asp:BoundField DataField="Actions Done" HeaderText="Actions Done" SortExpression="Actions Done" />
                <asp:BoundField DataField="Date Completed" HeaderText="Date Completed" ReadOnly="True" SortExpression="Date Completed" />
                <asp:BoundField DataField="Time Completed" HeaderText="Time Completed" SortExpression="Time Completed" />
                <asp:BoundField DataField="Room ID" HeaderText="Room ID" ReadOnly="True" SortExpression="Room ID" InsertVisible="False" />
                <asp:BoundField DataField="Room Address" HeaderText="Room Address" ReadOnly="True" SortExpression="Room Address" />
                <asp:BoundField DataField="Cost (RM)" HeaderText="Cost (RM)" SortExpression="Cost (RM)" />
            </Columns>
        </asp:GridView>

        

        
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="pnlRequests" runat="server" CssClass="modalpopup">
            <b><label>Service Requests Details</label></b>
            <br />
            <table>
                <tr>
                    <td>Service Request ID : </td>
                    <td><asp:Label ID="lblReqID" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Room ID : </td>
                    <td><asp:Label ID="lblRoomID" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Unit No. : </td>
                    <td><asp:Label ID="lblUnit" runat="server" Text="Label"></asp:Label></td>
                </tr>
                
                <tr>
                    <td>Room Address : </td>
                    <td><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Request Type : </td>
                    <td><asp:Label ID="lblReqType" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Request Date : </td>
                    <td><asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Description : </td>
                    <td><asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Action : </td>
                    <td>
                        <ajaxToolkit:ComboBox ID="cbAction" runat="server" DropDownStyle="DropDownList" >
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>In Process</asp:ListItem>
                            <asp:ListItem>Complete</asp:ListItem>
                        </ajaxToolkit:ComboBox>
                    </td>
                </tr>
            </table>
            
            <br />
            <asp:Button ID="btnBack" runat="server" Text="Cancel"/>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="mpeRequests" runat="server" CancelControlID="btnBack" 
             PopupControlID="pnlRequests" TargetControlID="lblReqID" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>


        <asp:Panel ID="pnlComplete" runat="server" CssClass="modalpopup2">
             <b><label>Additional Service Details</label></b>
            <table>
                <tr>
                    <td>Service Request ID : </td>
                    <td><asp:Label ID="lblReqID2" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td>Service Details : </td>
                    <td><asp:TextBox ID="txtServiceDetails" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Service Cost : </td>
                    <td>RM <asp:TextBox ID="txtCost" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);"></asp:TextBox></td>
                </tr>
            </table>

            <asp:Button ID="btnBack2" runat="server" Text="Cancel" />
            <asp:Button ID="btnUpdate2" runat="server" Text="Confirm" OnClick="btnUpdate2_Click"  />
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mpeComplete" runat="server" CancelControlID="btnBack2" 
             PopupControlID="pnlComplete" TargetControlID="lblReqID2" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select a.serviceRecordID, a.serviceReqID, b.requestType as 'Request Type',  b.descriptions as 'Request Descripion', b.requestDate as 'Request Date', a.description as 'Actions Done', format(a.date, 'dd-MM-yyyy') as 'Date Completed', a.time as 'Time Completed', 
       c.roomID as 'Room ID', concat(c.unitNumber,', ',address, ', ', c.city , ', ', c.postcode ,', ', c.state) as 'Room Address', a.cost as 'Cost (RM)'
from serviceRecords a, serviceRequests b, Rooms c
where a.serviceReqID = b.serviceReqID and a.roomID=c.roomID and b.roomID=c.roomID and b.customerID=10002"></asp:SqlDataSource>

    </form>
</body>
</html>
