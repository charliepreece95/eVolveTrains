using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsFitnessRecords
    {
        //class constructor
        public clsFitnessRecords(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblFitnessRecords_FilterByUsername");
            PopulateArray(DB);
        }

        //private data members for the allrecords lists
        private List<clsRecord> mRecordList = new List<clsRecord>();
        //private data member for thisclient
        clsRecord mThisRecord = new clsRecord();

        //public property for allclients
        public List<clsRecord> RecordList
        {
            get
            {
                //return the private data member
                return mRecordList;
            }
            set
            {
                //assign the incoming value to the private data member
                mRecordList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mRecordList.Count;
            }
            set
            {

            }
        }

        public clsRecord ThisRecord
        {
            get
            {
                return mThisRecord;
            }
            set
            {
                mThisRecord = value;
            }
        }

        public void FilterByUsername(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblFitnessRecords_FilterByUsername");
            PopulateArray(DB);
        }

        public void PopulateArray(clsDataConnection DB)
        {
            Int32 Index = 0;
            Int32 RecordCount;
            //get the count of the records
            RecordCount = DB.Count;
            //clear th eprivate record list
            mRecordList = new List<clsRecord>();
            while (Index < RecordCount)
            {
                clsRecord Record = new clsRecord();
                Record.FitRecID = Convert.ToInt32(DB.DataTable.Rows[Index]["FitRecID"]);
                //Record.ClientID = Convert.ToInt32(DB.DataTable.Rows[Index]["ClientID"]);
                Record.DateTimeCurr = Convert.ToString(DB.DataTable.Rows[Index]["DateTimeCurr"]);
                Record.DateTimeNxtAvail = Convert.ToString(DB.DataTable.Rows[Index]["DateTimeNxtAvail"]);
                Record.Calories = Convert.ToString(DB.DataTable.Rows[Index]["Calories"]);
                Record.Weight = Convert.ToString(DB.DataTable.Rows[Index]["Weight"]);
                //Record.Plan = Convert.ToString(DB.DataTable.Rows[Index]["Plan"]);
                Record.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                mRecordList.Add(Record);
                Index++;
            }
        }
    }
}
