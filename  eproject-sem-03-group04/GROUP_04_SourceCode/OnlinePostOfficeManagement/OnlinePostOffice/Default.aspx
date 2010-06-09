<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 21px;
            width: 36px;
        }
        .style4
        {
            width: 36px;
        }
        .style5
        {
            height: 23px;
            width: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Trang chính ko design mà dùn để link tới các trang còn lại<br />
    </div>
    <table style="width:100%;">
        <tr>
            <td colspan="3" style="text-align: center">
                DEMO MO HINH 3 LOP</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" Width="693px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView2" runat="server" Width="693px">
                </asp:GridView>
         
    <fckeditor id="FCKeditor1" runat="server" basepath="~/fckeditor/" 
        height="400px" width="800px">
    </fckeditor>
   </td>
        </tr>
    </table>
    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" BasePath="~/fckeditor/">
    </FCKeditorV2:FCKeditor>
    </form>
</body>
</html>
