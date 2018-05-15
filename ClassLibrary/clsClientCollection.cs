using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    public class clsClientCollection
    {
        //public constructor for the class
        public clsClientCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            //create an instance of the db connection
            clsDataConnection DB = new clsDataConnection();
            //execute the sproc 
            DB.Execute("sproc_tblClient_SelectAll");
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to procress
            while (Index < RecordCount)
            {
                //create a new instance of client clas
                clsClient AClient = new clsClient();
                AClient.ClientID = Convert.ToInt32(DB.DataTable.Rows[Index]["ClientID"]);
                AClient.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                AClient.LastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                AClient.Address = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                AClient.TelNo = Convert.ToString(DB.DataTable.Rows[0]["TelNo"]);
                AClient.Email = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                AClient.Height = Convert.ToString(DB.DataTable.Rows[0]["Height"]);
                AClient.Age = Convert.ToString(DB.DataTable.Rows[0]["Age"]);
                AClient.Gender = Convert.ToString(DB.DataTable.Rows[0]["Gender"]);
                AClient.AccountID = Convert.ToInt32(DB.DataTable.Rows[0]["AccountID"]);
                AClient.UserImagePath = Convert.ToString(DB.DataTable.Rows[0]["UserImagePath"]);
                //add the client to the private data member
                mClientList.Add(AClient);
                Index++;
            }
        }

        //private data members for the allclients lists
        private List<clsClient> mClientList = new List<clsClient>();
        //private data member for thisclient
        clsClient mThisClient = new clsClient();


        //public property for allclients
        public List<clsClient> ClientList
        {
            get
            {
                //return the private data member
                return mClientList;
            }
            set
            {
                //assign the incoming value to the private data member
                mClientList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mClientList.Count;
            }
            set
            {
                
            }
        }

        public clsClient ThisClient
        {
            get
            {
                return mThisClient;
            }
            set
            {
                mThisClient = value;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored proc
            DB.AddParameter("FirstName", mThisClient.FirstName);
            DB.AddParameter("LastName", mThisClient.LastName);
            DB.AddParameter("Address", mThisClient.Address);
            DB.AddParameter("TelNo", mThisClient.TelNo);
            DB.AddParameter("Email", mThisClient.Email);
            DB.AddParameter("Height", mThisClient.Height);
            DB.AddParameter("Age", mThisClient.Age);
            DB.AddParameter("Gender", mThisClient.Gender);
            DB.AddParameter("UserImagePath", mThisClient.UserImagePath);
            //execute the query
            return DB.Execute("sproc_tblClient_Insert");
        }
    }
}