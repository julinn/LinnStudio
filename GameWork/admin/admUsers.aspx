<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admUsers.aspx.cs" Inherits="admin_admUsers" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .title
        {
        	width:80px;
        	text-align:right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEdit" runat="server">
                    <table cellspacing="1" class="style1">
                        <tr>
                            <td class="title">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="title">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="title">
                                角色名：</td>
                            <td>
                                <asp:TextBox ID="edtName" runat="server"></asp:TextBox>
                            </td>
                            <td class="title">
                                职业：</td>
                            <td>
                                <asp:DropDownList ID="ddlProfession" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="title">
                                等级：</td>
                            <td>
                                <asp:TextBox ID="edtLevel" runat="server"></asp:TextBox>
                            </td>
                            <td class="title">
                                手机号：</td>
                            <td>
                                <asp:TextBox ID="edtTel" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="title">
                                QQ：</td>
                            <td>
                                <asp:TextBox ID="edtQQ" runat="server"></asp:TextBox>
                            </td>
                            <td class="title">
                                备注：</td>
                            <td>
                                <asp:TextBox ID="edtRemark" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:Button ID="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                    Text="取 消" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:Label ID="lbMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="edtStr" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                    Text="查 询" />
            &nbsp;<asp:Button ID="btnAddNewUser" runat="server" onclick="btnAddNewUser_Click" 
                    Text="增加新成员" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" DataKeyNames="ID" GridLines="Horizontal" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" CssClass="style1">
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="UName" HeaderText="角色名" />
                        <asp:BoundField DataField="Profession" HeaderText="职业" />
                        <asp:BoundField DataField="Level" HeaderText="等级" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

