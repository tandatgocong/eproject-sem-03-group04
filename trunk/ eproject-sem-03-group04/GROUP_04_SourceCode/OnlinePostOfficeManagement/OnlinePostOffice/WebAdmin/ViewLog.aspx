<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ViewLog.aspx.cs" Inherits="WebAdmin_ViewLog" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%@ Register src="../CalendarControl.ascx" tagname="CalendarControl" tagprefix="uc1" %>
    <table style="width: 100%;vertical-align: text-top;">
    <tr>
    <td>
    
        <table style="width:83%;">
            <tr>
                <td style="width: 90px; vertical-align: text-top;">
                    <asp:Label ID="Label2" runat="server" Text="Choose Date:"></asp:Label>
                </td>
                <td style="width: 147px">
                   <table style="width:100%;" border="0">
    <tr>
        <td class="style4" style="width: 102px">
<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td>
        <td class="style1" style="vertical-align: top; ">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" 
                ImageUrl="~/image/Calendar.png" onclick="ImageButton1_Click" Width="22px" />
        </td>
    </tr>
    <tr>
        <td class="style3" colspan="2">
            <asp:Calendar ID="Calendar" runat="server" 
    onselectionchanged="Calendar_SelectionChanged" Visible="False" 
    BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
    ForeColor="#663399" Height="160px" ShowGridLines="True" Width="122px">
    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
    <SelectorStyle BackColor="#FFCC66" />
    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#CC9966" />
    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
        ForeColor="#FFFFCC" />
</asp:Calendar>
        </td>
        
    </tr>
</table></td>
                <td  style="vertical-align: top; width: 64px;">
                    <asp:Button ID="btDate" runat="server" Text="View Log" onclick="btDate_Click" />
                </td>
                <td style="width: 166px; vertical-align: text-top;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Enter UserName :"></asp:Label>
&nbsp;</td>
                <td style="vertical-align: text-top; width: 119px;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td style="vertical-align: top">
                    <asp:Button ID="btUserName" runat="server" Text="View Log" 
                        onclick="btUserName_Click" />
                </td>
            </tr>            
        </table>
    
    </td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" 
                    Width="100%">
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                </asp:GridView></td>
    </tr>
    </table>
  
</asp:Content>

