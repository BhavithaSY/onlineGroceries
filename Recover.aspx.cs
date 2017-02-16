using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;
public partial class Recover : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string query1;
    SqlDataAdapter sa = new SqlDataAdapter();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppConString"].ConnectionString);
    static Random ran = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<User> allUsersList = Application["AllUsersList"] as List<User>;
        //code.Text = Convert.ToString(ran.Next(100000, 1000000));
        try
        {
            con.Open();
            query1 = "select * from yendrathib_WADsp16_userinfo";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.Text;
            sa.SelectCommand = cmd;
            sa.Fill(ds);
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string name = Convert.ToString(dr["full_name"]);
                    string company = Convert.ToString(dr["company"]);
                    string mailing = Convert.ToString(dr["mailing_address"]);
                    string phone = Convert.ToString(dr["phone_number"]);
                    string email = Convert.ToString(dr["email_address"]);
                    Int32 codes = Convert.ToInt32(dr["access_code"]);

                    //allUsersList.Add(new User(name.Text.Trim(), company.Text, maddress.Text, phonenum.Text, email.Text, int.Parse(codecheck.Text)));
                    allUsersList.Add(new User(name, company, mailing, phone, email, codes));

                }



            }
        }
        catch (Exception se)
        {
            Response.Write(se);
        }
        finally
        {
            con.Close();
        }

    }
    protected void recoverbutton(object sender, EventArgs e)
    {
        int userexists=0;
       Int32 ac=0;
        List<User> allUsersList = Application["AllUsersList"] as List<User>;
        if (allUsersList == null)
        {
            allUsersList = new List<User>();
        }
        foreach (User item in allUsersList)
        {
            if (email.Text.Trim().Equals(item.EmailAddress))
            {
                userexists = 1;
                 ac = item.AccessCode;
            }
        }
        if(userexists==1)
        {

            sendmail(ac);
        
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        "err_msg",
        "alert('Your Access code has been sent to the Email address in file');",
        true);
    }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        "err_msg",
        "alert('sorry your account email cannot be verified');",
        true);
        }
    }
    protected void sendmail(Int32 acc)
    {

        //string names = name.Text;
        String msgTo = email.Text;
        String msgSubject = "<Texans Store to door Delivary>Registration Conformation";
        string msgbody = "Valued Customer , ";
        String msgBody = "<br/>" + "<br/>" + "Thank you for contacting us.";
        msgBody += "<br/>" +"your access code is" + acc; 
        msgBody+="<br/>" + "Thankyou." + "<br/>" + "<br/>" + "sincerely" +
"<Delivery service name> – Customer Service Team";
        string msgbodyy = msgbody + msgBody;
        MailMessage mailObj = new MailMessage();
        mailObj.Body = msgbodyy;
        mailObj.From = new MailAddress(email.Text, "We have recieved your email");
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
    protected void textchange(object sender, EventArgs e)
    {
        int userexists = 0;
        List<User> allUsersList = Application["AllUsersList"] as List<User>;
        if (allUsersList == null)
        {
            allUsersList = new List<User>();
        }
        foreach (User item in allUsersList)
        {
            if (email.Text.Trim().Equals(item.EmailAddress))
            {
                userexists = 1;
            }
        }
        if (userexists == 1)
        {


            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            "err_msg",
            "alert('Your Access code has been sent to the Email address in file');",
            true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        "err_msg",
        "alert('sorry your account email cannot be verified');",
        true);
        }
    }
}
