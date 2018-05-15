using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class User : System.Web.UI.Page
    {
        //var to store the primary key of the record to be deleted
        Int32 PersonID;
        clsPersonCollection persons = new clsPersonCollection();

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

        protected void DeleteRecord()
        {
            //new instance of clsPersonCollection
            clsPersonCollection Record = new clsPersonCollection();
            //get the number of the Person to be deleted from the session object
            PersonID = Convert.ToInt32(Session["PersonID"]);
            //find the record
            Record.ThisPerson.Find(PersonID);
            //delete the record
            Record.Delete();
        }


        void GenerateTable()
        {
            StringBuilder html = new StringBuilder();

            html.Append("<table class='Available-Trains'>");
            html.Append("<thead class='Available-Trains'>");
            html.Append("<tr class='Available-Trains'>");
            html.Append("<td class='Available-Trains'>PersonID</td>");
            html.Append("<td class='Available-Trains'>First Name</td>");
            html.Append("<td class='Available-Trains'>Last Name</td>");
            html.Append("<td class='Available-Trains'>Date of Birth</td>");
            html.Append("<td class='Available-Trains'>Address</td>");
            html.Append("<td class='Available-Trains'>Postcode</td>");
            html.Append("<td class='Available-Trains'>Town</td>");
            html.Append("<td class='Available-Trains'>Country</td>");
            html.Append("<td class='Available-Trains'>Telephone</td>");
            html.Append("<td class='Available-Trains'>Email</td>");
            html.Append("<td class='Available-Trains'>Username</td>");
            html.Append("</tr>");
            html.Append("</thead>");

            foreach (clsPerson person in persons.PersonList)
            {
                html.Append("<tr class='Available-Trains'>");
                html.Append("<td class='Available-Trains'>" + person.PersonID + "</td>");
                html.Append("<td class='Available-Trains'>" + person.FirstName + "</td>");
                html.Append("<td class='Available-Trains'>" + person.LastName + "</td>");
                html.Append("<td class='Available-Trains'>" + person.DoB + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Address + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Postcode + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Town + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Country + "</td>");
                html.Append("<td class='Available-Trains'>" + person.TeleNo + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Email + "</td>");
                html.Append("<td class='Available-Trains'>" + person.Username + "</td>");
                html.Append("</tr>");
            }

            html.Append("</table");
            users.InnerHtml = html.ToString();
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            persons = new clsPersonCollection();
            persons.FilterByName(username);
            GenerateTable();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            clsPersonCollection Person = new clsPersonCollection();
            //validation here
            Boolean OK = Person.ThisPerson.Valid(txtFirstname.Text, txtLastName.Text, txtDob.Text, txtAddress.Text, txtPostcode.Text, txtTown.Text, txtCountry.Text, txtTeleNo.Text, txtEmail.Text, txtUsername.Text);
            //set some vars for the txt elements
            string Firstname = txtFirstname.Text;
            string Lastname = txtLastName.Text;
            string DoB = txtDob.Text;
            string Address = txtAddress.Text;
            string Postcode = txtPostcode.Text;
            string Town = txtTown.Text;
            string Country = txtCountry.Text;
            string TeleNo = txtTeleNo.Text;
            string Email = txtEmail.Text;
            string Username = txtUsername.Text;
            //if the data is OK add it to the object
            if (OK == true)
            {
                Person.ThisPerson.FirstName = Firstname;
                Person.ThisPerson.LastName = Lastname;
                Person.ThisPerson.DoB = DoB;
                Person.ThisPerson.Address = Address;
                Person.ThisPerson.Postcode = Postcode;
                Person.ThisPerson.Town = Town;
                Person.ThisPerson.Country = Country;
                Person.ThisPerson.TeleNo = TeleNo;
                Person.ThisPerson.Email = Email;
                Person.ThisPerson.Username = Username;
                Person.Add();
                //refresh the page
                Response.Redirect("Users.aspx");
                //success
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
                    SqlCommand cmd = new SqlCommand("sproc_tblPerson_Update_User", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter PersonID = new SqlParameter("@PersonID", txtPersonID.Text);
                    SqlParameter Firstname = new SqlParameter("@FirstName", txtFirstname.Text);
                    SqlParameter LastName = new SqlParameter("@LastName", txtLastName.Text);
                    SqlParameter DoB = new SqlParameter("@DOB", txtDob.Text);
                    SqlParameter Address = new SqlParameter("@Address", txtAddress.Text);
                    SqlParameter Postcode = new SqlParameter("@Postcode", txtPostcode.Text);
                    SqlParameter Town = new SqlParameter("@Town", txtTown.Text);
                    SqlParameter Country = new SqlParameter("@Country", txtCountry.Text);
                    SqlParameter TeleNo = new SqlParameter("@TeleNo", txtTeleNo.Text);
                    SqlParameter Email = new SqlParameter("@Email", txtEmail.Text);
                    SqlParameter Username = new SqlParameter("@Username", txtUsername.Text);

                    cmd.Parameters.Add(PersonID);
                    cmd.Parameters.Add(Firstname);
                    cmd.Parameters.Add(LastName);
                    cmd.Parameters.Add(DoB);
                    cmd.Parameters.Add(Address);
                    cmd.Parameters.Add(Postcode);
                    cmd.Parameters.Add(Town);
                    cmd.Parameters.Add(Country);
                    cmd.Parameters.Add(TeleNo);
                    cmd.Parameters.Add(Email);
                    cmd.Parameters.Add(Username);

                    con.Open();
                    int ReturnCode = (int)cmd.ExecuteNonQuery();
                    if (ReturnCode == -1)
                    {
                        lblValid.Text = "Try Again";
                    }
                    else
                    {
                        lblValid.Text = "Success";
                        Response.Redirect("Users.aspx");
                        //DisplayRecords();
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 PersonID;

            if (txtPersonID.Text != "")
            {
                //get primary key value of the record to delete 
                PersonID = Convert.ToInt32(txtPersonID.Text);
                //store data in a session object
                Session["PersonID"] = PersonID;
                //call the delete method
                DeleteRecord();
                //refresh the page
                Response.Redirect("Users.aspx");
                //record deletes
                lblValid.Text = "Success";
            }
            else
            {
                //error message
                lblValid.Text = "Enter an ID";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clsPersonCollection Person = new clsPersonCollection();
            GenerateTable();

        }
    }
}