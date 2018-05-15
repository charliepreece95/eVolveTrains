using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClassLibrary;
using System.Web.Security;


namespace TrainsWebApp.Customer
{
    public partial class Home : System.Web.UI.Page
    {
        clsJourneyCollection journeys = new clsJourneyCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lblUsername.Text = Session["User"].ToString();
            }
            if (!IsPostBack)
            {
                DisplayRecords();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("../Default.aspx");
        }

        private void DisplayRecords()
        {
            clsJourneyCollection Record = new clsJourneyCollection();
            GVJourney.DataSource = Record.JourneyList;
            GVJourney.DataBind();
        }

        private void DisplayJourney()
        {
            clsJourneyCollection JourneyList = new clsJourneyCollection();
            Int32 Index = 0;
            Int32 RecordCount = JourneyList.Count;
            while (Index < RecordCount)
            { 
                Response.Write(JourneyList.JourneyList[Index].JourneyID);
                Response.Write(JourneyList.JourneyList[Index].StationFrom);
                Response.Write(JourneyList.JourneyList[Index].PlatformFrom);
                Response.Write(JourneyList.JourneyList[Index].StationTo);
                Response.Write(JourneyList.JourneyList[Index].PlatformTo);
                Response.Write(JourneyList.JourneyList[Index].Price);
                Response.Write(JourneyList.JourneyList[Index].Departure);
                Response.Write(JourneyList.JourneyList[Index].Arrival);
                //increment the index
                Index++;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Username = Session["user"].ToString();
            clsBookingCollection Booking = new clsBookingCollection(Username);
            //validation here
            Boolean OK = Booking.ThisBooking.Valid(Station_origin.Text, Station_destination.Text, ddlType.Text, ddlDate.Text, ddlMonth.Text, ddlDeparture.Text);
            //set some vars for the txt elements
            string Station_Origin = Station_origin.Text;
            string Station_Destination = Station_destination.Text;
            string Type = ddlType.Text;
            string Date = ddlDate.Text;
            string Month = ddlMonth.Text;
            string Departure = ddlDeparture.Text;
           // string Arrival = ddlArrival.Text;
            string UserName = Username;
            //if the data is OK add it to the object
            if (OK == true)
            {
                Booking.ThisBooking.Station_Origin = Station_Origin;
                Booking.ThisBooking.Station_Destination = Station_Destination;
                Booking.ThisBooking.Type = Type;
                Booking.ThisBooking.Date = Date;
                Booking.ThisBooking.Month = Month;
                Booking.ThisBooking.Departure = Departure;
          //      Booking.ThisBooking.Arrival = Arrival;
                Booking.ThisBooking.Username = UserName;
                Booking.Add();
                //Response.Redirect("Cart.aspx");
                lblError.Text = "Success";
            }
            else
            {
                //report an error
                lblError.Text = "Please try again";
            }
        }
    }
}
