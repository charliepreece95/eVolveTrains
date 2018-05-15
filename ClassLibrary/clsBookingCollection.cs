using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class clsBookingCollection
    {
        
        //class constructor
        public clsBookingCollection(string Username)
        {           
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblBooking_FilterByUsername");
            PopulateArray(DB);         
        }

        //class constructor
        public clsBookingCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblBooking_SelectAll");
            PopulateArray(DB);
        }

        //private data members for the allBookings lists
        private List<clsBooking> mBookingList = new List<clsBooking>();
        //private data member for thisBooking
        clsBooking mThisBooking = new clsBooking();

        //public property for allBookings
        public List<clsBooking> BookingList
        {
            get
            {
                //return the private data member
                return mBookingList;
            }
            set
            {
                //assign the incoming value to the private data member
                mBookingList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mBookingList.Count;
            }
            set
            {

            }
        }

        public clsBooking ThisBooking
        {
            get
            {
                return mThisBooking;
            }
            set
            {
                mThisBooking = value;
            }
        }

        public void DeleteBooking(Int32 BookingID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@BookingID", BookingID);
            DB.Execute("sproc_tblBooking_FilterByBookingID");
            mBookingList = new List<clsBooking>();
            PopulateArray(DB);
        }

        //public constructor for the class
        void PopulateArray(clsDataConnection DB)
        {
            //could change to from int32 to var
            Int32 Index = 0;
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to procress
            while (Index < RecordCount)
            {
                //create a new instance of Booking clas
                clsBooking ABooking = new clsBooking();
                ABooking.BookingID = Convert.ToInt32(DB.DataTable.Rows[Index]["BookingID"]);
                ABooking.Station_Origin = Convert.ToString(DB.DataTable.Rows[Index]["Station_Origin"]);
                ABooking.Station_Destination = Convert.ToString(DB.DataTable.Rows[Index]["Station_Destination"]);
                ABooking.Type = Convert.ToString(DB.DataTable.Rows[Index]["Type"]);
                ABooking.Date = Convert.ToString(DB.DataTable.Rows[Index]["Date"]);
                ABooking.Month = Convert.ToString(DB.DataTable.Rows[Index]["Month"]);
                ABooking.Departure = Convert.ToString(DB.DataTable.Rows[Index]["Departure"]);
          //      ABooking.Arrival = Convert.ToString(DB.DataTable.Rows[Index]["Arrival"]);
                //add the Booking to the private data member
                mBookingList.Add(ABooking);
                Index++;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored proc
            DB.AddParameter("Station_Origin", mThisBooking.Station_Origin);
            DB.AddParameter("Station_Destination", mThisBooking.Station_Destination);
            DB.AddParameter("Type", mThisBooking.Type);
            DB.AddParameter("Date", mThisBooking.Date);
            DB.AddParameter("Month", mThisBooking.Month);
            DB.AddParameter("Departure", mThisBooking.Departure);
           // DB.AddParameter("Arrival", mThisBooking.Arrival);
            DB.AddParameter("Username", mThisBooking.Username);
            //execute the query
            return DB.Execute("sproc_tblBooking_Insert");
        }

        public void Update()
        {
            //update an existing record based on the values of thisBooking
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("BookingID", mThisBooking.BookingID);
            DB.AddParameter("Station_Origin", mThisBooking.Station_Origin);
            DB.AddParameter("Station_Destination", mThisBooking.Station_Destination);
            DB.AddParameter("Type", mThisBooking.Type);
            DB.AddParameter("Date", mThisBooking.Date);
            //execute the stored procedure
            DB.Execute("sproc_tblBooking_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisBooking
            //connect to the DB
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            DB.AddParameter("@BookingID", mThisBooking.BookingID);
            //execute the stored proc
            DB.Execute("sproc_tblBooking_Delete");
        }
    }
}