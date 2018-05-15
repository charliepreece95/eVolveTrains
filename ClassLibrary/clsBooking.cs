using System;

namespace ClassLibrary
{
    public class clsBooking
    {
        //private data members
        private Int32 mBookingID;
        private string mStation_Origin;
        private string mStation_Destination;
        private string mPlatform;
        private string mType;
        private string mDate;
        private string mMonth;
        private string mPrice;
        private string mDeparture;
        private string mArrival;
        private string mUsername;

        public Int32 BookingID
        {
            get
            {
                return mBookingID;
            }
            set
            {
                mBookingID = value;
            }
        }

        public string Station_Origin
        {
            get
            {
                return mStation_Origin;
            }
            set
            {
                mStation_Origin = value;
            }
        }

        public string Station_Destination 
        {
            get
            {
                return mStation_Destination;
            }
            set
            {
                mStation_Destination = value;
            }
        }

        public string Platform
        {
            get
            {
                return mPlatform;
            }
            set
            {
                mPlatform = value;
            }
        }

        public string Type
        {
            get
            {
                return mType;
            }
            set
            {
                mType = value;
            }
        }

        public string Date
        {
            get
            {
                return mDate;
            }
            set
            {
                mDate = value;
            }
        }

        public string Month
        {
            get
            {
                return mMonth;
            }
            set
            {
                mMonth = value;
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

        public bool Find(Int32 BookingID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@BookingID", BookingID);
            DB.Execute("sproc_tblBooking_FilterByBookingID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mBookingID = Convert.ToInt32(DB.DataTable.Rows[0]["BookingID"]);
                mStation_Origin = Convert.ToString(DB.DataTable.Rows[0]["Station_Origin"]);
                mStation_Destination = Convert.ToString(DB.DataTable.Rows[0]["Station_Destination"]);
                mType = Convert.ToString(DB.DataTable.Rows[0]["Type"]);
                mDate = Convert.ToString(DB.DataTable.Rows[0]["Date"]);
                mMonth = Convert.ToString(DB.DataTable.Rows[0]["Month"]);
                mDeparture = Convert.ToString(DB.DataTable.Rows[0]["Departure"]);
           //     mArrival = Convert.ToString(DB.DataTable.Rows[0]["Arrival"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                return true;
            }
            //if no record found?
            else
            {
                return false;
            }
        }

        public bool Valid(string Station_Origin, string Station_Destination, string Type, string Date, string Month, string Departure)
        {
            Boolean OK = true;

            //if the name is null
            if (Station_Origin.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (Station_Origin.Length > 50)
            {
                OK = false;
            }
            //if the name is null
            if (Station_Destination.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (Station_Destination.Length > 50)
            {
                OK = false;
            }
            //if the Type is null
            if (Type.Length < 1)
            {
                OK = false;
            }
            //if the Type is > 11
            if (Type.Length > 12)
            {
                OK = false;
            }
            //if the Date is null
            if (Date.Length < 1)
            {
                OK = false;
            }
            //if the Date is > 50
            if (Date.Length > 50)
            {
                OK = false;
            }
            //if the Date is null
            if (Month.Length < 1)
            {
                OK = false;
            }
            //if the Date is > 50
            if (Month.Length > 50)
            {
                OK = false;
            }
            //if the Date is null
            if (Departure.Length < 1)
            {
                OK = false;
            }
            //if the Date is > 50
            if (Departure.Length > 50)
            {
                OK = false;
            }
            return OK;
        }
    }
}