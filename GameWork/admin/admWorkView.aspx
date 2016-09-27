<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkView.aspx.cs" Inherits="admWorkView" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 336px;
        }
        .style3
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    </div>
    
    <table cellspacing="1" class="master">
        <tr>
            <td class="master_Title">
                主题：</td>
            <td colspan="3">
                <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                日期：</td>
            <td class="style2">
                <asp:Label ID="lbWorkDate" runat="server" Text=""></asp:Label>
            </td>
            <td class="master_Title">
                人数：</td>
            <td>
                <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
                                    </td>
        </tr>
        <tr>
            <td class="master_Title">
                人均：</td>
            <td class="style2">
                <asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                内容：</td>
            <td colspan="3">
                <asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                备注：</td>
            <td colspan="3">
                <asp:Label ID="lbRemark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Button ID="btnAddMore" runat="server" Text="批量添加成员" 
                    onclick="btnAddMore_Click" />
            &nbsp;<asp:Button ID="btnEdit" runat="server" Text="修改分红单" 
                    onclick="btnEdit_Click" />
&nbsp;<asp:Button ID="btnAudit" runat="server" Text="审核分红单" OnClientClick ="return confirm('分红单审核以后将不可修改或变更，确定要审核吗？');" onclick="btnAudit_Click" />
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3" class="style3">
                注：分红单审核以后不能再修改或变更，请仔细核对无误后再审核。</td>
        </tr>
        <tr>
            <td class="master_Title">
                成员列表：</td>
            <td colspan="3">
                <asp:Label ID="lbUsers" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    
    <hr />
    <div>
    已选人数：
     
        <asp:Label ID="lbselectCount" runat="server" Text=""></asp:Label>
    </div>
    <hr />
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID,MemID" onrowdeleting="GridView1_RowDeleting" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical">
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="UName" HeaderText="角色名" />
            <asp:BoundField DataField="Profession" HeaderText="职业" />
            <asp:BoundField DataField="PayState" HeaderText="结算状态" />
            <asp:BoundField DataField="PayTime" HeaderText="结算时间" />
            <asp:BoundField DataField="PayRemark" HeaderText="结算备注" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
                </asp:GridView>
    </div>    
    <hr />
    <div>日志记录</div>
    <hr />
    <div>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Horizontal" Width="740px">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="FDate" HeaderText="时间">
                    <ItemStyle Width="160px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserID" HeaderText="用户">
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="Content" HeaderText="修改变动">
                    <ItemStyle Width="500px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    
    </div>
    
</asp:Content>

