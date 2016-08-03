<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:200px; text-align:center; vertical-align:middle;">
        
    </div>
    <div style="height:100px; text-align:center; vertical-align:middle;">
        <asp:Label ID="lbGuildName" runat="server" Font-Size="X-Large"></asp:Label>
    </div>
    
    <div id="search" style="text-align:center; vertical-align:middle;">
    角色名：<asp:TextBox ID="edtstr" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch"
        runat="server" Text="查 询" onclick="btnSearch_Click" />
    </div>
    </form>
</body>
</html>
