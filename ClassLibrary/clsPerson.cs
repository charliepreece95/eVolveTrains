using System;

namespace ClassLibrary
{
    public class clsPerson
    {
        //private data members
        private Int32 mPersonID;
        private string mFirstName;
        private string mLastName;
        private string mAddress;
        private string mPostcode;
        private string mTeleNo;
        private string mDoB;
        private string mTown;
        private string mCountry;
        private string mEmail;
        private string mUsername;

        public Int32 PersonID
        {
            get
            {
                return mPersonID;
            }
            set
            {
                mPersonID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return mFirstName;
            }
            set
            {
                mFirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return mLastName;
            }
            set
            {
                mLastName = value; 
            }
        }
   
        public string Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                mAddress = value;
            }
        }

        public string TeleNo
        {
            get
            {
                return mTeleNo;
            }
            set
            {
                mTeleNo = value;
            }
        }

        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }

        public string DoB
        {
            get
            {
                return mDoB;
            }
            set
            {
                mDoB = value;
            }
        }

        public string Postcode
        {
            get
            {
                return mPostcode;
            }
            set
            {
                mPostcode = value;
            }
        }

        public string Town
        {
            get
            {
                return mTown;
            }
            set
            {
                mTown = value;
            }
        }

        public string Country
        {
            get
            {
                return mCountry;
            }
            set
            {
                mCountry = value;
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

        /*
        public Int32 AccountID
        {
            get
            {
                return mAccountID;
            }
            set
            {
                mAccountID = value;
            }
                 
        }
        */

        public bool Find(Int32 PersonID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@PersonID", PersonID);
            DB.Execute("sproc_tblPerson_FilterByPersonID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mPersonID = Convert.ToInt32(DB.DataTable.Rows[0]["PersonID"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mAddress = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                mTeleNo = Convert.ToString(DB.DataTable.Rows[0]["TeleNo"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mDoB = Convert.ToString(DB.DataTable.Rows[0]["DoB"]);
                mPostcode = Convert.ToString(DB.DataTable.Rows[0]["Postcode"]);
                mTown = Convert.ToString(DB.DataTable.Rows[0]["Town"]);
                mCountry = Convert.ToString(DB.DataTable.Rows[0]["Country"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                //mAccountID = Convert.ToInt32(DB.DataTable.Rows[0]["AccountID"]);
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public bool Valid(string FirstName, string LastName, string Address, string TeleNo, string Email, string DoB, string Postcode, string Town, string Country, string Username)
        {
            Boolean OK = true;
            //if the name is null
            if (FirstName.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (FirstName.Length > 50)
            {
                OK = false;
            }
            //if the name is null
            if (LastName.Length < 1)
            {
                OK = false;
            }
            //if the name is > 50
            if (LastName.Length > 50)
            {
                OK = false;
            }
            //if the address is null
            if (Address.Length < 1)
            {
                OK = false;
            }
            //if the address is > 50
            if (Address.Length > 50)
            {
                OK = false;
            }           
            //if the TeleNo is null
            if (TeleNo.Length < 1)
            {
                OK = false;
            }
            //if the TeleNo is > 11
            if  (TeleNo.Length > 11)
            {
                OK = false;
            }
     
            //if the dob is null
            if (DoB.Length < 1)
            {
                OK = false;
            }
            //if the dob is > 10
            if (DoB.Length > 10)
            {
                OK = false;
            }

            //if the postcode is null 
            if (Postcode.Length < 1)
            {
                OK = false;
            }
            //if the postcode is > 8
            if (Postcode.Length > 8)
            {
                OK = false;
            }
     
            //if the email is null
            if (Email.Length < 1)
            {
                OK = false;
            }
            //if the email is > 50
            if (Email.Length > 50)
            {
                OK = false;
            }
            
            //if the town is null
            if (Town.Length == 0)
            {
                OK = false;
            }
            //if the town is > 50
            if (Town.Length > 50)
            {
                OK = false;
            }
            
            //if the country is null
            if (Country.Length == 0)
            {
                OK = false;
            }
            //if the country is > 500
            if (Country.Length > 50)
            {
                OK = false;
            }

            //if the country is null
            if (Username.Length == 0)
            {
                OK = false;
            }
            //if the country is > 500
            if (Username.Length > 50)
            {
                OK = false;
            }

            return OK;
        }
    }
}