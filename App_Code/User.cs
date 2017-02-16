using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    string fullname;
    string company;
    string mailingAddress;
    string phoneNumber;
    string emailAddress;
    int accessCode;
    //DeliveryDetail[] delivaryDetailsList;
	public User(string nam ,string comp,string addr,string phone,string mail,int code)
	{
        Fullname=nam;
        Company=comp;
        MailingAddress=addr;
		PhoneNumber=phone;
        EmailAddress=mail;
        AccessCode = code;
	}
    public string Fullname
    {
        get { return fullname;}
        set { fullname = value; }
    }
    public string Company
    {
        get { return company; }
        set { company = value; }
    }
    public string MailingAddress
    {
        get { return mailingAddress; }
        set { mailingAddress = value; }
    }
    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }
    public string EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }
    public int AccessCode
    {
        get { return accessCode; }
        set { accessCode = value; }
    }
}