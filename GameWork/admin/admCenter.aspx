<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admCenter.aspx.cs" Inherits="admin_admCenter" Title="管理总览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                最近登录情况：
                <hr /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FDate" HeaderText="时间" />
                        <asp:BoundField DataField="Content" HeaderText="说明" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

