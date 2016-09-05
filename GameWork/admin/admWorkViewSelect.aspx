<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkViewSelect.aspx.cs" Inherits="admin_admWorkViewSelect" Title="参与人员选择" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div></div>
<hr />
    <table cellspacing="1" class="master">
        <tr>
            <td>
                当前已选：</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbUsers" runat="server" Text=""></asp:Label>
&nbsp;<hr /></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                <asp:TextBox ID="edtSearch" runat="server" onfocus="javascript:this.select()" ></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查 询" onclick="btnSearch_Click" />
&nbsp;<asp:Button ID="btnOk" runat="server" Text="添加当前所选成员" onclick="btnOk_Click" />
            &nbsp;<asp:Button ID="btnReurn" runat="server" Text="返回分红单" 
                    onclick="btnReurn_Click" />
            </asp:Panel>
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

