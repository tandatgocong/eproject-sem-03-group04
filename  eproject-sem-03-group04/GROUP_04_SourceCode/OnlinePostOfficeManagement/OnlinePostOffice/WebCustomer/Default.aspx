<%@ Page Title="" Language="C#" MasterPageFile="~/WebCustomer/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebCustomer_Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td colspan="3">
                <img src="../image/tmpxoa.JPG" style="width: 986px; height: 254px" /></td>
        </tr>
        <tr>
            <td style="width: 71px">
                <img src="../image/tmpxoa2.JPG" style="width: 361px; height: 272px" />&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server" 
                    PostBackUrl="~/WebCustomer/Default.aspx">LinkButton</asp:LinkButton>
            </td>
            <td>
                <img src="../image/tmpxoa3.JPG" style="width: 361px; height: 272px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 71px">
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

