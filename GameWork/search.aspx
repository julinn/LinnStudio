<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询</title>
    <style type="text/css">
        .width100
        {
            width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">    
        角色名：<asp:TextBox ID="edtStr" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查 询" onclick="Button1_Click" />
        <hr />
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="width100">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="WorkDate" HeaderText="时间" />
                <asp:BoundField DataField="Title" HeaderText="标题" />
                <asp:BoundField DataField="Amount" HeaderText="金额" />
                <asp:BoundField DataField="StatusName" HeaderText="状态" />
                <asp:BoundField DataField="PayTime" HeaderText="结算时间" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
