<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="WebAdmin_AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 632px" >
        <tr>
            <td 
                
                
                style="background-image: url('../../image/tmnbg.jpg'); color: #0000CC; font-size: xx-large; text-align: center; height: 59px; width: 123px;">
                </td>
            <td colspan="3" 
                
                
                style="background-image: url('../../image/tmnbg.jpg'); color: #0000CC; font-size: xx-large; text-align: center; height: 59px;">
                Add Employee</td>
        </tr>
        <tr>
            <td style="width: 123px; height: 23px">
                &nbsp;</td>
            <td style="width: 137px; height: 23px">
                Email</td>
            <td style="height: 23px; width: 165px;">
                <asp:TextBox ID="TextBox1" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="height: 23px; color: #FF3300; width: 36px;">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Password</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox2" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
               
                &nbsp;</td>
            <td style="width: 137px">
               
                Re-enter password</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox9" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Fist Name</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox3" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Last Name</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox4" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Birthday</td>
            <td style="width: 165px; vertical-align: middle;">
                <asp:TextBox ID="TextBox8" runat="server" Width="115px" ></asp:TextBox> &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server"  
                    ImageUrl="~/image/Calendar.png" Width="27px" />
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px; height: 25px;">
                &nbsp;</td>
            <td style="width: 137px; height: 25px;">
                Sex</td>
            <td class="style4" style="width: 165px">
                <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" />
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" />
            </td>
            <td style="height: 25px; color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Address</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox6" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px">
                &nbsp;</td>
            <td style="width: 137px">
                Phone</td>
            <td style="width: 165px">
                <asp:TextBox ID="TextBox7" runat="server" Width="228px"></asp:TextBox>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px; vertical-align: text-top;">
                &nbsp;</td>
            <td style="width: 137px; vertical-align: text-top;">
                Image</td>
            <td style="width: 165px">
                <asp:Image ID="Image1" runat="server" Height="120px" Width="120px" />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="224px" />
            </td>
            <td style="color: #FF3300; width: 36px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 123px; vertical-align: text-top;">
                &nbsp;</td>
            <td style="width: 137px; vertical-align: text-top;">
                Role</td>
            <td style="width: 165px">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Administrator</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px; vertical-align: text-top;">
                &nbsp;</td>
            <td style="width: 137px; vertical-align: text-top;">
                Office</td>
            <td style="width: 165px">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>New York</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="color: #FF3300; width: 36px">
                *</td>
        </tr>
        <tr>
            <td style="width: 123px; height: 58px;">
                </td>
            <td style="height: 58px; text-align: center;" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Add" Width="80px"  />
&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Clear" Width="87px" />
                
            </td>
            <td style="width: 36px; height: 58px;">
                </td>
        </tr>
    </table>
</asp:Content>

