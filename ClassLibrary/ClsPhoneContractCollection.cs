using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class ClsPhoneContractCollection
    {
        //private data member for the list 
        List<ClsPhoneContract> mThisPhoneContractsList = new List<ClsPhoneContract>();
        //private data member thisPhoneContracts
        ClsPhoneContract mThisPhoneContractss = new ClsPhoneContract();


        //public property for the PhoneContract list
        public List<ClsPhoneContract> ThisPhoneContractsList
        {
            get
            {
                //return the private data 
                return mThisPhoneContractsList;
            }
            set
            {
                //set the private data 
                mThisPhoneContractsList = value;
            }
        }

        //publuc property for Count 
        public int Count
        {
            get
            {
                //return the count of the list
                return mThisPhoneContractsList.Count;
            }
            set
            {
                //set the provate data
            }
        }


        //constructor for the class
        public ClsPhoneContractCollection()
        {
            //var for the index
            Int32 Index = 0;
            //var to store the record count 
            Int32 RecordCount = 0;
            //object for data connection 
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure 
            DB.Execute("sproc_tblPhoneContract_SelectAll");
            //get the count of records 
            RecordCount = DB.Count;
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank Contract 
                ClsPhoneContract APhoneContract = new ClsPhoneContract();
                //read in the fields from the current records
                APhoneContract.ContractNo = Convert.ToInt32(DB.DataTable.Rows[Index]["ContractNo"]);
                APhoneContract.SpecialFeatures = Convert.ToString(DB.DataTable.Rows[Index]["SpecialFeatures"]);
                APhoneContract.NetworkerProvider = Convert.ToString(DB.DataTable.Rows[Index]["NetworkerProvider"]);
                APhoneContract.DeviceName = Convert.ToString(DB.DataTable.Rows[Index]["DeviceName"]);
                APhoneContract.CapacityGB = Convert.ToString(DB.DataTable.Rows[Index]["CapacityGB"]);
                APhoneContract.MonthlyPayment = Convert.ToString(DB.DataTable.Rows[Index]["MonthlyPayment"]);
                APhoneContract.Duration = Convert.ToString(DB.DataTable.Rows[Index]["Duration"]);
                APhoneContract.GetContract = Convert.ToString(DB.DataTable.Rows[Index]["GetContract"]);
                //add the record to the private data memeber 
                mThisPhoneContractsList.Add(APhoneContract);
                //point at the next record 
                Index++;
            }
        }
        public ClsPhoneContract ThisPhoneContractss
        {
            get
            {
                //return the private data
                return mThisPhoneContractss;
                //
            }
            set
            {
                //set the private data
                mThisPhoneContractss = value;
            }
        }

        public int Add()
        {
            //adds a new record to the database based on the values of thisPhoneContract
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            //DB.AddParameter("@ContractNo", mThisPhoneContractss.ContractNo);
            DB.AddParameter("@DeviceName", mThisPhoneContractss.DeviceName);
            DB.AddParameter("@NetworkerProvider", mThisPhoneContractss.NetworkerProvider);
            DB.AddParameter("@SpecialFeatures", mThisPhoneContractss.SpecialFeatures);
            DB.AddParameter("@CapacityGB", mThisPhoneContractss.CapacityGB);
            DB.AddParameter("@MonthlyPayment", mThisPhoneContractss.MonthlyPayment);
            DB.AddParameter("@Duration", mThisPhoneContractss.Duration);
            DB.AddParameter("@GetContract", mThisPhoneContractss.GetContract); 

            //execute the query returning the PK balue
            return DB.Execute("sproc_tblPhoneContract_Insert");
        }

        public void Update()
        {
            //update an existing record based on the values of thisPhoneContractss
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            //DB.AddParameter("ContractNo", mThisPhoneContractss.ContractNo);
            DB.AddParameter("DeviceName", mThisPhoneContractss.DeviceName);
            DB.AddParameter("NetworkerProvider", mThisPhoneContractss.NetworkerProvider);
            DB.AddParameter("SpecialFeatures", mThisPhoneContractss.SpecialFeatures);
            DB.AddParameter("CapacityGB", mThisPhoneContractss.CapacityGB);
            DB.AddParameter("MonthlyPayment", mThisPhoneContractss.MonthlyPayment);
            DB.AddParameter("Duration", mThisPhoneContractss.Duration);
            DB.AddParameter("GetContract", mThisPhoneContractss.GetContract);
            //execute the stored procedure
            DB.Execute("sproc_tblPhoneContract_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisPhoneContract
            //connect to the DB
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            DB.AddParameter("@ContractNo", mThisPhoneContractss.ContractNo);
            //execute the stored proc
            DB.Execute("sproc_tblPhoneContract_Delete");
        }
    }
}
