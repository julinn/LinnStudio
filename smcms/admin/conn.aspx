<%@ Page Language="C#" AutoEventWireup="true" CodeFile="conn.aspx.cs" Inherits="admin_conn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellspacing="1" class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    IP</td>
                <td>
                    <asp:TextBox ID="edtIP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    UID</td>
                <td>
                    <asp:TextBox ID="edtUID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    PWD</td>
                <td>
                    <asp:TextBox ID="edtPWd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    DB</td>
                <td>
                    <asp:TextBox ID="edtDb" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保 存" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
