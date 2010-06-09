<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ManagetBranch.aspx.cs" Inherits="WebAdmin_ManagetBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="width: 188px">
                &nbsp;</td>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Manager Branches" Font-Bold="True" 
                    Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                <br />
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px; height: 63px">
                </td>
            <td style="width: 92px; height: 63px">
                <asp:Label ID="Label2" runat="server" Text="Enter Name :"></asp:Label>
            </td>
            <td style="height: 63px; vertical-align: middle;">
                <asp:TextBox ID="TextBox1" runat="server" Height="20px" 
                    style="margin-left: 0px" Width="266px"></asp:TextBox>
&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Search" />
&nbsp;<asp:LinkButton ID="LinkButton1" runat="server">Advance Search</asp:LinkButton>
            </td>
            <td style="height: 63px; width: 32px;">
                </td>
            <td style="height: 63px">
                </td>
        </tr>
        <tr>
            <td style="width: 188px">
                &nbsp;</td>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" ShowFooter="True" style="text-align: center" 
                    Width="655px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="Button2" runat="server" Text="Delete" />
                            </FooterTemplate>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Pin">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("branchPin") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("branchPin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("branchName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("branchName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Address">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("branchAddress") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("branchAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Phone">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("branchPhone") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("branchPhone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button3" runat="server" Text="Add New" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Select" Text="Detail"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td style="width: 32px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 32px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 32px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 188px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="width: 32px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

