<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admlogin.aspx.cs" Inherits="admin_admlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理登录</title>
    <style type="text/css">
        .style1
        {
            width: 300px;       
        }
        .title
        {
        	width:80px;
        	text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:200px;"></div>
    <div>
        <table align="center" cellspacing="1" class="style1">
            <tr>
                <td class="title">
                    账号：</td>
                <td>
                    <asp:TextBox ID="edtUserID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">
                    密码：</td>
                <td>
                    <asp:TextBox ID="edtPasswd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="title">
                    验证码：</td>
                <td>
                    <asp:TextBox ID="edtKeycode" runat="server"></asp:TextBox>
                    <asp:Label ID="lbCode" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="title">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnOk" runat="server" Text="登 录" onclick="btnOk_Click" />
&nbsp;<asp:Button ID="btnExit" runat="server" Text="取 消" onclick="btnExit_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
