<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProperty.aspx.cs" Inherits="HubCo_living.EditProperty1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .propImg{
            border:2px solid white;
            width:100px;
            height:100px;
        }
        .propImg:hover{
            border:2px solid red;
        }
        .propImg:active{
            border:2px solid red;
        }
     

    </style>

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

                    //Allow 2 decimal points
                    if ((txtlen - dotpos) > 2)
                        return false;
                }

                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Property</h2>

            <div>
                <asp:Repeater ID="imgRepeater" runat="server">
                    <ItemTemplate>
                        
                             <asp:ImageButton ImageUrl='<%# GetImage(Eval("imageContent"))  %>' runat="server" CssClass="propImg"  OnCommand="Image_Select" CommandName="ImageSelect" CommandArgument='<%# Eval("imageID") %>' ToolTip="Delete"/>
                             
                          
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                
                <br />
                <table>
                    <tr>
                        <td><asp:FileUpload ID="filUpPictures" runat="server" AllowMultiple="true"/></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnAddPhoto" runat="server" OnClick="btnAddPhoto_Click" Text="Add Photo" />
                            <asp:Label ID="lblRoomId" runat="server" Text="Label" Visible="False"></asp:Label>
                            <asp:Label ID="lblPicNum" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
                
            </div>


            <table>
                <tr>
                    <td><label>Room Name : </label></td>
                    <td><asp:TextBox ID="roomNameTxt" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><label>Address : </label></td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Postcode : </label></td>
                    <td><asp:TextBox ID="txtPostcode" runat="server" MaxLength="5" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>City : </label></td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td><label>State : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem Value="0">&lt;Select State&gt;</asp:ListItem>
                            <asp:ListItem>Johor</asp:ListItem>
                            <asp:ListItem>Kedah</asp:ListItem>
                            <asp:ListItem>Kelantan</asp:ListItem>
                            <asp:ListItem>Kuala Lumpur</asp:ListItem>
                            <asp:ListItem>Labuan</asp:ListItem>
                            <asp:ListItem>Melaka</asp:ListItem>
                            <asp:ListItem>Negeri Sembilan</asp:ListItem>
                            <asp:ListItem>Pahang</asp:ListItem>
                            <asp:ListItem>Penang</asp:ListItem>
                            <asp:ListItem>Perak</asp:ListItem>
                            <asp:ListItem>Perlis</asp:ListItem>
                            <asp:ListItem>Putrajaya</asp:ListItem>
                            <asp:ListItem>Sabah</asp:ListItem>
                            <asp:ListItem>Sarawak</asp:ListItem>
                            <asp:ListItem>Selangor</asp:ListItem>
                            <asp:ListItem>Terengganu</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                </tr>
                <tr>
                    <td><label>Room Segment : </label></td>
                    <td>
                        <asp:DropDownList ID="segmentDDL" runat="server" Width="246px">
                            <asp:ListItem>Apartment co-living</asp:ListItem>
                            <asp:ListItem>Hotel co-living</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Room Type : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="246px">
                            <asp:ListItem>Apartel</asp:ListItem>
                            <asp:ListItem>Coliving</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Room Number : </label></td>
                    <td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Room Status : </label></td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Available" GroupName="availability" Checked="true"/>
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Unavailable" GroupName="availability"/>
                    </td>
                </tr>

                <tr>
                    <td><label>Price (RM) : </label></td>
                    <td>
                         <asp:TextBox ID="priceTxt" runat="server" onkeypress="return onlyDotsAndNumbers(this,event);" ></asp:TextBox><br />
                    </td>
                </tr>

                  <tr>
                    <td><label>Bathroom : </label></td>
                    <td>
                        <asp:RadioButton ID="bathroomRB1" runat="server" Text="Private" GroupName="bathroom" Checked="true"/>
                        <asp:RadioButton ID="bathroomRB2" runat="server" Text="Shared" GroupName="bathroom"/>
                    </td>
                </tr>

                    <tr>
                    <td><label>Bathroom Quantity : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlBath" runat="server" Width="246px">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                    <tr>
                    <td><label>Bed : </label></td>
                    <td>
                         
                         <asp:DropDownList ID="bedDDL" runat="server" Width="246px">
                            <asp:ListItem>King size</asp:ListItem>
                            <asp:ListItem>Queen size</asp:ListItem>
                            <asp:ListItem>Super Single</asp:ListItem> 
                        </asp:DropDownList>
                  
                    </td>
                </tr>

                    <tr>
                    <td><label>Bed Quantity : </label></td>
                    <td>
                        <asp:DropDownList ID="ddlBed" runat="server" Width="246px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                  <tr>
                    <td><label>Bathtub : </label></td>
                    <td>
                        <asp:RadioButton ID="bathtubRB1" runat="server" Text="Yes" GroupName="Bathtub" Checked="true"/>
                        <asp:RadioButton ID="bathtubRB2" runat="server" Text="No" GroupName="Bathtub"/>
                    </td>
                </tr>

                   <tr>
                    <td><label>TV : </label></td>
                    <td>
                        <asp:RadioButton ID="tvRB1" runat="server" Text="Yes" GroupName="tv" Checked="true"/>
                        <asp:RadioButton ID="tvRB2" runat="server" Text="No" GroupName="tv"/>
                    </td>
                </tr>

                   <tr>
                    <td><label>Balcony : </label></td>
                    <td>
                        <asp:RadioButton ID="balconyRB1" runat="server" Text="Yes" GroupName="Balcony" Checked="true"/>
                        <asp:RadioButton ID="balconyRB2" runat="server" Text="No" GroupName="Balcony"/>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Button ID="btnCancel" runat="server"  Text="Back" OnClick="btnCancel_Click" />
&nbsp;
            <asp:Button ID="btnConfirm" runat="server" Text="Update" OnClick="btnConfirm_Click" />
        </div>
    </form>
</body>
</html>