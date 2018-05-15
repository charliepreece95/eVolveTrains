using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCalRecord
    {
        //private data members
        private Int32 mDailyCalorieID;
        private Int32 mClientID;
        private string mDateTimeCurr;
        private string mDateTimeNxtAvail;
        private string mDailyCal;
        private string mReqCal;
        private string mUsername;

        public Int32 DailyCalorieID
        {
            get
            {
                return mDailyCalorieID;
            }
            set
            {
                mDailyCalorieID = value;
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

        public string DailyCal
        {
            get
            {
                return mDailyCal;
            }
            set
            {
                mDailyCal = value;
            }
        }

        public string ReqCal
        {
            get
            {
                return mReqCal;
            }
            set
            {
                mReqCal = value;
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


        public bool Find(Int32 DailyCalorieID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@DailyCalorieID", DailyCalorieID);
            DB.Execute("sproc_tblDailyCal_FilterByCalorieID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mDailyCalorieID = Convert.ToInt32(DB.DataTable.Rows[0]["DailyCalorieID"]);
                mClientID = Convert.ToInt32(DB.DataTable.Rows[0]["ClientID"]);
                mDateTimeCurr = Convert.ToString(DB.DataTable.Rows[0]["DateTimeCurr"]);
                mDateTimeNxtAvail = Convert.ToString(DB.DataTable.Rows[0]["DateTimeNxtAvail"]);
                mDailyCal = Convert.ToString(DB.DataTable.Rows[0]["DailyCal"]);
                mReqCal = Convert.ToString(DB.DataTable.Rows[0]["ReqCal"]);
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
