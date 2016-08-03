<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkView.aspx.cs" Inherits="admWorkView" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    </div>
    
    <table cellspacing="1" class="master">
        <tr>
            <td class="master_Title">
                主题：</td>
            <td colspan="3">
                <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                日期：</td>
            <td>
                <asp:Label ID="lbWorkDate" runat="server" Text=""></asp:Label>
            </td>
            <td class="master_Title">
                人数：</td>
            <td>
                <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
                                    </td>
        </tr>
        <tr>
            <td class="master_Title">
                人均：</td>
            <td>
                <asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
            </td>
            <td class="master_Title">
                总金额：</td>
            <td>
                <asp:Label ID="lbTotal" runat="server" Text=""></asp:Label>
                                    </td>
        </tr>
        <tr>
            <td class="master_Title">
                内容：</td>
            <td colspan="3">
                <asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                备注：</td>
            <td colspan="3">
                <asp:Label ID="lbRemark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Button ID="btnAddMore" runat="server" Text="批量添加用户" 
                    onclick="btnAddMore_Click" />
            </td>
        </tr>
    </table>
    
    <hr />
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" onrowdeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="UName" HeaderText="角色名" />
            <asp:BoundField DataField="Profession" HeaderText="职业" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
                </asp:GridView>
    </div>    
    
</asp:Content>

