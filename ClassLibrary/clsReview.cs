using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsReview
    {
        //private data members
        private Int32 mReviewID;
        private string mUsername;
        private string mDescription;
        private Int32 mRating;
        private string mRevDate;
        private string mSystemName;

        public Int32 ReviewID { get { return mReviewID; } set { mReviewID = value; } }
        public string Username { get { return mUsername; } set { mUsername = value; } }
        public string Description { get { return mDescription; } set { mDescription = value; } }
        public Int32 Rating { get { return mRating; } set { mRating = value; } }
        public string RevDate { get { return mRevDate; } set { mRevDate = value; } }
        public string SystemName { get { return mSystemName; } set { mSystemName = value; } }

        //find method
        public bool Find(Int32 ReviewerID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ReviewerID", mReviewID);
            DB.Execute("sproc_tblReview_FilterByReviewID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mReviewID = Convert.ToInt32(DB.DataTable.Rows[0]["ReviewID"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mRating = Convert.ToInt32(DB.DataTable.Rows[0]["Rating"]);
                mRevDate = Convert.ToString(DB.DataTable.Rows[0]["RevDate"]);
                mSystemName = Convert.ToString(DB.DataTable.Rows[0]["SystemName"]);
                return true;
            }
            //if no record found
            else
            {
                return false;
            }
        }

        public bool Valid(string Description)
        {
            Boolean OK = true;

            //if property is null
            if (Description.Length < 1)
            {
                OK = false;
            }
            //property is 200
            if (Description.Length > 200)
            {
                OK = false;
            }
            return OK;
        }
    }
}
