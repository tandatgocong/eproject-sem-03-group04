<%@ Page Title="" Language="C#" MasterPageFile="~/WebCustomer/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="CustomerRegister.aspx.cs" Inherits="WebCustomer_CustomerRegister" %>
<%@ Register assembly="MSCaptcha" namespace="MSCaptcha" tagprefix="cc1" %>
<%@ Register src="../CalendarControl.ascx" tagname="CalendarControl" tagprefix="uc1" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:Panel ID="Panel33" runat="server">
         <table style="width:100%;">
        <tr>
            <td style="width: 211px">
                &nbsp;</td>
            <td style="width: 597px">
                <table bgcolor="#FFFFCC" style="width: 100%;">
                    <tr>
                        <td bgcolor="#FF9900" colspan="3">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                                ForeColor="Blue" Text="Account Registration"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            Cùi Bấp<asp:ValidationSummary ID="ValidationSummary2" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                ValidationGroup="r4" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" bgcolor="#FF9900">&nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="Account Information" 
                                Font-Bold="True" Font-Italic="True" ForeColor="White"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td style="text-align: right; width: 145px;">
                                        <asp:Label ID="Label6" runat="server" Text="Email Address: "></asp:Label>&nbsp;
                                    &nbsp;</td>
                                    <td style="vertical-align: text-top; width: 200px;">
                                        <asp:TextBox ID="txtemail" runat="server" Width="215px"></asp:TextBox>
                                        <br />
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtemail" ErrorMessage="Email Address is  not blank.">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txtemail" ErrorMessage="Invalid Email Address" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                            ControlToValidate="txtemail" ErrorMessage="Email is not blank." 
                                            ValidationGroup="r4">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                            ControlToValidate="txtemail" ErrorMessage="Invalid Email Address" 
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                            ValidationGroup="r4">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 145px;">
                                        &nbsp;</td>
                                    <td style="vertical-align: text-top; width: 200px;">
                                        <asp:Button ID="btcheck" runat="server" Height="24px" 
                                            Text="Check availability!" Width="127px" onclick="btcheck_Click" 
                                            ValidationGroup="r4" />
                                        <br />
                                        <asp:Label ID="lbcheck" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 145px; height: 26px;">
                                        <asp:Label ID="Label7" runat="server" Text="Password: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 200px; height: 26px;">
                                        <asp:TextBox ID="txtpass" runat="server" Width="215px" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td style="height: 26px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtpass" ErrorMessage="Password is not blank.">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 145px;">
                                        <asp:Label ID="Label8" runat="server" Text="Confirm password: " 
                                            style="text-align: right"></asp:Label>
                                    &nbsp;</td>
                                    <td style="width: 200px">
                                        <asp:TextBox ID="txtcomfirmpass" runat="server" Width="215px" 
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtpass" ControlToValidate="txtcomfirmpass" 
                                            ErrorMessage="Confirm password must be the same password.">*</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" bgcolor="#FF9900">&nbsp;&nbsp;
                            <asp:Label ID="Label5" runat="server" Text="Personal Information" 
                                Font-Bold="True" Font-Italic="True" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table style="width:116%;">
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        <asp:Label ID="Label9" runat="server" Text="First Name: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 183px">
                                        <asp:TextBox ID="txtfirstName" runat="server" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtfirstName" ErrorMessage="First Name is not blank">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        <asp:Label ID="Label10" runat="server" Text="Last Name: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 183px">
                                        <asp:TextBox ID="txtlastname" runat="server" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="txtlastname" ErrorMessage="Last Name is not blank.">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px; vertical-align: text-top;">
                                        <asp:Label ID="Label11" runat="server" Text="Birthday: "></asp:Label>&nbsp;
                                    </td>
                                    <td colspan="2">
                                        <uc1:CalendarControl ID="CalendarControl2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px; vertical-align: text-top;">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        <asp:Label ID="Label18" runat="server" Font-Italic="True" Font-Size="12px" 
                                            Text="Ex: MM/DD/YYYY"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        <asp:Label ID="Label12" runat="server" Text="Sex: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 183px">
                                        <asp:RadioButton ID="rbMale" runat="server" Checked="True" Text="Male" />
                                        <asp:RadioButton ID="rbfemale" runat="server" Text="Female" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        <asp:Label ID="Label13" runat="server" Text="Address: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 183px">
                                        <asp:TextBox ID="txtaddress" runat="server" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ErrorMessage="Address is not blank" ControlToValidate="txtaddress">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        <asp:Label ID="Label14" runat="server" Text="Phone: "></asp:Label>&nbsp;
                                    </td>
                                    <td style="width: 183px">
                                        <asp:TextBox ID="txtPhone" runat="server" Width="215px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="txtPhone" ErrorMessage="Phone is not blank">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="txtPhone" ErrorMessage="Invalid Phone Number" 
                                            ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 146px;">
                                        &nbsp;</td>
                                    <td style="width: 183px">
                                        <asp:Label ID="Label17" runat="server" Font-Italic="True" Font-Size="12px" 
                                            Text="Ex: 123-456-7890 or (123) 456- 7890"></asp:Label>
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
                    <td colspan="3" bgcolor="#FF9900">&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Word Verification" 
                                Font-Bold="True" Font-Italic="True" ForeColor="White"></asp:Label>
                        </td>  
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table style="width: 97%;">
                                <tr>
                                    <td style="width: 143px">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        <asp:Label ID="Label16" runat="server" 
                                            Text="Type the characters you see in the picture below." Font-Italic="True" 
                                            ForeColor="Blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 143px">
                                        &nbsp;</td>
                                    <td style="width: 176px">
                                        <cc1:CaptchaControl ID="Captcha" runat="server" 
                                            ToolTip="If you can not read this code, please refresh (F5) the browser to get new code." 
                                            Width="212px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" 
                                            Text="If you can not read this code, please refresh (F5) the browser to get new code." 
                                            Font-Italic="True" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 143px; height: 23px;">
                                        &nbsp;</td>
                                    <td style="width: 176px; height: 23px;">
                                        <asp:TextBox ID="txtcode" runat="server" Width="215px"></asp:TextBox>
                                    </td>
                                    <td style="height: 23px">
                                        <asp:Label ID="lblCodeResult" runat="server" Font-Italic="False" 
                                            Font-Size="10pt" ForeColor="Red"></asp:Label>
                                        </td>
                                </tr>
                                </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#FFCC66" 
                                 Text="Create Account" ToolTip="Submit" 
                                Width="116px" Font-Bold="True" ForeColor="Red" BorderColor="Blue" 
                                BorderStyle="Dotted" BorderWidth="1px" Height="25px" 
                                onclick="btnSubmit_Click" />
                        &nbsp;<asp:Button ID="btnSubmit0" runat="server" BackColor="#FFCC66" 
                                 Text="Clear" ToolTip="Submit" 
                                Width="116px" Height="25px" Font-Bold="True" ForeColor="Red" 
                                BorderColor="Blue" BorderStyle="Dotted" 
                                BorderWidth="1px" CausesValidation="False" onclick="btnSubmit0_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
      </asp:Panel>
   <asp:Panel ID="Panel34" runat="server" Visible="False">
      <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 722px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 722px">
                    <span 
                        style="border-collapse: separate; color: rgb(102, 102, 102); font-family: Verdana; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                    <span  style="font-size: 13px; ">
                    <h2 style="padding-top: 0px; padding-right: 0px; padding-bottom: 6px; padding-left: 0px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(153, 153, 153); margin-top: 0px; margin-right: 0px; margin-bottom: 8px; margin-left: 0px; line-height: 24px; font-size: 24px; color: rgb(51, 51, 51); font-family: Arial, Helvetica; ">
                        Thanks !.</h2>
                    <h2 style="padding-top: 0px; padding-right: 0px; padding-bottom: 6px; padding-left: 0px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(153, 153, 153); margin-top: 0px; margin-right: 0px; margin-bottom: 8px; margin-left: 0px; line-height: 24px; font-size: 24px; color: rgb(51, 51, 51); font-family: Arial, Helvetica; ">
                        You are create new account successfully, please login to use our services</h2>
                    <div 
                        style="padding-top: 0px; padding-right: 3px; padding-bottom: 15px; padding-left: 3px; font-size: 12px; overflow-x: hidden; overflow-y: hidden; ">
                        Tt </div>
                    </span></span>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 722px; text-align: center;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
   </asp:Panel>

</asp:Content>

