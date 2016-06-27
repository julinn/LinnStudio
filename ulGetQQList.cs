using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

/*
 
*/
/// <summary>
/// 获取本机登录QQ列表
/// Author：julinn
/// Update：2015-08-27 16:42:44
/// </summary>
///
/*示例代码
private void button2_Click(object sender, EventArgs e)
{
    ulGetQQList qlist = new ulGetQQList();
    bool b = qlist.GetList();
    if (b)
    {
       //MessageBox.Show(qlist.FQQList.Count.ToString());
       string temp = "", res = "";
       foreach (KeyValuePair<string, string> p in qlist.FQQList)
       {
           temp = p.Key + ";" + p.Value;
           if (res == "")
               res = temp;
           else
               res = res + "\n" + temp;
       }
       MessageBox.Show(res);
   }
   else
       MessageBox.Show(qlist.FErrmsg);
}
*/
public class ulGetQQList
{
    private System.Windows.Forms.WebBrowser web;
    private static string FURL = "http://xui.ptlogin2.qq.com/cgi-bin/qlogin";//"http://xui.ptlogin2.qq.com/cgi-bin/qlogin?domain=qq.com&amp;lang=2052&amp;qtarget=1&amp;jumpname=&amp;appid=549000912&amp;ptcss=undefined&amp;param=u1%253Dhttp%25253A%25252F%25252Fqun.qzone.qq.com%25252Fgroup&amp;css=&amp;mibao_css=&amp;s_url=http%253A%252F%252Fqun.qzone.qq.com%252Fgroup&amp;low_login=0&amp;style=12&amp;authParamUrl=&amp;needVip=1&amp;ptui_version=10028";//"http://xui.ptlogin2.qq.com/cgi-bin/qlogin";

    private static bool FbDoing = false;

    private string _errmsg = "";
    public string FErrmsg
    {
        get { return _errmsg; }
        set { _errmsg = value; }
    }

    private Dictionary<string, string> _FQQList;
    public Dictionary<string, string> FQQList
    {
        get { return _FQQList; }
        set { _FQQList = value; }
    }

    private int _listcount = 0;
    public int FListCount
    {
        get { return _listcount; }
        set { _listcount = value; }
    }

    public ulGetQQList()
    {
        FQQList = new Dictionary<string,string>();
        web = new System.Windows.Forms.WebBrowser();
    }

    /// <summary>
    /// 获取QQ列表，有记录返回true
    /// </summary>
    /// <returns></returns>
    public bool GetList()
    {
        bool ret = false;
        try
        {
            FbDoing = true;
            web.Navigate(FURL);
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebCompleted);
            while (FbDoing)
            {
                Application.DoEvents();
            }
            FListCount = FQQList.Count;
            if (FListCount > 0)
                ret = true;
        }
        catch (Exception ex)
        {
            FErrmsg = ex.Message;
            return false;
        }
        return ret;
    }

    /// <summary>
    /// 根据索引获取QQ号码
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public string GetQQNum(int idx)
    {
        try
        {
            string ret = "";
            if (idx < FListCount)
            {
                List<string> ks = new List<string>(FQQList.Keys);
                for (int i = 0; i < ks.Count; i ++ )
                {
                    if (i == idx)
                    {
                        ret = ks[i];
                        break;
                    }
                }
            }
            return ret;
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// 根据索引获取QQ昵称
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public string GetQQName(int idx)
    {
        try
        {
            string ret = "";
            if (idx < FListCount)
            {
                List<string> ks = new List<string>(FQQList.Values);
                for (int i = 0; i < ks.Count; i++)
                {
                    if (i == idx)
                    {
                        ret = ks[i];
                        break;
                    }
                }
            }
            return ret;
        }
        catch
        {
            return "";
        }
    }

    void WebCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        //为了保险起见 我们在这再次判断是否加载完成
        if (web.ReadyState == WebBrowserReadyState.Complete && web.IsBusy == false)
        {
            HtmlDocument doc = web.Document; //抓取网页
            HtmlElement hem = doc.GetElementById("list_uin");//这里就像js里面一样通过ID来查找对象
            while (doc == null || hem == null)  //网络操作总是伴随着一些不可预知的异常，所以在这以防万一对象为空,我们继续判断
            {

                Application.DoEvents();//如果为空，就转交控制权
            }

            for (int i = 0; i < hem.Children.Count; i++)
            {
                string innertext = hem.Children[i].InnerText.Trim(); //获取到昵称和QQ号，格式是这样的  昵称(qq号)
                string[] temps = innertext.Split(' '); //我们把昵称和(qq号)分离
                string name = temps[0]; //得到昵称
                string num = temps[1]; //得到QQ号
                num = num.Replace("(", "").Replace(")", ""); //因为这里我们得到的QQ号还是(qq号)带有括号，所以需要去掉括号

                /*
                ListViewItem item = new ListViewItem(); //创建Listviewitem对象
                item.Text = name;  //将昵称设置为文本
                item.SubItems.Add(num);//将QQ号添加进子项
                lvQQ.Items.Add(item);//最后将listviewitem对象添加进listview
                */
                FQQList.Add(num, name);
            }
        }
        else
        {
            FErrmsg = "网页错误。请重试";
        }
        FbDoing = false;
    }

}
