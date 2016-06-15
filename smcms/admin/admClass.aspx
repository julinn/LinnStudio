<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admClass.aspx.cs" Inherits="admin_admClass" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <asp:Button ID="btnAdd" runat="server" Text="添加分类" onclick="btnAdd_Click" />
    </div>
    <asp:Panel runat="server" ID="pnlEidt">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lbFlag" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text_right width_100">
                ID</td>
            <td>
                <asp:TextBox ID="edtID" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="text_right width_100">
                名称</td>
            <td>
                <asp:TextBox ID="edtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="保 存" />
                &nbsp;<asp:Button ID="btnAddNavigar" runat="server" onclick="btnAddNavigar_Click" 
                    Text="加入导航" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                
            </td>
        </tr>
    </table>
   </asp:Panel>
    <div>      
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="560px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID">
                            <ItemStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="名称" />
                        <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Width="40px" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
    </div>
</asp:Content>

