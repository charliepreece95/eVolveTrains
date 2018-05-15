using System;

namespace ClassLibrary
{
    public class clsJourney
    {
        private Int32 mJourneyID;
        private string mStationFrom;
        private string mPlatformFrom;
        private string mStationTo;
        private string mPlatformTo;
        private string mPrice;
        private string mDeparture;
        private string mArrival;

        public Int32 JourneyID
        {
            get
            {
                return mJourneyID;
            }
            set
            {
                mJourneyID = value;
            }
        }

        public string StationFrom
        {
            get
            {
                return mStationFrom;
            }
            set
            {
                mStationFrom = value;
            }
        }

        public string PlatformFrom
        {
            get
            {
                return mPlatformFrom;
            }
            set
            {
                mPlatformFrom = value;
            }
        }

        public string StationTo
        {
            get
            {
                return mStationTo;
            }
            set
            {
                mStationTo = value;
            }
        }

        public string PlatformTo
        {
            get
            {
                return mPlatformTo;
            }
            set
            {
                mPlatformTo = value;
            }
        }

        public string Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public string Departure
        {
            get
            {
                return mDeparture;
            }
            set
            {
                mDeparture = value;
            }
        }

        public string Arrival
        {
            get
            {
                return mArrival;
            }
            set
            {
                mArrival = value;
            }
        }
      
        public bool Find(Int32 JourneyID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@JourneyID", JourneyID);
            DB.Execute("sproc_tblJourney_FilterByJourneyID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mJourneyID = Convert.ToInt32(DB.DataTable.Rows[0]["JourneyID"]);
                mStationFrom = Convert.ToString(DB.DataTable.Rows[0]["StationFrom"]);
                mPlatformFrom = Convert.ToString(DB.DataTable.Rows[0]["PlatformFrom"]);
                mStationTo = Convert.ToString(DB.DataTable.Rows[0]["StationTo"]);
                mPlatformTo = Convert.ToString(DB.DataTable.Rows[0]["PlatformTo"]);
                mPrice = Convert.ToString(DB.DataTable.Rows[0]["Price"]);
                mDeparture = Convert.ToString(DB.DataTable.Rows[0]["Departure"]);
                mArrival = Convert.ToString(DB.DataTable.Rows[0]["Arrival"]);
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public bool Valid(string StationFrom, string PlatformFrom, string StationTo, string PlatformTo, string Price, string Departure, string Arrival)
        {
            Boolean OK = true;
            //if the name is null
            if (StationFrom.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (StationFrom.Length > 50)
            {
                OK = false;
            }
            //if the name is null
            if (PlatformFrom.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (PlatformFrom.Length > 2)
            {
                OK = false;
            }
            //if the name is null
            if (StationTo.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (StationTo.Length > 50)
            {
                OK = false;
            }
            //if the name is null
            if (PlatformTo.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (PlatformTo.Length > 2)
            {
                OK = false;
            }
            //if the Price is null
            if (Price.Length < 1)
            {
                OK = false;
            }
            //if the Price is > 11
            if (Price.Length > 7)
            {
                OK = false;
            }
            if (Departure.Length < 1)
            {
                OK = false;
            }
            if (Departure.Length > 5)
            {
                OK = false;
            }
            if (Arrival.Length < 1)
            {
                OK = false;
            }
            if (Arrival.Length > 5)
            {
                OK = false;
            }
            return OK;
        }
    }
}