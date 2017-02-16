using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class Contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        String msgTo = TextBox1.Text;
        String msgSubject = "We have recieved your email";
        String msgBody = "Valued Customer" + "<br/>" + "<br/>" + "Thank you for contacting us. One of our customer service representatives will be contacting you within the next 24 hours." + "<br/>" +
"Thank You" + "<br/>" + "<br/>" +
"<Delivery service name> – Customer Service Team";

        MailMessage mailObj = new MailMessage();
        mailObj.Body = msgBody;
        mailObj.From = new MailAddress(TextBox1.Text, "We have recieved your email");
        mailObj.To.Add(new MailAddress(msgTo));
        mailObj.Subject = msgSubject;
        mailObj.IsBodyHtml = true;
        SmtpClient SMTPClient = new System.Net.Mail.SmtpClient();
        SMTPClient.Host = "smtp.gmail.com";
        SMTPClient.Port = 587;
        SMTPClient.Credentials = new NetworkCredential("bhavitha.yendrathi@gmail.com", "vijayajanakisai");
        SMTPClient.EnableSsl = true;
        try
        {
            SMTPClient.Send(mailObj);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
               "err_msg",
               "alert('Email has been sent- Thank you');",
               true);
        }
        catch (Exception) { }
    }
}