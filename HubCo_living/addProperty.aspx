<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProperty.aspx.cs" Inherits="HubCo_living.addProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
            <asp:Label ID="title" runat="server" Text="Add Property" Font-Bold="True" Font-Size="X-Large"></asp:Label>  
    </div>

    <form id="form1" runat="server">
       
        <div>
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
                        <asp:DropDownList ID="typeDDL" runat="server" Width="246px">
                            <asp:ListItem>Small Room</asp:ListItem>
                            <asp:ListItem>Medium Room</asp:ListItem>
                            <asp:ListItem>Large Room</asp:ListItem>
                            <asp:ListItem>Mini Studio</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Room Number : </label></td>
                    <td><asp:TextBox ID="txtNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Images : </label></td>
                    <td><asp:FileUpload ID="filUpPictures" runat="server" AllowMultiple="true"/>
        
                    </td>
                </tr>
                <tr>
                    <td><label>Room Status : </label></td>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Available" GroupName="availability" Checked="true"/>
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Unavailable" GroupName="availability"/>
                    </td>
                </tr> 
                  
                  <tr>
                    <td><label>Price : </label></td>
                    <td>
                         <asp:TextBox ID="priceTxt" runat="server" TextMode="Number"></asp:TextBox>
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
                        <asp:TextBox ID="bathroomQtyTxt" runat="server" TextMode="Number" min="0"></asp:TextBox>
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
                        <asp:TextBox ID="bedQtyTxt" runat="server" TextMode="Number" min="0"></asp:TextBox>
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

        </div>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
    </form>
</body></html>
