<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="HubCo_living.WebForm3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
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
            height:66px;
            background-color:wheat;
            border:1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                Enter your name:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
                <asp:Button ID="Button3" runat="server" Text="Cancel" />

            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                CancelControlID="Button3" PopupControlID="Panel1" TargetControlID="Label1" 
                BackgroundCssClass="modalBackground" >

            </ajaxToolkit:ModalPopupExtender>
        </div>
    </form>
</body>
</html>
