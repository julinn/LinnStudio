<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admWorkView.aspx.cs" Inherits="admWorkView" Title="�ޱ���ҳ" %>

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
                ���⣺</td>
            <td colspan="3">
                <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                ���ڣ�</td>
            <td class="style2">
                <asp:Label ID="lbWorkDate" runat="server" Text=""></asp:Label>
            </td>
            <td class="master_Title">
                ������</td>
            <td>
                <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
                                    </td>
        </tr>
        <tr>
            <td class="master_Title">
                �˾���</td>
            <td class="style2">
                <asp:Label ID="lbAmount" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                ���ݣ�</td>
            <td colspan="3">
                <asp:Label ID="lbContent" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                ��ע��</td>
            <td colspan="3">
                <asp:Label ID="lbRemark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3">
                <asp:Button ID="btnAddMore" runat="server" Text="������ӳ�Ա" 
                    onclick="btnAddMore_Click" />
            &nbsp;<asp:Button ID="btnEdit" runat="server" Text="�޸ķֺ쵥" 
                    onclick="btnEdit_Click" />
&nbsp;<asp:Button ID="btnAudit" runat="server" Text="��˷ֺ쵥" OnClientClick ="return confirm('�ֺ쵥����Ժ󽫲����޸Ļ�����ȷ��Ҫ�����');" onclick="btnAudit_Click" />
            </td>
        </tr>
        <tr>
            <td class="master_Title">
                &nbsp;</td>
            <td colspan="3" class="style3">
                ע���ֺ쵥����Ժ������޸Ļ���������ϸ�˶����������ˡ�</td>
        </tr>
        <tr>
            <td class="master_Title">
                ��Ա�б�</td>
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
    ��ѡ������
     
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
            <asp:BoundField DataField="UName" HeaderText="��ɫ��" />
            <asp:BoundField DataField="Profession" HeaderText="ְҵ" />
            <asp:BoundField DataField="PayState" HeaderText="����״̬" />
            <asp:BoundField DataField="PayTime" HeaderText="����ʱ��" />
            <asp:BoundField DataField="PayRemark" HeaderText="���㱸ע" />
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
    <div>��־��¼</div>
    <hr />
    <div>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Horizontal" Width="740px">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="FDate" HeaderText="ʱ��">
                    <ItemStyle Width="160px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserID" HeaderText="�û�">
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="Content" HeaderText="�޸ı䶯">
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

