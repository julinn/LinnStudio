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
///ulMsgBox 的摘要说明
/// </summary>
public class ulMsgBox
{
    public ulMsgBox()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// alter提示信息
    /// </summary>
    /// <param name="msgstr"></param>
    /// <returns></returns>
    public static void msgBox(string msgstr, Page page)
    {
        msgstr = msgstr.Replace("'", "＇").Replace("\"", "＂");
        msgstr = "<script language='javascript'>alert('" + msgstr + "')</script>";
        page.Response.Write(msgstr);
    }

    /// <summary>
    /// 替换查询参数：空格，or ，and ， 单引号(')
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
    /// 在新窗口中打开URL
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenNewUrl(string sUrl, Page page)
    {
        string s =  "<script language='javascript'>window.open('" + sUrl + "');</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// 打开URL，替换原窗口内容
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenUrl(string sUrl, Page page)
    {
        string s = "<script language='javascript'>window.location='" + sUrl + "'</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// 打开ModeDialog格式网页对话框，锁定焦点
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenModeUrl(string sUrl, Page page)
    {
        string s =  "<script>window.showModalDialog('" + sUrl + "')</script>";
        page.Response.Write(s);
    }

    /// <summary>
    /// 打开对话框，不锁定焦点
    /// </summary>
    /// <param name="sUrl"></param>
    /// <returns></returns>
    public static void OpenModelessUrl(string sUrl, Page page)
    {
        string s = "<script>window.showModelessDialog('" + sUrl + "')</script>";
        page.Response.Write(s);
    }
}
