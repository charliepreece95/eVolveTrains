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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
               lblUsername.Text = Session["User"].ToString();
            }
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("../Default.aspx");
        }
    }
}
