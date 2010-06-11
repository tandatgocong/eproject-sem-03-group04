<%@ Page Title="" Language="C#" MasterPageFile="~/WebCustomer/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="CustomerFeedback.aspx.cs" Inherits="WebCustomer_CustomerFeedback" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%; height: 593px;">
        <tr>
            <td style="width: 172px">
                &nbsp;</td>
            <td style="width: 632px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                &nbsp;</td>
            <td style="width: 632px">
                <table bgcolor="#FFFFCC" style="width: 107%; margin-left: 0px; height: 545px;">
                    <tr>
                        <td colspan="6" bgcolor="#FF9900" style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                                ForeColor="Blue" style="text-align: center" Text="FEEDBACK &amp; CONTACT"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px; text-align: right;">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px; text-align: right;">
                            <asp:Label ID="Label4" runat="server" Text="Name:"></asp:Label>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px; text-align: right;">
                            <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px; text-align: right;">
                            <asp:Label ID="Label6" runat="server" Text="Address:"></asp:Label>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px; text-align: right;">
                            <asp:Label ID="Label7" runat="server" Text="Phone:"></asp:Label>&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtphone" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px; height: 26px;">
                            </td>
                        <td style="width: 67px; text-align: right; height: 26px;">
                            <asp:Label ID="Label8" runat="server" Text="Subject:"></asp:Label>&nbsp;
                        </td>
                        <td style="height: 26px">
                            <asp:TextBox ID="txtsubject" runat="server" Width="230px"></asp:TextBox>
                        </td>
                        <td style="height: 26px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            </td>
                        <td style="width: 67px; text-align: right;">
                            <asp:Label ID="Label9" runat="server" Text="Content:"></asp:Label>&nbsp;
                        </td>
                        <td rowspan="3">
                            
                            <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="~/fckeditor/" runat="server" Height="300">
                            </FCKeditorV2:FCKeditor>
                            
                        </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px; height: 253px">
                            </td>
                        <td style="height: 253px; width: 67px">
                            </td>
                        <td style="height: 253px">
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 9px">
                            &nbsp;</td>
                        <td style="width: 67px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#FFCC66" 
                                 Text="Submit" ToolTip="Submit" 
                                Width="116px" Font-Bold="True" ForeColor="Red" BorderColor="Blue" 
                                BorderStyle="Dotted" BorderWidth="1px" Height="25px" 
                                />&nbsp;&nbsp;
                            <asp:Button ID="btnSubmit0" runat="server" BackColor="#FFCC66" 
                                 Text="Clear" ToolTip="Submit" 
                                Width="116px" Height="25px" Font-Bold="True" ForeColor="Red" 
                                BorderColor="Blue" BorderStyle="Dotted" 
                                BorderWidth="1px" CausesValidation="False"  />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                &nbsp;</td>
            <td style="width: 632px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

