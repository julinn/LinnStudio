<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admArticleList.aspx.cs" Inherits="admin_admArticleList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="edtStr" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查 询" 
                    onclick="btnSearch_Click" />
            &nbsp;<asp:Button ID="btnNew" runat="server" Text="添加文章" onclick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="style1" 
                    DataKeyNames="ID" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowdeleting="GridView1_RowDeleting" AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
<asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="标题" />
                        <asp:BoundField DataField="FDate" HeaderText="日期" />
                        <asp:CommandField ShowSelectButton="True" >
                            <ItemStyle Width="50px" />
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True">
                            <ItemStyle Width="50px" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

