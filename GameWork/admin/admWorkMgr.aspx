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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="标题" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="金额" />
                    <asp:BoundField DataField="Count" HeaderText="人数" />
                    <asp:BoundField DataField="Amount" HeaderText="人均" />
                    <asp:BoundField DataField="WorkDate" HeaderText="日期" />
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

