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
    .grid_100
    {
    	width:100%;
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
                        <asp:GridView ID="gvWillPayCustomer" runat="server" AutoGenerateColumns="False" 
                            CssClass="grid_100" DataKeyNames="CID" BackColor="White" 
                            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            GridLines="Vertical">
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="CNO" HeaderText="会员号" />
                                <asp:BoundField DataField="CName" HeaderText="姓名" />
                                <asp:BoundField DataField="Tel" HeaderText="手机号" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
        <td class="center">
            <table cellspacing="1" class="style1">
                <tr>
                    <td>
                        <asp:TextBox ID="edtMemstr" runat="server"></asp:TextBox>
                        <asp:Button ID="btnMemSeach" runat="server" Text="查 找" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMemInfo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="grid_100"
                            DataKeyNames="ID" BackColor="White" BorderColor="#CC9966" 
                            BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <Columns>
                                <asp:BoundField DataField="GName" HeaderText="名称" />
                                <asp:BoundField DataField="Price" HeaderText="价格" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
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
                        <asp:TextBox ID="edtGoodstr" runat="server"></asp:TextBox>
                        <asp:Button ID="btnGoodSearch" runat="server" Text="查 找" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvGoods" runat="server" CssClass="grid_100" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" 
                            BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="GName" HeaderText="名称" />
                                <asp:BoundField DataField="Price" HeaderText="价格" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

