using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainsWebApp.Customer
{
    public partial class Bookings : System.Web.UI.Page
    {
        //var to store the primary key of the record to be deleted
        Int32 BookingID;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                lblUsername.Text = Session["User"].ToString();
            }
            if (!IsPostBack)
            {
                //call methods
                DisplayRecords();
                DeleteRecord();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("../Default.aspx");
        }

        private void DisplayRecords()
        {
            string Username = Session["user"].ToString();
            clsBookingCollection Record = new clsBookingCollection(Username);
            GVBookings.DataSource = Record.BookingList;
            GVBookings.DataBind();
        }

        private void DeleteRecord()
        {
            string username = Session["user"].ToString();
            //new instance
            clsBookingCollection Record = new clsBookingCollection(username);
            //get the number of the booking to be deleted from the session object
            BookingID = Convert.ToInt32(Session["BookingID"]);
            //find the record
            Record.ThisBooking.Find(BookingID);
            //delete the record
            Record.Delete();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 BookingID;

            if (txtRemove.Text != "")
            {
                //get primary key value of the record to delete 
                BookingID = Convert.ToInt32(txtRemove.Text);
                //store data in a session object
                Session["BookingID"] = BookingID;
                //call the delete method
                DeleteRecord();
                //record deletes
                lblError.Text = "Success";
                //refresh the page
                Response.Redirect("Bookings.aspx");
            }
            else
            {
                //error message
                lblError.Text = "Enter an ID";
            }
         
        }
    }
}