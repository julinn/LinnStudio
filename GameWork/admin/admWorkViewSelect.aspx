<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkViewSelect.aspx.cs" Inherits="admin_admWorkViewSelect" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div></div>
<hr />

    <table cellspacing="1" class="master">
        <tr>
            <td>
                <asp:Button ID="btnOk" runat="server" Text="确 定" onclick="btnOk_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UName" HeaderText="角色名" />
                        <asp:BoundField DataField="Profession" HeaderText="职业" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>

