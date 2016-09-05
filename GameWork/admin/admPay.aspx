<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admPay.aspx.cs" Inherits="admin_admPay" Title="结算管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 243px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
&nbsp;<table cellspacing="1" class="style1">
                    <tr>
                        <td class="style2">
                <asp:TextBox ID="edtStr" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="查 询" 
                                onclick="btnSearch_Click" />
                        </td>
                        <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="2">
                    <asp:ListItem Value="1" Selected="True">待结算</asp:ListItem>
                    <asp:ListItem Value="2">已结算</asp:ListItem>
                </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            <hr />
                </td>
        </tr>
        <tr>
            <td>
                角色信息：<asp:Label ID="lbinfo" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                合计金额：<asp:Label ID="lbTotal" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                结算备注：<asp:TextBox ID="edtRemark" runat="server" Width="354px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <hr /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPay" runat="server" Text="结 算" Width="122px"  
                    OnClientClick ="return confirm('请仔细核对信息，结算后会改变账单状态，且不能撤销，确定要结算吗？');" 
                    onclick="btnPay_Click" />
                <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" GridLines="Horizontal" DataKeyNames="ID">
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="FDate" HeaderText="日期" />
                        <asp:BoundField DataField="Title" HeaderText="主题" />
                        <asp:BoundField DataField="Amount" HeaderText="金额" />
                        <asp:BoundField DataField="State" HeaderText="状态" />
                        <asp:BoundField DataField="PayTime" HeaderText="结算时间" />
                        <asp:HyperLinkField DataNavigateUrlFields="Url" Target="_blank" Text="活动详情" />
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
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
</asp:Content>

