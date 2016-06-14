<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admArticle.aspx.cs" Inherits="admin_admArticle" Title="无标题页" ValidateRequest="false" %>

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
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="200px" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
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

