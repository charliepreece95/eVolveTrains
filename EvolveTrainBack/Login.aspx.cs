using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TrainsWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        { 
                //call the authentication function and pass through the values of username and password
                AuthenticateUser(txtUsername.Text, txtPassword.Text);
        }

            //private method to return true or false
            //takes 2 parameters username and password
            //executre the sproc to authenticate users
            //sproc expects 2 parameters
            //pass the values of username and password to the parameters
            //sproc returns 1 or -1 therefore invoke execute scalar as we expect 1 (user authenticated)
            //-1 returns false and means user is not authenticated
            private void AuthenticateUser(string username, string password)
            {
                // ConfigurationManager class is in System.Configuration namespace
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                // SqlConnection is in System.Data.SqlClient namespace
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("sproc_tblAccounts_AuthenticateAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Formsauthentication is in system.web.security
                    string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                    //sqlparameter is in System.Data namespace
                    SqlParameter paramUsername = new SqlParameter("@Username", username);
                    SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);

                    cmd.Parameters.Add(paramUsername);
                    cmd.Parameters.Add(paramPassword);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        int retryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);

                        if (Convert.ToInt32(rdr["UserFound"]) == 0)
                        {
                            lblMessage.Text = "Invalid User Name and/or Password.";
                        }
                        else if (Convert.ToBoolean(rdr["AccountLocked"]))
                        {
                            lblMessage.Text = "Account locked, please contact administrator";
                        }
                        else if (retryAttempts > 0)
                        {
                            // allowing user to attempt login 3 times
                            int attemptsLeft = (3 - retryAttempts);
                            lblMessage.Text = "Invalid User Name and/or Password. " +
                                attemptsLeft.ToString() + " attempt(s) left";
                        }
                        else if (Convert.ToBoolean(rdr["Authenticated"]))
                        {
                            Session["user"] = txtUsername.Text;
                            FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, chkBoxRememberMe.Checked);
                        }
                    }
                }
            }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}