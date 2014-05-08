using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//
using System.Net.Mail;
using System.Text;

/// <summary>
/// ulSendEmail 的摘要说明
/// Author: julinn
/// GitHub: https://github.com/julinn/LinnStudio
/// Webnet: www.liuju.net
/// Update: 2014-05-08 2014-05-08 22:15:39
/// </summary>
public class ulSendEmail
{
    public ulSendEmail()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="mailTo">收件人</param>
    /// <param name="mailTitle">主题</param>
    /// <param name="mailContent">内容</param>
    /// <param name="mailFrom">发送人</param>
    /// <param name="userPassword">发送账号用户密码</param>
    /// <param name="smtpServer">发送方SmtpServer地址</param>
    /// <returns></returns>
    public static bool SendEmail(string mailTo, string mailTitle, string mailContent, string mailFrom, string userPassword, string smtpServer)
    {
        // 邮件服务设置
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
        smtpClient.Host = smtpServer; //指定SMTP服务器
        smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

        // 发送邮件设置        
        MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
        mailMessage.Subject = mailTitle;//主题
        mailMessage.Body = mailContent;//内容
        mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
        mailMessage.IsBodyHtml = true;//设置为HTML格式
        mailMessage.Priority = MailPriority.Low;//优先级

        try
        {
            smtpClient.Send(mailMessage); // 发送邮件
            return true;
        }
        catch
        {
            return false;
        }

    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="mailTo">收件人</param>
    /// <param name="mailTitle">主题</param>
    /// <param name="mailContent">内容</param>
    /// <param name="mailFrom">发送人</param>
    /// <param name="userPassword">发送账号用户密码</param>
    /// <param name="smtpServer">发送方SmtpServer地址</param>
    /// <returns></returns>
    public static bool SendImgEmail(string mailTo, string mailTitle, string mailContent, string NetImgUrl,
        string mailFrom, string userPassword, string smtpServer)
    {
        // 邮件服务设置
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
        smtpClient.Host = smtpServer; //指定SMTP服务器
        smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

        //邮件正文拼接  http://www.cnhis.com/data/attachment/portal/201305/14/090747q9phe0zeeqpvmrkp.jpg
        mailContent = "<html>"
                    + "<head>"
                    + "<meta http-equiv='content-type' content='text/html; charset=GBK'>"
                    + "</head>"
                    + "<body>"
                    + mailContent + "<br />"
                    + "<img src='" + NetImgUrl + "'/>"
                    + "</body>"
                    + "</html>";

        // 发送邮件设置        
        MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
        mailMessage.Subject = mailTitle;//主题
        mailMessage.Body = mailContent;//内容
        mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
        mailMessage.IsBodyHtml = true;//设置为HTML格式
        mailMessage.Priority = MailPriority.Low;//优先级   

        try
        {
            smtpClient.Send(mailMessage); // 发送邮件
            return true;
        }
        catch
        {
            return false;
        }

    }
}
