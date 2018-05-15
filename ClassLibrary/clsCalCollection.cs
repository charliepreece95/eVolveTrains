using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCalCollection
    {
        //class constructor
        public clsCalCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblDailyCal_SelectAll");
            PopulateArray(DB);
        }

        //private data members for the allrecords lists
        private List<clsCalRecord> mCalRecordList = new List<clsCalRecord>();
        //private data member for thisclient
        clsCalRecord mThisCalRecord = new clsCalRecord();

        //public property for allclients
        public List<clsCalRecord> CalRecordList
        {
            get
            {
                //return the private data member
                return mCalRecordList;
            }
            set
            {
                //assign the incoming value to the private data member
                mCalRecordList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mCalRecordList.Count;
            }
            set
            {

            }
        }

        public clsCalRecord ThisCalRecord
        {
            get
            {
                return mThisCalRecord;
            }
            set
            {
                mThisCalRecord = value;
            }
        }

        public void FilterByUsername(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblDailyCal_FilterByUsername");
            PopulateArray(DB);
        }

        public void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            //get the count of the records
            RecordCount = DB.Count;
            //clear th eprivate record list
            mCalRecordList = new List<clsCalRecord>();
            while (Index < RecordCount)
            {
                clsCalRecord CalRecord = new clsCalRecord();
                CalRecord.DailyCalorieID = Convert.ToInt32(DB.DataTable.Rows[Index]["DailyCalorieID"]);
                //Record.ClientID = Convert.ToInt32(DB.DataTable.Rows[Index]["ClientID"]);
                CalRecord.DateTimeCurr = Convert.ToString(DB.DataTable.Rows[Index]["DateTimeCurr"]);
                CalRecord.DateTimeNxtAvail = Convert.ToString(DB.DataTable.Rows[Index]["DateTimeNxtAvail"]);
                CalRecord.DailyCal = Convert.ToString(DB.DataTable.Rows[Index]["DailyCal"]);
                CalRecord.ReqCal = Convert.ToString(DB.DataTable.Rows[Index]["Reqcal"]);
                CalRecord.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                mCalRecordList.Add(CalRecord);
                Index++;
            }
        }
    }
}
