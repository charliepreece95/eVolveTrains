using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReviewCollection
    {
        public clsReviewCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblReview_System");
            PopulateArray(DB);
        }

        //class constructor
        public clsReviewCollection(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblReview_FilterByUsername");
            PopulateArray(DB);
        }

        //private data members for the all reviews list
        private List<clsReview> mReviewList = new List<clsReview>();
        //private data member for this review
        clsReview mThisReview = new clsReview();

        //public proprty for all reivews
        public List <clsReview> ReviewList
        {
            get
            {
                return mReviewList;
            }
            set
            {
                mReviewList = value;
            }
        }

        public clsReview ThisReview
        {
            get
            {
                return mThisReview;
            }
            set
            {
                mThisReview = value;
            }
        }

        public int Count { get { return mReviewList.Count; } set { } }

        public void FilterByUsername(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblReview_FilterByUsername");
            PopulateArray(DB);
        }

        public void FilterBySystem(string Username, string SystemName)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.AddParameter("@System", SystemName);
            DB.Execute("sproc_tblReview_FilterBySystem");
            PopulateArray(DB);
        }

        public int Add(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            //DB.AddParameter("@ReviewID", mThisReview.ReviewID);
            DB.AddParameter("@Username", Username);
            DB.AddParameter("@Description", mThisReview.Description);
            DB.AddParameter("@Rating", mThisReview.Rating);
            DB.AddParameter("@SystemName", mThisReview.SystemName);
            return DB.Execute("sproc_tblReview_Insert");
        }

        public void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            //get the count of the records
            RecordCount = DB.Count;
            //clear th eprivate record list
            mReviewList = new List<clsReview>();
            while (Index < RecordCount)
            {
                clsReview Review = new clsReview();
                Review.ReviewID = Convert.ToInt32(DB.DataTable.Rows[Index]["ReviewID"]);
                Review.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                Review.Description = Convert.ToString(DB.DataTable.Rows[Index]["Description"]);
                Review.Rating = Convert.ToInt32(DB.DataTable.Rows[Index]["Rating"]);
                Review.RevDate = Convert.ToString(DB.DataTable.Rows[Index]["RevDate"]);                      
                Review.SystemName = Convert.ToString(DB.DataTable.Rows[Index]["SystemName"]);
                mReviewList.Add(Review);
                Index++;
            }
        }
    }
}
