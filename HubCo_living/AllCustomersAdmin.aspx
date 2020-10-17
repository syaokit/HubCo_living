<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllCustomersAdmin.aspx.cs" Inherits="HubCo_living.AllCustomersAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .dataTable{
            border:1px groove black;
            border-collapse: collapse;
            width:265px;
        }

        .dataTable th{
            font-size:large;
            color:green;
           text-align:left;
           padding-left:15px;
           padding-bottom:10px;
           padding-top:5px;
           padding-right:15px;
        }
        
        .search{
            margin-left:800px;
        }

        .labels{
            padding-left:15px;
            padding-right:15px;
        }
        .labels_last{
            padding-left:15px;
            padding-bottom:10px;
            
        }
        .buttons{
            margin-left:15px;
            margin-bottom:5px;
            width:235px
        }
        .items{
            padding-right:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>All Customers</h2>
        </div>
        <div class="search">
            <label>Search: </label>
            <asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            
        </div>
        <br />
        <div>

            <asp:DataList ID="DataList1" runat="server" DataKeyField="customerID" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="5">
                <ItemTemplate>
                        <asp:Label id="lblID" runat="server" Text='<%# Eval("customerID") %>' Visible="false"/>
                    <table class="dataTable" >
                        <tr>
                            <th colspan="2">
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("fullName") %>' />
                                <br />
                            </th>
                        </tr>
                        <tr>
                            <td class="labels">
                                Email: 
                            </td>
                            <td class="items">
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">
                                Contact No:
                            </td>
                            <td class="items">
                                <asp:Label ID="lblContact" runat="server" Text='<%# Eval("contactNo") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="labels_last">
                                Unhandled Req:
                            </td>
                            <td class="items">
                                <b><asp:Label ID="lblReq" runat="server" Text='<%# Eval("unhandled_request") %>' /></b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button Id="btnView" runat="server" Text="View"  OnCommand="btnView_Click" CommandArgument='<%# Eval("customerID") %>' CssClass="buttons"/>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </div>
    </form>
</body>
</html>
