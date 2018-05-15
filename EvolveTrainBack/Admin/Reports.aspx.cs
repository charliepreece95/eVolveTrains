using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainsBackEnd.Admin
{
    public partial class CentralHub : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lblUsername.Text = Session["User"].ToString();
            }
            if (!IsPostBack)
            {
                DisplayFitnessRecords();
                DisplayPCRecords();
                DisplayHomeRecords();
                DisplayMobileRecords();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("../Default.aspx");
        }

        private void DisplayFitnessRecords()
        {
            clsClientCollection Record = new clsClientCollection();
            Fitness.DataSource = Record.ClientList;
            Fitness.DataBind();
        }

        private void DisplayPCRecords()
        {
            clsPCProductCollection Record = new clsPCProductCollection();
            PC.DataSource = Record.ProductsList;
            PC.DataBind();
        }

        private void DisplayHomeRecords()
        {
            clsHomeProductCollection Record = new clsHomeProductCollection();
            Home.DataSource = Record.HomeProductList;
            Home.DataBind();
        }

        private void DisplayMobileRecords()
        {
            ClsPhoneContractCollection Record = new ClsPhoneContractCollection();
            Phone.DataSource = Record.ThisPhoneContractsList;
            Phone.DataBind();
        }

        protected void Fitness_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Fitness.PageIndex = e.NewPageIndex;
            clsClientCollection Record = new clsClientCollection();
            Fitness.DataSource = Record.ClientList;
            Fitness.DataBind();
        }

        protected void PC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PC.PageIndex = e.NewPageIndex;
            clsPCProductCollection Record = new clsPCProductCollection();
            PC.DataSource = Record.ProductsList;
            PC.DataBind();
        }

        protected void Home_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Home.PageIndex = e.NewPageIndex;
            clsHomeProductCollection Record = new clsHomeProductCollection();
            Home.DataSource = Record.HomeProductList;
            Home.DataBind();
        }

        protected void Phone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Phone.PageIndex = e.NewPageIndex;
            DisplayMobileRecords();
        }
    }
}
