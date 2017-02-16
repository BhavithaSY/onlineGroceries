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

public partial class newaccountcreation : System.Web.UI.Page
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
        code.Text = Convert.ToString(ran.Next(100000, 1000000));
        try
        {
            con.Open();
            query1 = "select * from yendrathib_WADsp16_userinfo";
            SqlCommand cmd = new SqlCommand(query1,con);
            cmd.CommandType = CommandType.Text;
            sa.SelectCommand = cmd;
            sa.Fill(ds);
            dt = ds.Tables[0];
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string name=Convert.ToString(dr["full_name"]);
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
        catch(Exception se)
        {
            Response.Write(se);
        }
        finally
        {
            con.Close();
        }

    }
    protected void accpage(object sender, EventArgs e)
    {
        if (ne.SelectedItem.Text == "I have an existing account")
            Response.Redirect("Accounts.aspx");
    }
    protected void hasgone(object sender, EventArgs e)
    {
        Response.Redirect("Accounts.aspx");
    }
    //for create account button
    protected void sweat(object sender, EventArgs e)
    {
        if (name.Text == "" || phonenum.Text == "" || email.Text == "" || maddress.Text == "" || codecheck.Text == "")
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
         "err_msg",
         "alert('please fill the fields with * symbol');",
         true);
        else
        {
           
            userCreation();
            

        }
       
    }
    protected void userCreation()
    {
        int newuser = 1;
        List<User> allUsersList = Application["AllUsersList"] as List<User>;
        if(allUsersList==null)
        {
            allUsersList=new List<User>();
        }
        foreach(User item in allUsersList)
        {
            if(email.Text.Trim().Equals(item.EmailAddress))
            {
                newuser=0;
            }
        }
        if (newuser == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "alert('The user already exists please login');", true);
        }
        else
        {
            allUsersList.Add(new User(name.Text.Trim(), company.Text, maddress.Text, phonenum.Text, email.Text, int.Parse(codecheck.Text)));
           /* foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Text = string.Empty;
                    }
                }
            }*/
            Application["AllUsersList"] = allUsersList;

            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(),
            "err_msg",
            "alert('Thank you for creating an account with us .We have sent you an email with details.');window.location.href='Accounts.aspx';",
            true);
           
           

        }
        //sql server for insertion into userinfo table.
        try
        {

            con.Open();
           SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            test.Text = name.Text;
            //int ac = Int32.Parse(codecheck.Text.Trim());
           int ac,acces=0;
            if(Int32.TryParse(codecheck.Text.Trim(),out ac))
            {
                 acces = ac;
            }
            else
            {
                Response.Write(code.Text);
            }
           // ac = Int32.Parse(codecheck.Text.Trim());
            cmd.CommandText = "insert into yendrathib_WADsp16_userinfo (full_name,company,mailing_address,phone_number,email_address,access_code)values('"+name.Text+"','"+company.Text+"','"+maddress.Text+"','"+phonenum.Text+"','"+email.Text+"',"+acces+")";
            //cmd.CommandText="insert into Table1 values("+name.Text+",'"+company.Text+"','"+maddress.Text+"','"+phonenum.Text+"','"+email.Text+"','"+codecheck.Text+"')";
                cmd.ExecuteNonQuery();
           
        }
        catch(Exception e)
        {
            Response.Write(e);
        }
        finally{
            con.Close();
        }
        senmail();
        }
        protected void senmail()
        {
            string names = name.Text;
            String msgTo = email.Text;
            String msgSubject = "<Texans Store to door Delivary>Registration Conformation";
            string msgbody = "Valued Customer  " + names;
            String msgBody = "<br/>" + "<br/>" + "Thank you for registering with texans store to door delivary. You can now use your account to order deliveries with us." + "<br/>" +
    "Looking Forward to Bussiness with you" + "<br/>" + "Thankyou again for keeping trust on us."+"<br/>" +"<br/>"+"sincerely"+
    "<Delivery service name> – Customer Service Team";
            string msgbodyy=msgbody+msgBody;
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
    }
   
