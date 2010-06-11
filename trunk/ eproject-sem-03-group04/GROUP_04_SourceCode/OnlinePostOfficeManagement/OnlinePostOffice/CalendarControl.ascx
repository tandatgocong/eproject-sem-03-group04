<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarControl.ascx.cs" Inherits="CalendarControl" %>

<script language="javascript" type="text/javascript">
// <!CDATA[

   function valid(source,args)
    {
       var dateOfB = new Date(args.Value);
       var now = new Date();
       if(now.getFullYear()-dateOfB.getFullYear() < 18)
            args.IsValid = false;
       else
            args.IsValid = true;
    }

    dtFormat = 'MM/DD/YYYY'

    function chkDate(source, args) {
        udt = args.Value;
        if (udt.indexOf("/") == -1) {
          //  alert('Not a valid date, format ' + dtFormat);
           // document.frm.mdt.focus();
            //  return false;
            args.IsValid = false;
        }
        dt1 = udt.split("/")
        mm1 = parseInt(dt1[0]);
        dd1 = parseInt(dt1[1]);
        yy1 = parseInt(dt1[2]);
        if (isNaN(dd1) || isNaN(mm1) || isNaN(yy1)) {
            args.IsValid = false;
        }
        dt2 = new Date(mm1 + '/' + dd1 + '/' + yy1)
        dd2 = dt2.getDate();
        mm2 = dt2.getMonth() + 1;
        yy2 = dt2.getFullYear();

        //alert(dd1+'/'+mm1+'/'+yy1);
        //alert(dd2+'/'+mm2+'/'+yy2);
        if (dd1 == dd2 && mm1 == mm2 && yy1 == yy2)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
// ]]>
</script>

<style type="text/css">
    .style1
    {
        height: 8px;
        width: 28px;
    }
    .style3
    {
        width: 80px;
    }
    .style4
    {
        width: 29px;
    }
</style>
<table style="width:24%;" border="0">
    <tr>
        <td class="style4">
            <asp:TextBox ID="txtDate" runat="server" Width="183px"></asp:TextBox>
        </td>
        <td class="style1" style="vertical-align: middle; ">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" 
                ImageUrl="~/image/Calendar.png" onclick="ImageButton1_Click" Width="22px" 
                CausesValidation="False" />       
            </td>
        <td>
            <asp:CustomValidator ID="CustomValidator2" runat="server" 
                ClientValidationFunction="chkDate" ControlToValidate="txtDate" 
                ErrorMessage="Invalid Date">*</asp:CustomValidator>
        </td>
        <td>
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                ErrorMessage="Must be greater than 18 years old" 
                ClientValidationFunction="valid" ControlToValidate="txtDate">*</asp:CustomValidator>
            </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtDate" ErrorMessage="Date is not blank">*</asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td class="style3" colspan="2">
            <asp:Calendar ID="Calendar" runat="server" 
    onselectionchanged="Calendar_SelectionChanged" Visible="False" 
    BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
    ForeColor="#663399" Height="160px" ShowGridLines="True" Width="185px" 
                SelectedDate="1980-06-11">
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
</table>


