using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// ulMsgBox ��ժҪ˵��
/// Author: julinn
/// GitHub: https://github.com/julinn/LinnStudio
/// Webnet: www.liuju.net
/// Update: 2014-05-08 22:14:00
/// </summary>
public class ulMsgBox
{
    public ulMsgBox()
    {
        //
        //TODO: �ڴ˴���ӹ��캯���߼�
        //
    }

    /// <summary>
    /// alter��ʾ��Ϣ
    /// </summary>
    /// <param name="msgstr"></param>
    /// <returns></returns>
    public static void msgBox(string msgstr, Page page)
    {
        msgstr = msgstr.Replace("'", "��").Replace("\"", "��");
        msgstr = "<script language='javascript'>alert('" + msgstr + "')</script>";
        page.Response.Write(msgstr);
    }

    /// <summary>
    /// �滻��ѯ�������ո�or ��and �� ������(')
    /// </summary>
    /// <param name="ParaValue"></param>
    /// <returns></returns>
    public static string FmtSQLQueryParameter(string ParaValue)
    {
        return ParaValue.Replace("'", "").Replace(" or ", "").Replace(" OR ", "").Replace(" oR ", "").Replace(" Or ", "").Replace(" + ", "")
            .Replace(" and ", "").Replace(" And ", "").Replace(" aNd ", "").Replace(" anD ", "").Replace(" ANd ", "").Replace(" AnD ", "")
            .Replace(" aND ", "").Replace(" AND ", "").Replace(" ", "");
    }

    /// <summary>
    /// ���´����д�URL
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenNewUrl(string sUrl, Page page)
    {
        string s =  "<script language='javascript'>window.open('" + sUrl + "');</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// ��URL���滻ԭ��������
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenUrl(string sUrl, Page page)
    {
        string s = "<script language='javascript'>window.location='" + sUrl + "'</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// ��ModeDialog��ʽ��ҳ�Ի�����������
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenModeUrl(string sUrl, Page page)
    {
        string s =  "<script>window.showModalDialog('" + sUrl + "')</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// �򿪶Ի��򣬲���������
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenModelessUrl(string sUrl, Page page)
    {
        string s = "<script>window.showModelessDialog('" + sUrl + "')</script>";
        page.Response.Write(s);
    }
}
