using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Text;

namespace TrainsBackEnd.Admin
{
    public partial class Trains : System.Web.UI.Page
    {
        //var to store the primary key of the record to be deleted
        Int32 TrainID;
        clsTrainCollection train = new clsTrainCollection();

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

        private void DeleteRecord()
        {
            //new instance
            clsTrainCollection Record = new clsTrainCollection();
            //get the number of the Train to be deleted from the session object
            TrainID = Convert.ToInt32(Session["TrainID"]);
            //find the record
            Record.ThisTrain.Find(TrainID);
            //delete the record
            Record.Delete();
        }

        void GenerateTable()
        {
            StringBuilder html = new StringBuilder();

            html.Append("<table class='Available-Trains'>");
            html.Append("<thead class='Available-Trains'>");
            html.Append("<tr class='Available-Trains'>");
            html.Append("<td class='Available-Trains'>TrainID</td>");
            html.Append("<td class='Available-Trains'>Train</td>");
            html.Append("<td class='Available-Trains'>Capacity</td>");
            html.Append("<td class='Available-Trains'>Active</td>");
            html.Append("</tr>");
            html.Append("</thead>");

            foreach (clsTrain Train in train.TrainList)
            {
                html.Append("<tr class='Available-Trains'>");
                html.Append("<td class='Available-Trains'>" + Train.TrainID + "</td>");
                html.Append("<td class='Available-Trains'>" + Train.Train + "</td>");
                html.Append("<td class='Available-Trains'>" + Train.Capacity + "</td>");
                html.Append("<td class='Available-Trains'>" + Train.Active + "</td>");
                html.Append("</tr>");
            }

            html.Append("</table");
            travel.InnerHtml = html.ToString();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string trains = txtTrain.Text;
            train = new clsTrainCollection();
            train.FilterByTrain(trains);
            GenerateTable();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            clsTrainCollection Train = new clsTrainCollection();
            //validation here
            Boolean OK = Train.ThisTrain.Valid(txtTrain.Text, txtCapacity.Text, txtActive.Text);
            //set some vars for the txt elements
            string Trains = txtTrain.Text;
            string Capacity = txtCapacity.Text;
            string Active = txtActive.Text;
            //if the data is OK add it to the object
            if (OK == true)
            {
                Train.ThisTrain.Train = Trains;
                Train.ThisTrain.Capacity = Capacity;
                Train.ThisTrain.Active = Active;
                Train.Add();
                //refresh the page
                Response.Redirect("Trains.aspx");
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
                    SqlCommand cmd = new SqlCommand("sproc_tblTrain_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter TrainID = new SqlParameter("@TrainID", txtTrainID.Text);
                    SqlParameter Train = new SqlParameter("@Train", txtTrain.Text);
                    SqlParameter Capacity = new SqlParameter("@Capacity", txtCapacity.Text);
                    SqlParameter Active = new SqlParameter("@Active", txtActive.Text);

                    cmd.Parameters.Add(TrainID);
                    cmd.Parameters.Add(Train);
                    cmd.Parameters.Add(Capacity);
                    cmd.Parameters.Add(Active);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteNonQuery();
                    if (ReturnCode == -1)
                    {
                        lblValid.Text = "Try Again";
                    }
                    else
                    {
                        lblValid.Text = "Success";
                        Response.Redirect("Trains.aspx");
                        //DisplayRecords();
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 TrainID;

            if (txtTrainID.Text != "")
            {
                //get primary key value of the record to delete 
                TrainID = Convert.ToInt32(txtTrainID.Text);
                //store data in a session object
                Session["TrainID"] = TrainID;
                //call the delete method
                DeleteRecord();
                //record deletes
                lblValid.Text = "Success";
                //refresh the page
                Response.Redirect("Trains.aspx");
            }
            else
            {
                //error message
                lblValid.Text = "Enter an ID";
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            clsTrainCollection train = new clsTrainCollection();
            GenerateTable();
        }
    }
}