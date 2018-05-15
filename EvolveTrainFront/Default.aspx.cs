using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainsWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRecords();
            }
        }

        private void DisplayRecords()
        {
            clsReviewCollection Record = new clsReviewCollection();
            GVReviews.DataSource = Record.ReviewList;
            GVReviews.DataBind();
        }
    }
}