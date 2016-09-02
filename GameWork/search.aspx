<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
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
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3" 
                Height="45px" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Value="0">待审核</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">待结算</asp:ListItem>
                <asp:ListItem Value="2">已结算</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox ID="edtName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查 询" 
                onclick="btnSearch_Click" />
            <br />
            <asp:Label ID="lbTotal" runat="server"></asp:Label>
        <hr />
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="width100">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="FDate" HeaderText="时间" />
                <asp:BoundField DataField="Title" HeaderText="标题" />
                <asp:BoundField DataField="Amount" HeaderText="金额" />
                <asp:BoundField DataField="State" HeaderText="状态" />
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
