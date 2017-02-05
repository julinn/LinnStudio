<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admCenter.aspx.cs" Inherits="admin_admCenter" Title="管理总览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 384px;
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                成员总数：<br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        未售记录：<br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        待结人数：<br />
                待结金额：<br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        已结人数：<br />
                已结金额：</td>
        </tr>
        <tr>
            <td>
                <hr /></td>
        </tr>
        <tr>
            <td>
                <table cellspacing="1" class="style1">
                    <tr>
                        <td class="style2">
                            最近登录情况：</td>
                        <td>
                            最近成员变更：</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FDate" HeaderText="时间" />
                        <asp:BoundField DataField="Content" HeaderText="说明" />
                    </Columns>
                </asp:GridView>
                        </td>
                        <td class="style2">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FDate" HeaderText="时间" />
                        <asp:BoundField DataField="Content" HeaderText="说明" />
                    </Columns>
                </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

