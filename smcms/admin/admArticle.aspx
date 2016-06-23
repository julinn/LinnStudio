<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admArticle.aspx.cs" Inherits="admin_admArticle" Title="文章编辑" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../nicEdit/nicEdit.js" type="text/javascript"></script>
    <script type="text/javascript">
        bkLib.onDomLoaded(function() {
        new nicEditor({ fullPanel: true }).panelInstance('ctl00_ContentPlaceHolder1_txtContent');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="1" class="style1">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <table cellspacing="1" class="style1">
                        <tr>
                            <td>
                                <asp:Label ID="lbFlag" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                标题：<asp:TextBox ID="edtTitle" runat="server" Width="542px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                类别：<asp:DropDownList ID="ddlClass" runat="server" Width="138px">
                                </asp:DropDownList>
                                &nbsp;<asp:CheckBox ID="chkIstop" runat="server" Text="置顶" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtContent" runat="server" Height="200px" TextMode="MultiLine" 
                                    Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="保 存" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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

