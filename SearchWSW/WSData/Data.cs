﻿using System;
using System.Collections.Generic;
using System.Text;
//
using System.Data;
using System.Net;
using System.IO;

namespace WSData
{
    class Data
    {
        //
        public static DataTable FdtUser = new DataTable();
        public static Dictionary<string, string> FcfgLocal = GetLocalConfig();
        //

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="sBegin">开始标识</param>
        /// <param name="sEnd">结束标识</param>
        /// <returns></returns>
        public static string GetMiddleString(string str, string sBegin, string sEnd)
        {
            try
            {
                int iFrom = str.IndexOf(sBegin) + sBegin.Length,
                    iTo = str.IndexOf(sEnd);
                return str.Substring(iFrom, iTo - iFrom);
            }
            catch
            {
                return "";
            }
        }

        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；  
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();//转让控制权              
            }
            return;
        }

        public static string FmtStr(string s)
        {
            return s.Replace("'", "").Replace(" ", "");
        }

        public static int StrToInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }
        
        // ================================ 

        public static string GetMac()
        {
            return ulMAC.GetMacAddress();
        }

        public static string user_login_mac(string tel, string pwd)
        {
            tel = FmtStr(tel);
            pwd = FmtStr(pwd);
            string result = "", mac = GetMac(), err ="",
                sql = "call proc_user_login_mac('" + tel + "','" + pwd + "','" + mac + "')";
            result = ulMySqlHelper.GetFirstVar(sql);
            if (result == "1")
            {
                sql = "call proc_user_info('" + tel + "','" + pwd + "')";
                ulMySqlHelper.GetaDatatable(sql, out FdtUser, out err);
                if (FdtUser.Rows.Count > 0)
                    result = "";
                else
                {
                    if (err == "")
                        err = "获取用户信息失败，用户名或密码错误";
                    result = err;
                }
            }
            return result;
        }

        public static string GetFdtUserInfo(string fieldName)
        {
            try
            {
                if (FdtUser.Rows.Count == 0)
                    return "";
                else
                    return FdtUser.Rows[0][fieldName].ToString();
            }
            catch
            {
                return "";
            }
        }

        public static Dictionary<string, string> GetLocalConfig()
        {
            Dictionary<string, string> local = new Dictionary<string, string>();
            string fileName = ulSystem.getCurrpath() + "\\config.txt";
            local = ulSystem.readConfig_txt(fileName);
            return local;
        }

        public static void SaveLocalConfig(string tel, string pwd, bool chkSelected)
        {
            string chk = "1";
            if (!chkSelected)
            {
                chk = "0";
                pwd = "";
            }
            Dictionary<string, string> local = new Dictionary<string, string>();
            local.Add("uid", tel);
            local.Add("pwd", pwd);
            local.Add("select", chk);
            string fileName = ulSystem.getCurrpath() + "\\config.txt";
            ulSystem.saveConfig_txt(local, fileName);
        }

        public static string user_create(string tel, string pwd, string name, int levID, string uTel, string uPwd)
        {
            tel = FmtStr(tel);
            pwd = FmtStr(pwd);
            name = FmtStr(name);
            uTel = FmtStr(uTel);
            uPwd = FmtStr(uPwd);
            if (tel.Length != 11 || !ulSystem.IsNumber(tel))
                return "手机号码格式错误";
            string ret = "",
                sql = "call proc_user_create('" + tel + "','" + pwd + "','" + name + "'," + levID.ToString() + ",'" + uTel + "','" + uPwd + "')";
            ret = ulMySqlHelper.GetFirstVar(sql);
            if (ret == "1")
                ret = "";
            return ret;
        }

        public static DataTable data_search(string classDef, string str)
        {
            classDef = FmtStr(classDef);
            str = FmtStr(str);
            string err = "",
                sql = "call proc_data_search('" + classDef + "','" + str + "')";
            DataTable dt = new DataTable();
            ulMySqlHelper.GetaDatatable(sql, out dt, out err);
            return dt;
        }

        public static DataTable user_search(string str)
        {
            str = FmtStr(str);
            string tel = FmtStr(GetFdtUserInfo("Tel")),
                err = "",
                sql = "call proc_user_users('" + tel + "','" + str + "')";
            DataTable dt = new DataTable();
            ulMySqlHelper.GetaDatatable(sql, out dt, out err);
            return dt;
        }

        public static DataTable user_pointLogSearch(string tel, int inout)
        {
            tel = FmtStr(tel);
            if (inout < 0 || inout > 2)
                inout = 0;
            string err = "",
                sql = "call proc_user_pointLogSearch('" + tel + "'," + inout.ToString() + ")";
            DataTable dt = new DataTable();
            ulMySqlHelper.GetaDatatable(sql, out dt, out err);
            return dt;
        }

    }
}