<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admLogin.aspx.cs" Inherits="admin_admLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <style type="text/css">
        .style1
        {
            width: 300px;
        }
        .right{ text-align:right;}
        .w_100{ width:100px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:200px;">
    
    </div>
    <table align="center" cellspacing="1" class="style1">
        <tr>
            <td class="right w_100">
                账号</td>
            <td>
                <asp:TextBox ID="edtUID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="right w_100">
                密码</td>
            <td>
                <asp:TextBox ID="edtPwd" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="right w_100">
                验证码</td>
            <td>
                <asp:TextBox ID="edtCode" runat="server" Width="51px"></asp:TextBox>
                <asp:Label ID="lbCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="登 录" onclick="btnLogin_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取 消" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lbMsg" runat="server" ></asp:Label>
            </td>
        </tr>
        </table>
    </form>
    </body>
</html>
