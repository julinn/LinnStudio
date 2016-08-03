<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkEdit.aspx.cs" Inherits="admWorkEdit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                日期</td>
            <td>
                <asp:TextBox ID="edtWorkDate" runat="server"></asp:TextBox>
            </td>
            <td class="master_Title">
                人数</td>
            <td>
                <asp:TextBox ID="edtCount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                人均</td>
            <td>
                <asp:TextBox ID="edtAmount" runat="server"></asp:TextBox>
            </td>
            <td class="master_Title">
                总金额</td>
            <td>
                <asp:TextBox ID="edtTotal" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                内容</td>
            <td colspan="3">
                <asp:TextBox ID="edtContent" runat="server" Width="425px"></asp:TextBox>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

