<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkEdit.aspx.cs" Inherits="admWorkEdit" Title="分红编辑" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 284px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="lbFlag" runat="server"></asp:Label>
    </div>
    <hr />
    <table cellspacing="1" class="master">
        <tr>
            <td class="master_Title">
                标题</td>
            <td colspan="3">
                <asp:TextBox ID="edtTitle" runat="server" Width="425px"></asp:TextBox>
                （主要掉落物品）</td>
        </tr>
        <tr>
            <td class="master_Title">
                时间</td>
            <td class="style2">
                <asp:TextBox ID="edtWorkDate" runat="server" Width="237px"></asp:TextBox>
            </td>
            <td class="master_Title">
                人数</td>
            <td>
                <asp:TextBox ID="edtCount" runat="server"></asp:TextBox>
                                    </td>
        </tr>
        <tr>
            <td class="master_Title">
                出售状态</td>
            <td class="style2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2">
                    <asp:ListItem Selected="True" Value="0">未出售</asp:ListItem>
                    <asp:ListItem Value="1">已出售</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="master_Title">
                人均分红</td>
            <td>
                <asp:TextBox ID="edtAmount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                内容</td>
            <td colspan="3">
                <asp:TextBox ID="edtContent" runat="server" Width="425px" Height="76px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                备注</td>
            <td colspan="3">
                <asp:TextBox ID="edtRemark" runat="server" Width="425px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnExit" runat="server" Text="取 消" onclick="btnExit_Click" />
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

