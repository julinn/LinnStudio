<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="bill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>活动详情</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
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
                    日期：<asp:Label ID="lbDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    主题：<asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    内容：<asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    人数：<asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    红利：<asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    备注：<asp:Label ID="lbRemark" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <hr />
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbList" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
