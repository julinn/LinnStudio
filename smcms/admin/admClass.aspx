﻿<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admClass.aspx.cs" Inherits="admin_admClass" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                ID</td>
            <td>
                <asp:TextBox ID="edtID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Name</td>
            <td>
                <asp:TextBox ID="edtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                PID</td>
            <td>
                <asp:TextBox ID="edtPID" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
                <asp:Button ID="btnAddNavigar" runat="server" Text="加入导航" 
                    onclick="btnAddNavigar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
      
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="名称" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
      
    </div>
</asp:Content>

