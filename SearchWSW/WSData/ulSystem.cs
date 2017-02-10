using System;
using System.Collections.Generic;
using System.Text;

public class ulSystem
{
    private static string FsConnFileName = getCurrpath() + "\\connset.txt";
    private static string FsConfigFileName = getCurrpath() + "\\defconfig.txt";

    public ulSystem()
    {
    }

    #region getCurrpath 当前程序目录（末尾不含\，格式 如 E:\App\AppPath）
    /// <summary>
    /// 当前程序目录（末尾不含\，格式 如 E:\App\AppPath）
    /// </summary>
    /// <returns></returns>
    public static string getCurrpath()
    {
        try
        {
            return System.Windows.Forms.Application.StartupPath;
        }
        catch
        {
            return "";
        }
    }
    #endregion 

    #region IsNumber 检查是否是数字
    /// <summary>
    /// 检查是否是数字
    /// </summary>
    /// <param name="str_number"></param>
    /// <returns></returns>
    public static bool IsNumber(string str_number)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");
    }
    #endregion 

    #region GetFileVersion 获取文件版本号
    /// <summary>
    /// 获取文件版本号
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string GetFileVersion(string filePath)
    {
        try
        {
            System.Diagnostics.FileVersionInfo fv = new System.Diagnostics.FileVersionInfo(filePath);
            return fv.FileVersion; 
        }
        catch
        {
            return "";
        }
    }
    #endregion 

    #region SimpleEncStr 简单加密 base64
    /// <summary>
    /// 简单加密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SimpleEncStr(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        return Convert.ToBase64String(b);
    }
    #endregion

    #region SimpleDecStr 简单解密 base64
    /// <summary>
    /// 简单解密 base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SimpleDecStr(string str)
    {
        byte[] b = Convert.FromBase64String(str);
        return System.Text.Encoding.Default.GetString(b);
    }
    #endregion

    #region txtRead txt文件读取
    /// <summary>
    /// txt文件读取
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns></returns>
    public static string txtRead(string path)
    {
        try
        {
            return System.IO.File.ReadAllText(path);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// txt 读取
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="coding">指定读取的编码格式</param>
    /// <returns></returns>
    public static string txtRead(string path, Encoding coding)
    {
        try
        {
            return System.IO.File.ReadAllText(path, coding);
        }
        catch
        {
            return "";
        }
    }

    public static string[] txtReadStrings(string path)
    {
        try
        {
            return System.IO.File.ReadAllLines(path);
        }
        catch
        {
            return new string[0];
        }
    }
    public static string[] txtReadStrings(string path, Encoding coding)
    {
        try
        {
            return System.IO.File.ReadAllLines(path, coding);
        }
        catch
        {
            return new string[0];
        }
    }
    #endregion 

    #region txtSave txt文件保存
    /// <summary>
    /// txt文件保存
    /// </summary>
    /// <param name="content"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool txtSave(string content, string path)
    {
        try
        {
            System.IO.File.WriteAllText(path, content);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool txtSave(string content, string path, Encoding coding)
    {
        try
        {
            System.IO.File.WriteAllText(path, content, coding);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool txtSave(string[] contentlines, string path)
    {
        try
        {
            System.IO.File.WriteAllLines(path, contentlines);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool txtSave(string[] contentlines, string path, Encoding coding)
    {
        try
        {
            System.IO.File.WriteAllLines(path, contentlines, coding);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region txtAddLine txt文件保存（追加行）
    /// <summary>
    /// txt文件保存（追加行）
    /// </summary>
    /// <param name="content"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool txtAddLine(string content, string path)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(content);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region openPathAndSelectFile 打开文件夹并选择指定文件
    /// <summary>
    /// 打开文件夹并选择指定文件
    /// </summary>
    /// <param name="FileName">要选定的文件名</param>
    /// <param name="Filepath">文件夹路径（为空自动获取当前程序运行路径）</param>
    /// <returns></returns>
    public static bool openPathAndSelectFile(string FileName, string Filepath)
    {
        try
        {
            if (Filepath == "")
                Filepath = getCurrpath();
            System.Diagnostics.Process.Start("Explorer.exe", "/select," + Filepath + @"\" + FileName);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region openPath 打开文件夹
    /// <summary>
    /// 打开文件夹
    /// </summary>
    /// <param name="Filepath">文件夹路径（为空自动获取当前程序运行路径）</param>
    /// <returns></returns>
    public static bool openPath(string Filepath)
    {
        try
        {
            if (Filepath == "")
                Filepath = getCurrpath();
            System.Diagnostics.Process.Start(Filepath);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion 

    #region readConfig_txt 读取TXT配置文件
    /// <summary>
    /// 读取TXT配置文件
    /// </summary>
    /// <param name="txtpath">txt完整路径</param>
    /// <returns></returns>
    public static Dictionary<string, string> readConfig_txt(string txtpath)
    {
        Dictionary<string, string> cfg = new Dictionary<string, string>();
        try
        {
            string[] lines = txtReadStrings(txtpath);
            string key = "", value = "", temp = "";
            string[] kv = new string[2];
            for (int i = 0; i < lines.Length; i++)
            {
                temp = lines[i];
                kv = temp.Split('=');
                key = kv[0];
                value = kv[1];
                cfg.Add(key, value);
            }
        }
        catch
        {
            //
        }
        return cfg;
    }

    public static Dictionary<string, string> readConfig_txt()
    {
        return readConfig_txt(FsConfigFileName);
    }

    public static string readConfig_txt(string txtpath, string nodeName)
    {
        string ret = "";
        Dictionary<string, string> cfg = readConfig_txt(txtpath);
        if (cfg.ContainsKey(nodeName))
            ret = cfg[nodeName];
        return ret;
    }

    #endregion 

    #region saveConfig_txt 保存TXT配置文件
    /// <summary>
    /// 保存TXT配置文件
    /// </summary>
    /// <param name="cfg"></param>
    /// <param name="txtpath">txt完整路径</param>
    /// <returns></returns>
    public static bool saveConfig_txt(Dictionary<string, string> cfg, string txtpath)
    {
        bool b = false;
        try
        {
            string[] lines = new string[cfg.Count];
            int i = 0;
            foreach (KeyValuePair<string, string> kv in cfg)
            {
                lines[i] = kv.Key + "=" + kv.Value;
                i++;
            }
            b = txtSave(lines, txtpath);
        }
        catch
        {
        }
        return b;
    }

    public static bool saveConfig_txt(Dictionary<string, string> cfg)
    {
        return saveConfig_txt(FsConfigFileName);
    }

    public static bool saveConfig_txt(string nodeName, string nodeValue, string txtpath)
    {
        bool b = false;
        Dictionary<string, string> cfg = readConfig_txt(txtpath);
        if (cfg.ContainsKey(nodeName))
            cfg[nodeName] = nodeValue;
        else
            cfg.Add(nodeName, nodeValue);
        b = saveConfig_txt(cfg, txtpath);
        return b;
    }

    public static bool saveConfig_txt(string nodeName, string nodeValue)
    {
        return saveConfig_txt(nodeName, nodeValue, FsConfigFileName);
    }

    #endregion 

    #region getDictKey 根据索引获取Key
    /// <summary>
    /// 根据索引获取Key
    /// </summary>
    /// <param name="idx">索引</param>
    /// <param name="dict"></param>
    /// <returns></returns>
    public static string getDictKey(int idx, Dictionary<string, string> dict)
    {
        string ret = "";
        try
        {
            if (idx < dict.Count)
            {
                List<string> keys = new List<string>(dict.Keys);
                for (int i = 0; i < keys.Count; i++)
                {
                    if (i == idx)
                    {
                        ret = keys[i];
                        break;
                    }
                }
            }
        }
        catch
        {
        }
        return ret;
    }
    #endregion 

    #region getDictValue 根据索引获取Value
    /// <summary>
    /// 根据索引获取Value
    /// </summary>
    /// <param name="idx">索引</param>
    /// <param name="dict"></param>
    /// <returns></returns>
    public static string getDictValue(int idx, Dictionary<string, string> dict)
    {
        string ret = "";
        try
        {
            if (idx < dict.Count)
            {
                List<string> valus = new List<string>(dict.Values);
                for (int i = 0; i < valus.Count; i++)
                {
                    if (i == idx)
                    {
                        ret = valus[i];
                        break;
                    }
                }
            }
        }
        catch
        {
        }
        return ret;
    }
    #endregion 



    public static Dictionary<string, string> GetConnSet()
    {
        Dictionary<string, string> cfg = new Dictionary<string, string>();
        //string path = 
        cfg = readConfig_txt(FsConnFileName);
        return cfg;
    }

    #region DownloadFile 下载文件
    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="URL">文件URL</param>
    /// <param name="filename">保存到本地名称（如：D:\App\App.exe）</param>
    /// <param name="prog">进度条控件名</param>
    /// <param name="label1">显示进度文字控件</param>
    /// <returns></returns>
    public static string DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label label1)
    {
        string result = "下载失败";
        float percent = 0;
        try
        {
            System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
            long totalBytes = myrp.ContentLength;
            if (prog != null)
            {
                prog.Maximum = (int)totalBytes;
            }
            System.IO.Stream st = myrp.GetResponseStream();
            System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            long totalDownloadedByte = 0;
            byte[] by = new byte[1024];
            int osize = st.Read(by, 0, (int)by.Length);
            while (osize > 0)
            {
                totalDownloadedByte = osize + totalDownloadedByte;
                System.Windows.Forms.Application.DoEvents();
                so.Write(by, 0, osize);
                if (prog != null)
                {
                    prog.Value = (int)totalDownloadedByte;
                }
                osize = st.Read(by, 0, (int)by.Length);

                percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                label1.Text = "下载进度：" + percent.ToString() + "%";
                System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
            }
            so.Close();
            st.Close();
            result = "";
        }
        catch (System.Exception ex)
        {
            result = "下载失败：" + ex.Message;
        }
        return result;
    }
    #endregion 

}
