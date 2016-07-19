<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admSetting.aspx.cs" Inherits="admin_admSetting" Title="设置" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:100%">
    <div>
     导航栏设置
     <hr />
     <asp:TextBox ID="edtNavigar" runat="server" TextMode="MultiLine" Height="64px" 
            Width="549px"></asp:TextBox>     
        <br />
        <asp:Button ID="btnNavigarSave" runat="server" Text="确 定" 
            onclick="btnNavigarSave_Click" />     
    </div>
</div>
</asp:Content>

