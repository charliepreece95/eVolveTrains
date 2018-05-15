using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Text;

namespace TrainsBackEnd.Admin
{
    public partial class Journeys : System.Web.UI.Page
    {

        //var to store the primary key of the record to be deleted
        Int32 JourneyID;
        clsJourneyCollection journeys = new clsJourneyCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateTable();

            if (Session["user"] != null)
            {
                lblUsername.Text = Session["User"].ToString();
            }
            if (!IsPostBack)
            {
                DeleteRecord();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("../Default.aspx");
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

        private void DisplayTrains()
        {
            clsTrainCollection TrainList = new clsTrainCollection();
            Int32 Index = 0;
            Int32 RecordCount = TrainList.Count;
            while (Index < RecordCount)
            {
                Response.Write(TrainList.TrainList[Index].TrainID);
                Response.Write(TrainList.TrainList[Index].Train);
                Response.Write(TrainList.TrainList[Index].Capacity);
                //increment the index
                Index++;
            }
        }

        private void DisplayUsers()
        {
            clsPersonCollection PersonList = new clsPersonCollection();
            Int32 Index = 0;
            Int32 RecordCount = PersonList.Count;
            while (Index < RecordCount)
            {
                Response.Write(PersonList.PersonList[Index].PersonID);
                Response.Write(PersonList.PersonList[Index].FirstName);
                Response.Write(PersonList.PersonList[Index].LastName);
                Response.Write(PersonList.PersonList[Index].DoB);
                Response.Write(PersonList.PersonList[Index].Address);
                Response.Write(PersonList.PersonList[Index].Postcode);
                Response.Write(PersonList.PersonList[Index].Town);
                Response.Write(PersonList.PersonList[Index].Country);
                Response.Write(PersonList.PersonList[Index].TeleNo);
                Response.Write(PersonList.PersonList[Index].Email);
                //increment the index
                Index++;
            }

        }

        void GenerateTable()
        {
            StringBuilder html = new StringBuilder();

            html.Append("<table class='Available-Trains'>");
            html.Append("<thead class='Available-Trains'>");
            html.Append("<tr class='Available-Trains'>");
            html.Append("<td class='Available-Trains'>journeyID</td>");
            html.Append("<td class='Available-Trains'>Origin</td>");
            html.Append("<td class='Available-Trains'>Platform</td>");
            html.Append("<td class='Available-Trains'>Destination</td>");
            html.Append("<td class='Available-Trains'>Platform</td>");
            html.Append("<td class='Available-Trains'>Price</td>");
            html.Append("<td class='Available-Trains'>Departure</td>");
            html.Append("<td class='Available-Trains'>Arrival</td>");
            html.Append("</tr>");
            html.Append("</thead>");


            //string username = txtUsername.Text;
            //journeys.FilterByName(username);

            foreach (clsJourney journey in journeys.JourneyList)
            {
                html.Append("<tr class='Available-Trains'>");
                html.Append("<td class='Available-Trains'>" + journey.JourneyID + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.StationFrom + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.PlatformFrom + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.StationTo + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.PlatformTo + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.Price + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.Departure + "</td>");
                html.Append("<td class='Available-Trains'>" + journey.Arrival + "</td>");
                html.Append("</tr>");
            }

            html.Append("</table");
            travel.InnerHtml = html.ToString();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string station = txtStationFrom.Text;
            string platform = txtplatformFrom.Text;
            journeys = new clsJourneyCollection();
            journeys.FilterByStation(station, platform);
            GenerateTable();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            clsJourneyCollection Journey = new clsJourneyCollection();
            //validation here
            Boolean OK = Journey.ThisJourney.Valid(txtStationFrom.Text, txtplatformFrom.Text, txtStationTo.Text, txtPlatformTo.Text, txtPrice.Text, txtDeparture.Text, txtArrvial.Text);
            //set some vars for the txt elements
            string StationFrom = txtStationFrom.Text;
            string PlatformFrom = txtplatformFrom.Text;
            string StationTo = txtStationTo.Text;
            string PlatformTo = txtPlatformTo.Text;
            string Price = txtPrice.Text;
            string Departure = txtDeparture.Text;
            string Arrvial = txtArrvial.Text;

            //if the data is OK add it to the object
            if (OK == true)
            {
                Journey.ThisJourney.StationFrom = StationFrom;
                Journey.ThisJourney.PlatformFrom = PlatformFrom;
                Journey.ThisJourney.StationTo = StationTo;
                Journey.ThisJourney.PlatformTo = PlatformTo;
                Journey.ThisJourney.Price = Price;
                Journey.ThisJourney.Departure = Departure;
                Journey.ThisJourney.Arrival = Arrvial;
                Journey.Add();
                //refresh the page
                Response.Redirect("Journeys.aspx");
                lblValid.Text = "Success";
            }
            else
            {
                //report an error
                lblValid.Text = "Please try again";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Read the connection string from web.config.
                //ConfigurationManager class is in System.Configuration namespace
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                //SqlConnection is in System.Data.SqlClient namespace
                //Connect to the db
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //execute the stored procedure
                    SqlCommand cmd = new SqlCommand("sproc_tblJourney_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter JourneyID = new SqlParameter("@JourneyID", txtJourneyID.Text);
                    SqlParameter StationFrom = new SqlParameter("@StationFrom", txtStationFrom.Text);
                    SqlParameter PlatformFrom = new SqlParameter("@PlatformFrom", txtplatformFrom.Text);
                    SqlParameter StationTo = new SqlParameter("@StationTo", txtStationTo.Text);
                    SqlParameter PlatformTo = new SqlParameter("@PlatformTo", txtPlatformTo.Text);
                    SqlParameter Price = new SqlParameter("@Price", txtPrice.Text);
                    SqlParameter Departure = new SqlParameter("@Departure", txtDeparture.Text);
                    SqlParameter Arrival = new SqlParameter("@Arrival", txtArrvial.Text);

                    cmd.Parameters.Add(JourneyID);
                    cmd.Parameters.Add(StationFrom);
                    cmd.Parameters.Add(PlatformFrom);
                    cmd.Parameters.Add(StationTo);
                    cmd.Parameters.Add(PlatformTo);
                    cmd.Parameters.Add(Price);
                    cmd.Parameters.Add(Departure);
                    cmd.Parameters.Add(Arrival);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteNonQuery();
                    if (ReturnCode == -1)
                    {
                        lblValid.Text = "Try Again";
                    }
                    else
                    {
                        lblValid.Text = "Success";
                        Response.Redirect("Journeys.aspx");
                        //DisplayRecords();
                    }
                }
            }
        }

        private void DeleteRecord()
        {
            //new instance
            clsJourneyCollection Record = new clsJourneyCollection();
            //get the number of the Journey to be deleted from the session object
            JourneyID = Convert.ToInt32(Session["JourneyID"]);
            //find the record
            Record.ThisJourney.Find(JourneyID);
            //delete the record
            Record.Delete();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 JourneyID;

            if (txtJourneyID.Text != "")
            {
                //get primary key value of the record to delete 
                JourneyID = Convert.ToInt32(txtJourneyID.Text);
                //store data in a session object
                Session["JourneyID"] = JourneyID;
                //call the delete method
                DeleteRecord();
                //record deletes
                lblValid.Text = "Success";
                //refresh the page
                Response.Redirect("Journeys.aspx");
            }
            else
            {
                //error message
                lblValid.Text = "Enter an ID";
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            clsJourneyCollection journey = new clsJourneyCollection();
            GenerateTable();
        }
    }
}
