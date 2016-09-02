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
                onclick="btnAddNew_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="edtstr" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查 询" onclick="btnSearch_Click" />
&nbsp;日期范围：<asp:TextBox ID="edtFrom" runat="server"></asp:TextBox>
            至 
            <asp:TextBox ID="edtTo" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="FDate" HeaderText="日期" />
                    <asp:BoundField DataField="Title" HeaderText="标题" />
                    <asp:BoundField DataField="Amount" HeaderText="人均" />
                    <asp:BoundField DataField="SellState" HeaderText="出售状态" />
                    <asp:BoundField DataField="AuditState" HeaderText="审核状态" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
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

