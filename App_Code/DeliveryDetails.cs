using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliveryDetails
/// </summary>
public class DeliveryDetails
{
    int accessCode;
    string pickupAddress;
    string receipientAddress;
    string receipientPhone;
    string description;
    DateTime datetime;
	
		public DeliveryDetails(String pickup, String recadd, String recphone, String descrip, int access,DateTime dattime)
	{
        PickupAddress = pickup;
        ReceipientAddress = recadd;
        ReceipientPhone = recphone;
        Description = descrip;
        AccessCode = access;
        datetime = dattime;
		
	}
	
    public String PickupAddress
    {
        get { return pickupAddress; }
        set { pickupAddress = value; }
    }

    public String ReceipientAddress
    {
        get { return receipientAddress; }
        set { receipientAddress = value; }
    }
    public String ReceipientPhone
    {
        get { return receipientPhone; }
        set { receipientPhone = value; }
    }
    public String Description
    {
        get { return description; }
        set { description = value; }
    }
    public int AccessCode
    {
        get { return accessCode; }
        set { accessCode = value; }
    }
    public DateTime Datetime
    {
        get { return datetime; }
        set { datetime = DateTime.Today; }
    }
}