using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;


namespace TrainsWebApp.Customer
{
    public partial class Account : System.Web.UI.Page
    {
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
            string Username = Session["user"].ToString();
            clsPersonCollection Record = new clsPersonCollection(Username);
            GVPerson.DataSource = Record.PersonList;
            GVPerson.DataBind();
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
                    string UserName = Session["User"].ToString();
                    //execute the stored procedure
                    SqlCommand cmd = new SqlCommand("sproc_tblPerson_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter Firstname = new SqlParameter("@FirstName", txtFirstname.Text);
                    SqlParameter LastName = new SqlParameter("@LastName", txtLastName.Text);
                    SqlParameter DoB = new SqlParameter("@DOB", txtDob.Text);
                    SqlParameter Address = new SqlParameter("@Address", txtAddress.Text);
                    SqlParameter Postcode = new SqlParameter("@Postcode", txtPostCode.Text);
                    SqlParameter Town = new SqlParameter("@Town", txtTown.Text);
                    SqlParameter Country = new SqlParameter("@Country", txtCountry.Text);
                    SqlParameter TeleNo = new SqlParameter("@TeleNo", txtTeleNo.Text);
                    SqlParameter Email = new SqlParameter("@Email", txtEmail.Text);

                    cmd.Parameters.Add(Firstname);
                    cmd.Parameters.Add(LastName);
                    cmd.Parameters.Add(DoB);
                    cmd.Parameters.Add(Address);
                    cmd.Parameters.Add(Postcode);
                    cmd.Parameters.Add(Town);
                    cmd.Parameters.Add(Country);
                    cmd.Parameters.Add(TeleNo);
                    cmd.Parameters.Add(Email);
                    cmd.Parameters.AddWithValue("@UserName", UserName);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteNonQuery();
                    if (ReturnCode == -1)
                    {
                        lblUpdateMessage.Text = "Try Again";
                    }
                    else
                    {
                        lblUpdateMessage.Text = "Success";
                        DisplayRecords();
                    }
                }
            }
        }
    }
}