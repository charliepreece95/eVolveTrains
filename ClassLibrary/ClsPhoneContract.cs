using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class ClsPhoneContract
    {
        //private data for the ContractNo field
        private Int32 mContractNo;
        //private data for the SpecialFeatures field
        private string mSpecialFeatures;
        //prviate data for the NetworkProvider field
        private string mNetworkerProvider;
        //private data for the DeviceName field
        private string mDeviceName;
        //private data for the Capacity field
        private string mCapacityGB;
        //private data for the MonthlyPayment field
        private string mMonthlyPayment;
        //private data for duration field
        private string mDuration;
        //private data for Get Contract field
        private string mGetContract;

        //public property for the ContractNo
        public int ContractNo
        {
            get
            {
                //return the private data
                return mContractNo;
            }
            set
            {
                //set the value of the private data 
                mContractNo = value;
            }
        }

        //public property for the SpecialFeature
        public string SpecialFeatures
        {
            get
            {
                //return the private data 
                return mSpecialFeatures;
            }
            set
            {
                //set the value of the prviate
                mSpecialFeatures = value;
            }
        }

        //public property for the NetworkProvider
        public string NetworkerProvider
        {
            get
            {
                //return the private data
                return mNetworkerProvider;
            }
            set
            {
                //set the value of the private data 
                mNetworkerProvider = value;
            }
        }

        //public property for the DeviceName
        public string DeviceName
        {
            get
            {
                //return the private data
                return mDeviceName;
            }
            set
            {
                //set the value of the private data 
                mDeviceName = value;
            }
        }

        //public property for the CapacityGB
        public string CapacityGB
        {
            get
            {
                //return the private data
                return mCapacityGB;
            }
            set
            {
                //set the value of the private data 
                mCapacityGB = value;
            }
        }

        //public property for the MonthlyPayment
        public string MonthlyPayment
        {
            get
            {
                //return the private data
                return mMonthlyPayment;
            }
            set
            {
                //set the value of the private data 
                mMonthlyPayment = value;
            }
        }

        //public property for the Duration
        public string Duration
        {
            get
            {
                //return the private data
                return mDuration;
            }
            set
            {
                //set the value of the private data 
                mDuration = value;
            }
        }

        //public property for the GetContract
        public string GetContract
        {
            get
            {
                //return the private data
                return mGetContract;
            }
            set
            {
                //set the value of the private data 
                mGetContract = value;
            }
        }

        public bool Find(int ContractNo)
        {
            //crate an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            //add the parameter for the staff no to search for
            DB.AddParameter("@ContractNo", ContractNo);
            //execute the sotred proc
            DB.Execute("sproc_tblPhoneContract_filterByContractNo");
            //if one record if found (There should be either one or zero!)
            if (DB.Count == 1)
            {
                //copy from the db to the private data members
                mContractNo = Convert.ToInt32(DB.DataTable.Rows[0]["ContractNo"]);
                mSpecialFeatures = Convert.ToString(DB.DataTable.Rows[0]["SpecialFeatures"]);
                mNetworkerProvider = Convert.ToString(DB.DataTable.Rows[0]["NetworkerProvider"]);
                mDeviceName = Convert.ToString(DB.DataTable.Rows[0]["DeviceName"]);
                mCapacityGB = Convert.ToString(DB.DataTable.Rows[0]["CapacityGB"]);
                mMonthlyPayment = Convert.ToString(DB.DataTable.Rows[0]["MonthlyPayment"]);
                mDuration = Convert.ToString(DB.DataTable.Rows[0]["Duration"]);
                mGetContract = Convert.ToString(DB.DataTable.Rows[0]["GetContract"]);
                //return that everything worked OK
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }


        }

        public bool Valid(string SpecialFeatures, string NetworkerProvider, string DeviceName, string CapacityGB, string MonthlyPayment, string Duration, string GetContract)
        {
            //create a boolean var to flag the error
            Boolean OK = true;
            //if the FirstName is blank
            if (SpecialFeatures.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the SpecialFeatures is greater than 40 chars
            if (SpecialFeatures.Length > 40)
            {
                //set the flag to false
                OK = false;
            }
            if (NetworkerProvider.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the NetworkProvider is greater than 20 chars
            if (NetworkerProvider.Length > 20)
            {
                //set the flag to false
                OK = false;
            }
            if (DeviceName.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the DeviceName is greater than 40 chars
            if (DeviceName.Length > 40)
            {
                //set the flag to false
                OK = false;
            }
            if (CapacityGB.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the CapacityGB is greater than 20 chars
            if (CapacityGB.Length > 10)
            {
                //set the flag to false
                OK = false;
            }
            if (MonthlyPayment.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the MonthlyPayment is greater than 20 chars
            if (MonthlyPayment.Length > 10)
            {
                //set the flag to false
                OK = false;
            }
            if (Duration.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the MonthlyPayment is greater than 20 chars
            if (Duration.Length > 10)
            {
                //set the flag to false
                OK = false;
            }
            if (GetContract.Length == 0)
            {
                //set the flag OK to false
                OK = false;
            }
            //if the GetContract is greater than 50 chars
            if (GetContract.Length > 50)
            {
                //set the flag to false
                OK = false;
            }

            //return the value of OK
            return OK;
        }


    }
}
