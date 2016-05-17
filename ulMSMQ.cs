using System;
//添加MSMQ引用 
using System.Messaging;
/*
web.config 会出现类似如下配置
<compilation debug="false">
  <assemblies>
    <add assembly="System.Messaging, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"/>
  </assemblies>
</compilation> 
*/

/// <summary>
///ulMSMQ 的摘要说明
///update: 2016-05-17 09:26:44
///author: julinn
/// </summary>
public class ulMSMQ
{
	public ulMSMQ()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static bool CheckQueue()
    {
        return CheckQueue("Default");
    }
    /// <summary>
    /// 检查队列是否存在， 不存在则创建
    /// </summary>
    /// <param name="queueName"></param>
    /// <returns></returns>
    public static bool CheckQueue(string queueName)
    {
        bool b = true;
        try
        {
            if (queueName == "")
                queueName = "Default";
            if (!MessageQueue.Exists(@".\private$\" + queueName))
                MessageQueue.Create(@".\private$\" + queueName);
        }
        catch(Exception ex)
        {
            b = false;
            MQ.WriteDebugLog("创建消息队列路径失败：" + queueName, ex.Message);
        }
        return b;
    }

    public static bool SendMessage(string msgText)
    {
        return SendMessage("Default", msgText);
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="queueName">写入队列名称</param>
    /// <param name="msgText">消息内容</param>
    /// <returns></returns>
    public static bool SendMessage(string queueName, string msgText)
    {
        bool b = false;
        try
        {
            if (!CheckQueue(queueName))
                return false;
            using (MessageQueue mq = new MessageQueue(@".\private$\"+queueName))
            {
                Message msg = new Message();
                msg.Body = msgText;
                msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                mq.Send(msg);
            }
            b = true;
        }
        catch(Exception ex)
        {
            MQ.WriteDebugLog("发送消息失败:" + queueName,"内容:"+msgText+"；错误："+ ex.Message);
        }
        return b;
    }

    public static string GetMessage(bool bDel)
    {
        return GetMessage("Default", bDel);
    }
    /// <summary>
    /// 从队列中获取一条消息
    /// </summary>
    /// <param name="queueName">队列名称</param>
    /// <param name="bDel">是否从队列中删除消息</param>
    /// <returns></returns>
    public static string GetMessage(string queueName, bool bDel)
    {
        string s = "";
        try
        {
            using (MessageQueue mq = new MessageQueue(@".\private$\" + queueName))
            {
                mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                Message msg = new Message();
                if (bDel)
                    msg = mq.Receive();
                else
                    msg = mq.Peek();
                s = msg.Body.ToString();
            }
        }
        catch (Exception ex)
        {
            s = "";
            MQ.WriteDebugLog("获取消息失败:" + queueName, ex.Message);
        }
        return s;
    }

    public static string GetAllMessage()
    {
        return GetAllMessage("Default");
    }
    /// <summary>
    /// 获取队列中全部消息
    /// </summary>
    /// <param name="queueName">队列名称</param>
    /// <returns></returns>
    public static string GetAllMessage(string queueName)
    {
        string s = "", temp = "";
        try
        {
            using (MessageQueue mq = new MessageQueue(@".\private$\" + queueName))
            {
                mq.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});
                Message[] msg = mq.GetAllMessages();
                for (int i = 0; i < msg.Length; i++)
                {
                    temp = msg[i].Body.ToString();
                    if (s == "")
                        s = temp;
                    else
                        s = s + "|" + temp;
                }
            }
        }
        catch (Exception ex)
        {
            s = "";
            MQ.WriteDebugLog("获取消息失败:" + queueName, ex.Message);
        }
        return s;
    }

    public static void CleanMessage()
    {
        CleanMessage("Default");
    }
    /// <summary>
    /// 清空队列中的全部消息
    /// </summary>
    /// <param name="queueName">队列名称</param>
    public static void CleanMessage(string queueName)
    {
        try
        {
            using (MessageQueue mq = new MessageQueue(@".\private$\" + queueName))
            {
                mq.Purge();
            }
        }
        catch (Exception ex)
        {
            MQ.WriteDebugLog("清空队列消息失败:" + queueName, ex.Message);
        }
    }
}
