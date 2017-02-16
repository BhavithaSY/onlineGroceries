using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void logon(object sender, EventArgs e)
    {
        checkUser();
      //  Response.Redirect("Userhomepage.aspx");
    }
    protected void checkUser()
    {
        int yesuser = 0;
        List<User> allUsersList = Application["AllUsersList"] as List<User>;
        if (allUsersList == null)
        {
            allUsersList = new List<User>();
        }
        foreach (User item in allUsersList)
        {
            if (email.Text.Trim().Equals(item.EmailAddress) && pass.Text.Trim().Equals(item.AccessCode.ToString()))
            {
                yesuser = 1;
                Session["userobj"] = item;
             //   Response.Redirect("Userhomepage.aspx");
                break;
            }
        }
        if (yesuser == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "alert('The user doesnot exist please register');window.location='newaccountcreation.aspx'", true);
        }
        if(yesuser==1)
        {
            Response.Redirect("Userhomepage.aspx");
        }
    }
    protected void newpage(object sender, EventArgs e)
    {
        if (ne.SelectedItem.Text == "I don't have an existing account")
        Response.Redirect("newaccountcreation.aspx");
    }
}