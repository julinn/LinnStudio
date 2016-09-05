<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkMgr.aspx.cs" Inherits="admin_admWorkMgr" Title="分红管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="master">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAddNew" runat="server" Text="新建分红单" 
                onclick="btnAddNew_Click" TabIndex="1" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="edtstr" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查 询" onclick="btnSearch_Click" />
            &nbsp;
            <asp:CheckBox ID="chkUserDate" runat="server" Text="使用日期条件检索" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellspacing="1" class="style1">
                <tr>
                    <td style="text-align:right; width:100px;">
                        日期范围：</td>
                    <td>
                        <asp:TextBox ID="edtFrom" runat="server"></asp:TextBox>
            至<asp:TextBox ID="edtTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:100px;">
                        出售状态：</td>
                    <td>
                        <asp:RadioButtonList ID="rblSellFlag" runat="server" RepeatColumns="3">
                            <asp:ListItem Selected="True" Value="2">全部</asp:ListItem>
                            <asp:ListItem Value="0">未出售</asp:ListItem>
                            <asp:ListItem Value="1">已出售</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; width:100px;">
                        审核状态：</td>
                    <td>
                        <asp:RadioButtonList ID="rblAutidFlag" runat="server" RepeatColumns="3">
                            <asp:ListItem Selected="True" Value="2">全部</asp:ListItem>
                            <asp:ListItem Value="0">未审核</asp:ListItem>
                            <asp:ListItem Value="1">已审核</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" GridLines="Horizontal">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <Columns>
                    <asp:BoundField DataField="FDate" HeaderText="日期" />
                    <asp:BoundField DataField="Title" HeaderText="标题" />
                    <asp:BoundField DataField="Amount" HeaderText="人均" />
                    <asp:BoundField DataField="SellState" HeaderText="出售状态" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
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
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

