using System;
using System.Collections.Generic;


namespace ClassLibrary
{
    public class clsJourneyCollection
    {

        //class constructor
        public clsJourneyCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure 
            DB.Execute("sproc_tblJourney_SelectAll");
            PopulateArray(DB);
        }

        //private data members for the allJourneys lists
        List<clsJourney> mJourneyList = new List<clsJourney>();
        //private data member for thisJourney
        clsJourney mThisJourney = new clsJourney();

        //public property for allJourneys
        public List<clsJourney> JourneyList
        {
            get
            {
                //return the private data member
                return mJourneyList;
            }
            set
            {
                //assign the incoming value to the private data member
                mJourneyList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mJourneyList.Count;
            }
            set
            {
                //empty set 
            }
        }

        public clsJourney ThisJourney
        {
            get
            {
                return mThisJourney;
            }
            set
            {
                mThisJourney = value;
            }
        }

        //public constructor for the class
        void PopulateArray(clsDataConnection DB)
        {
            //could change to from int32 to var
            Int32 Index = 0;
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = DB.Count;
            //list records
            mJourneyList = new List<clsJourney>();
            //while there are records to procress
            while (Index < RecordCount)
            {
                //create a new instance of Journey clas
                clsJourney AJourney = new clsJourney();
                AJourney.JourneyID = Convert.ToInt32(DB.DataTable.Rows[Index]["JourneyID"]);
                AJourney.StationFrom = Convert.ToString(DB.DataTable.Rows[Index]["StationFrom"]);
                AJourney.PlatformFrom = Convert.ToString(DB.DataTable.Rows[Index]["PlatformFrom"]);
                AJourney.StationTo = Convert.ToString(DB.DataTable.Rows[Index]["StationTo"]);
                AJourney.PlatformTo = Convert.ToString(DB.DataTable.Rows[Index]["PlatformTo"]);
                AJourney.Price = Convert.ToString(DB.DataTable.Rows[Index]["Price"]);
                AJourney.Departure = Convert.ToString(DB.DataTable.Rows[Index]["Departure"]);
                AJourney.Arrival = Convert.ToString(DB.DataTable.Rows[Index]["Arrival"]);
                //add the Journey to the private data member
                mJourneyList.Add(AJourney);
                Index++;
            }
        }

        public void FilterByStation(string Station, string Platform)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Station", Station);
            DB.AddParameter("@Platform", Platform);
            DB.Execute("sproc_tblJourney_FilterByStation");
            PopulateArray(DB);
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored proc
            DB.AddParameter("StationFrom", mThisJourney.StationFrom);
            DB.AddParameter("PlatformFrom", mThisJourney.PlatformFrom);
            DB.AddParameter("StationTo", mThisJourney.StationTo);
            DB.AddParameter("PlatformTo", mThisJourney.PlatformTo);
            DB.AddParameter("Price", mThisJourney.Price);
            DB.AddParameter("Departure", mThisJourney.Departure);
            DB.AddParameter("Arrival", mThisJourney.Arrival);
            //execute the query
            return DB.Execute("sproc_tblJourney_Insert");
        }

        public void Update()
        {
            //update an existing record based on the values of thisJourney
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("StationFrom", mThisJourney.StationFrom);
            DB.AddParameter("PlatformFrom", mThisJourney.PlatformFrom);
            DB.AddParameter("StationTo", mThisJourney.StationTo);
            DB.AddParameter("PlatformTo", mThisJourney.PlatformTo);
            DB.AddParameter("Price", mThisJourney.Price);
            DB.AddParameter("Departure", mThisJourney.Departure);
            DB.AddParameter("Arrival", mThisJourney.Arrival);
            //execute the stored procedure
            DB.Execute("sproc_tblJourney_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisJourney
            //connect to the DB
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            DB.AddParameter("@JourneyID", mThisJourney.JourneyID);
            //execute the stored proc
            DB.Execute("sproc_tblJourney_Delete");
        }
    }
}