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

public partial class Userhomepage : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    string query1;
    SqlDataAdapter sa = new SqlDataAdapter();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppConString"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        User use = (User)Session["userobj"];
        DateTime dtttt;
        name.Text = use.Fullname;
        Int32 co =Convert.ToInt32( use.AccessCode);
        List<DeliveryDetails> delivaryList = Application["delivaryList"] as List<DeliveryDetails>;
        try
        {
            con.Open();
            query1 = "select * from yendrathib_WADsp16_delivarydetails";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.CommandType = CommandType.Text;
            sa.SelectCommand = cmd;
            sa.Fill(ds);
            dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string pickup = Convert.ToString(dr["pickup_address"]);
                    string raddre = Convert.ToString(dr["recipient_address"]);
                    string rphone = Convert.ToString(dr["recipient_phone"]);
                    string dess = Convert.ToString(dr["description"]);
                    var ci = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                   // string dttt = Convert.ToString(dr["request_date"]);
                   // object ts = dr["request_date"];
                    DateTime dtt = Convert.ToDateTime(dr["request_date"]);
                  //  Session[dtttt] = dtt;
                   // var value = DateTime.Parse("dtt", ci);
                   // DateTime dtt = Convert.ToDateTime(dttt);

                    //allUsersList.Add(new User(name.Text.Trim(), company.Text, maddress.Text, phonenum.Text, email.Text, int.Parse(codecheck.Text)));
                   // allUsersList.Add(new User(name, company, mailing, phone, email, codes));
                    delivaryList.Add(new DeliveryDetails(pickup, raddre, rphone, dess, co, dtt));

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
    protected void swap(object sender, EventArgs e)
    {
        
        if (radd.Text == "" || add.Text == "" || phone.Text == "" || items.Text == "")
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
          "err_msg",
          "alert('please fill the fields with * symbol');",
          true);
        else
        {
            newDelivary();
        }
    }
    protected void newDelivary()
    {
       /* List<DeliveryDetails> delivaryList = Application["delivaryList"] as List<DeliveryDetails>;
        User use = (User)Session["userobj"];
        if(delivaryList==null)
        {
            delivaryList=new List<DeliveryDetails>();
        }

        delivaryList.Add(new DeliveryDetails(add.Text.Trim(), radd.Text.Trim(), phone.Text.Trim(), items.Text.Trim(),use.AccessCode,ddt));

        Application["delivaryList"] = delivaryList;*/

       
        tdelivary();
       
    }
    protected void tdelivary()
    {
        User use = (User)Session["userobj"];
        name.Text = use.Fullname;
        Int32 co = Convert.ToInt32(use.AccessCode);
        //sql server for insertion into userinfo table.
        DateTime myDateTime = DateTime.Now;
        string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        try
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
          //  long epoch = (ddtt.Ticks - 621355968000000000) / 10000000;
           // test.Text = name.Text;
            //int ac = Int32.Parse(codecheck.Text.Trim());
           // ac = Int32.Parse(codecheck.Text.Trim());
            cmd.CommandText = "insert into yendrathib_WADsp16_delivarydetails (access_code,request_date,pickup_address,recipient_phone,description)values('" + co + "','" + sqlFormattedDate + "','" + add.Text + "','" + phone.Text + "','" + items.Text + "')";
            //cmd.CommandText="insert into Table1 values("+name.Text+",'"+company.Text+"','"+maddress.Text+"','"+phonenum.Text+"','"+email.Text+"','"+codecheck.Text+"')";
            cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            Response.Write(e);
        }
        finally
        {
            con.Close();
        }
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
    "err_msg",
    "alert('Thank you for submitting a delivary request .We are more than happy to serve you.An invoice mail has been sent to your email adddress in our file.');",
    true);
        senmail();
    }
    protected void senmail()
    {
        User use = (User)Session["userobj"];
        string names = name.Text;
        string ra = radd.Text;
        string pa = add.Text;
        string des = items.Text;
        String msgTo = use.EmailAddress;
        String msgSubject = "<Texans Store to door Delivary>Registration Conformation";
        string msgbody = "Valued Customer  " + names;
        String msgBody = "<br/>" + "<br/>" + "You have requested a new delivary.Details shown below." + "<br/>";
        msgBody += "Pickup Address : " + pa;
        msgBody += "<br/>" + "Recipient Address : " + ra;
        msgBody += "<br/>" + "Description : " + des; 
       msgBody+= "<br/>" + "Please note that any modifications made after 2 hours of submission of the original request shall be rejected." + "<br/>" + "<br/>" + "sincerely" +
 "<Delivery service name> – Customer Service Team";

        string msgbodyy = msgbody + msgBody;
        MailMessage mailObj = new MailMessage();
        mailObj.Body = msgbodyy;
        mailObj.From = new MailAddress(use.EmailAddress, "We have recieved your email");
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
    protected void logoutof(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Accounts.aspx");
    }
    
}