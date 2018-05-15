using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainsWebApp.Customer
{
    public partial class Reviews : System.Web.UI.Page
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
            clsReviewCollection Record = new clsReviewCollection(Username);
            GVReview.DataSource = Record.ReviewList;
            GVReview.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Username = Session["user"].ToString();
            clsReviewCollection Review = new clsReviewCollection(Username);
            //validation here 
            Boolean OK = Review.ThisReview.Valid(txtReview.Text);

            string review = txtReview.Text;
            string system = ddlReviewSystem.Text;
            int rating = Int32.Parse(ddlRating.Text);

            if (OK == true)
            {
                Review.ThisReview.Description = review;
                Review.ThisReview.SystemName = system;
                Review.ThisReview.Rating = rating;
                Review.Add(Username);
                //success
                lblMessage.Text = "Thank For Your Feedback";
                //refresh the page 
                Response.Redirect("Reviews.aspx");
            }
            else
            {
                //report an error
                lblMessage.Text = "Please Comment";
            }

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            string Username = Session["user"].ToString();
            clsReviewCollection Record = new clsReviewCollection(Username);
            Response.Redirect("Reviews.aspx");
        }
    }
}