<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ManagetBranch.aspx.cs" Inherits="WebAdmin_ManagetBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <table style="width:100%; height: 751px;">
    <tr>
        <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Manager Branches" Font-Bold="True" 
                    Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                </td>
    </tr>
    <tr>
        <td style="vertical-align: text-top">
            <asp:Panel ID="Panel1" runat="server" GroupingText="Information Branches" 
                Height="522px" Font-Size="Medium" Width="100%">
                <table>
                <tr>
                <td>
                    <asp:Panel ID="panelSearch" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="style5" style="width: 351px">
                                <asp:Label ID="Label2" runat="server" Text="Enter Branch Name: "></asp:Label>
                                <asp:TextBox ID="txtname" runat="server" MaxLength="30"></asp:TextBox>
                                <asp:Button ID="btsearch" runat="server" onclick="btsearch_Click" 
                                    Text="Search" CausesValidation="False" />
                                &nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" Height="16px" Width="111px" 
                                    onclick="LinkButton1_Click" CausesValidation="False">Advanced Search</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                    <asp:Panel ID="PanelAdvanced" runat="server" Visible="false">
                        <asp:Label ID="Label3" runat="server" Text="Branch Name: "></asp:Label>
                        <asp:TextBox ID="txtbranchName" runat="server"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="Branch Address:"></asp:Label>
                        <asp:TextBox ID="txtbranchAddress" runat="server"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Text="Branch Phone:"></asp:Label>
                        <asp:TextBox ID="txtbranchPhone" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="btAdvancedSearch" runat="server" Text="Search" 
                            onclick="btAdvancedSearch_Click" CausesValidation="False" />
                    </asp:Panel>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowediting="GridView1_RowEditing" ShowFooter="True" Width="100%" 
                        onrowupdating="GridView1_RowUpdating" style="margin-top: 0px" 
                        onrowdeleting="GridView1_RowDeleting" PageSize="8">
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <Columns>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:Button ID="btDelete" runat="server" Text="Delete" 
                                        onclick="btDelete_Click" />
                                </FooterTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="CheckAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:CheckBox ID="checkItems" runat="server" AutoPostBack="True" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Pin">
                                <EditItemTemplate>
                                    <asp:Label ID="lbranchPin" runat="server" Text='<%# Bind("branchPin") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("branchPin") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="textbranchName" runat="server" Text='<%# Bind("branchName") %>' 
                                        Height="22px" ValidationGroup="E1" Width="113px"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="textbranchName" ErrorMessage="Name Not Null." ValidationGroup="E1"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("branchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Address">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtbranchAddress" runat="server" Text='<%# Bind("branchAddress") %>' 
                                        Height="21px" ValidationGroup="E1" Width="306px"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="txtbranchAddress" ErrorMessage="Adress Not Null" 
                                        ValidationGroup="E1"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("branchAddress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Phone">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtbranchPhone" runat="server" 
                                        Text='<%# Bind("branchPhone") %>' ValidationGroup="E1"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                        ControlToValidate="txtbranchPhone" ErrorMessage="Phone not null." 
                                        ValidationGroup="E1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="txtbranchPhone" ErrorMessage="Phone invalid" 
                                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" 
                                        ValidationGroup="E1"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("branchPhone") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="Update" ValidationGroup="E1"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Delete" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr>
                <td>
                  
                    <asp:Panel ID="AddNew" runat="server" GroupingText="Add New Information Brarch">
                      <table style="width:100%; height: 11px;">
                        <tr>
                            <td class="style5" style="width: 281px">
                                <asp:Label ID="Label6" runat="server" Text="Branch Name: "></asp:Label>
                                <asp:TextBox ID="txtbranchNameAdd" runat="server" Width="174px" 
                                    ValidationGroup="Add"></asp:TextBox>
                            </td>
                            <td style="width: 332px">
                                <asp:Label ID="Label7" runat="server" Text="Branch Address:"></asp:Label>
                                <asp:TextBox ID="txtbranchAddressAdd" runat="server" Width="209px" 
                                    ValidationGroup="Add"></asp:TextBox>
                            </td>
                            <td style="width: 265px">
                                <asp:Label ID="Label8" runat="server" Text="Branch Phone:"></asp:Label>
                                <asp:TextBox ID="txtbranchPhoneAdd" runat="server" Width="157px" 
                                    ValidationGroup="Add"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Add" runat="server" Text="Add New" onclick="Add_Click" 
                                    ValidationGroup="Add" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" style="width: 281px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtbranchNameAdd" ErrorMessage="Branch Not Null." 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 332px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtbranchAddressAdd" ErrorMessage="Branch Not Null." 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 265px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtbranchPhoneAdd" ErrorMessage="Branch Not Null." 
                                    ValidationGroup="Add"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtbranchPhoneAdd" ErrorMessage="Phone invalid" 
                                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" 
                                    ValidationGroup="Add"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        
                    </table>
                    </asp:Panel>
                  
                </td>
                </tr>
                </table>
            </asp:Panel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
  
</asp:Content>

