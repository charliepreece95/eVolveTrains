using System;

namespace ClassLibrary
{
    public class clsClient
    {
        //private data members
        private Int32 mClientID;
        private string mFirstName;
        private string mLastName;
        private string mAddress;
        private string mTelNo;
        private string mEmail;
        private string mHeight;
        private string mAge;
        private string mGender;
        private Int32 mAccountID;
        private string mUsername;
        private string mUserImagePath;

        public Int32 ClientID
        {
            get
            {
                return mClientID;
            }
            set
            {
                mClientID = value;
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

        public string TelNo
        {
            get
            {
                return mTelNo;
            }
            set
            {
                mTelNo = value;
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

        public string Height
        {
            get
            {
                return mHeight;
            }
            set
            {
                mHeight = value;
            }
        }

        public string Age
        {
            get
            {
                return mAge;
            }
            set
            {
                mAge = value;
            }
        }

        public string Gender
        {
            get
            {
                return mGender;
            }
            set
            {
                mGender = value;
            }
        }

        public int AccountID
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

        public string UserImagePath
        {
            get
            {
                return mUserImagePath;
            }
            set
            {
                mUserImagePath = value;
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

        public bool Find(Int32 ClientID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ClientID", ClientID);
            DB.Execute("sproc_tblClient_FilterByClientID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mClientID = Convert.ToInt32(DB.DataTable.Rows[0]["ClientID"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mAddress = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                mTelNo = Convert.ToString(DB.DataTable.Rows[0]["TelNo"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mHeight = Convert.ToString(DB.DataTable.Rows[0]["Height"]);
                mAge = Convert.ToString(DB.DataTable.Rows[0]["Age"]);
                mGender = Convert.ToString(DB.DataTable.Rows[0]["Gender"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                //mAccountID = Convert.ToInt32(DB.DataTable.Rows[0]["AccountID"]);
                //mUserImagePath = Convert.ToString(DB.DataTable.Rows[0]["UserImagePath"]);
                return true;
            }
            //if no record was found
            else
            {
                //return false indicating a problem
                return false;
            }
        }

        public bool Valid(string firstName, string lastName, string address, string telNo, string email, string height, string age, string gender, string username)
        {
            Boolean OK = true;
            //if the name is null
            if (firstName.Length == 0)
            {
                OK = false;
            }
            //if the name is > 50
            if (firstName.Length > 50)
            {
                OK = false;
            }


            return OK;
        }
    }
}