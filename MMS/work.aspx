<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="work.aspx.cs" Inherits="work" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
        vertical-align:top;
    }
    .left
    {
    	width: 300px;
    	vertical-align:top;
    }
    .center
    {
    	vertical-align:top;
    }
    .right
    {
    	width: 300px;
    	vertical-align:top;
    }
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
    <tr>
        <td class="left">
            <table cellspacing="1" class="style1">
                <tr>
                    <td>
                        待结客户</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvWillPayCustomer" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td class="center">
            <table cellspacing="1" class="style1">
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel1" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td class="right">
            <table cellspacing="1" class="style2">
                <tr>
                    <td>
                        服务项目</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" Text="Button" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

