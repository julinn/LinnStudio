<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baili.aspx.cs" Inherits="baili" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>百利分红查询系统</title>
    <style type="text/css">
      .width_100{ width:100%;}
    </style>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3" 
                Height="45px">
                <asp:ListItem Value="0">未出售</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">待结算</asp:ListItem>
                <asp:ListItem Value="2">已结算</asp:ListItem>
            </asp:RadioButtonList>
            角色名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查 询" 
                onclick="btnSearch_Click" />
        </div>
        <hr />
        <div>
            <asp:Label ID="lbTotal" runat="server"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="width_100"
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Horizontal">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="FDate" HeaderText="时间" >
                    <ItemStyle Width="154px" />
                </asp:BoundField>
                <asp:BoundField DataField="Title" HeaderText="主要掉落" />
                <asp:BoundField DataField="Amount" HeaderText="红利" >
                    <ItemStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="State" HeaderText="状态" >
                    <ItemStyle Width="60px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
