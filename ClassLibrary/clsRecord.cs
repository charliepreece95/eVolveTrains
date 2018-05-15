using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsRecord
    {
        //private data members
        private Int32 mFitRecID;
        private Int32 mClientID;
        private string mDateTimeCurr;
        private string mDateTimeNxtAvail;
        private string mCalories;
        private string mWeight;
        private string mPlan;
        private string mUsername;

        public Int32 FitRecID
        {
            get
            {
                return mFitRecID;
            }
            set
            {
                mFitRecID = value;
            }
        }

        public Int32 ClientID
        {
            get
            {
                return mClientID;
            }
            set
            {
                mClientID = value;
            }
        }

        public string DateTimeCurr
        {
            get
            {
                return mDateTimeCurr;
            }
            set
            {
                mDateTimeCurr = value;
            }
        }

        public string DateTimeNxtAvail
        {
            get
            {
                return mDateTimeNxtAvail;
            }
            set
            {
                mDateTimeNxtAvail = value;
            }
        }

        public string Calories
        {
            get
            {
                return mCalories;
            }
            set
            {
                mCalories = value;
            }
        }

        public string Weight
        {
            get
            {
                return mWeight;
            }
            set
            {
                mWeight = value;
            }
        }

        public string Plan
        {
            get
            {
                return mPlan;
            }
            set
            {
                mPlan = value;
            }
        }

        public string Username
        {
            get
            {
                return mUsername;
            }
            set
            {
                mUsername = value;
            }
        }


        public bool Find(Int32 FitRecID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@FitRecID", FitRecID);
            DB.Execute("sproc_tblFitnessRecords_FilterByFitRecID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mFitRecID = Convert.ToInt32(DB.DataTable.Rows[0]["FitRecID"]);
                mClientID = Convert.ToInt32(DB.DataTable.Rows[0]["ClientID"]);
                mDateTimeCurr = Convert.ToString(DB.DataTable.Rows[0]["DateTimeCurr"]);
                mDateTimeNxtAvail = Convert.ToString(DB.DataTable.Rows[0]["DateTimeNxtAvail"]);
                mCalories = Convert.ToString(DB.DataTable.Rows[0]["Calories"]);
                mWeight = Convert.ToString(DB.DataTable.Rows[0]["Weight"]);
                mPlan = Convert.ToString(DB.DataTable.Rows[0]["Plan"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }
    }
}
