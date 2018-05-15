using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

namespace ClassLibrary
{
    public class clsHomeUser
    {
        private Int32 mCustomerID;
        private string mFirstName;
        private string mLastName;
        private string mEmail;
        private string mAddressLine1;
        private string mAddressLine2;
        private string mCity;
        private string mRegion;
        private string mPostCode;
        private string mCountry;
        private string mUsername;
        private string mProfileImagePath;
        private string mTelephone;
        //private Int32 mAccountID;

        public Int32 CustomerID { get { return mCustomerID; } set { mCustomerID = value; } }
        public string FirstName { get { return mFirstName; } set { mFirstName = value; } }
        public string LastName { get { return mLastName; } set { mLastName = value; } }
        public string Email { get { return mEmail; } set { mEmail = value; } }
        public string AddressLine1 { get { return mAddressLine1; } set { mAddressLine1 = value; } }
        public string AddressLine2 { get { return mAddressLine2; } set { mAddressLine2 = value; } }
        public string City { get { return mCity; } set { mCity = value; } }
        public string Region { get { return mRegion; } set { mRegion = value; } }
        public string PostCode { get { return mPostCode; } set { mPostCode = value; } }
        public string Country { get { return mCountry; } set { mCountry = value; } }
        public string Username { get { return mUsername; } set { mUsername = value; } }
        public string ProfileImagePath { get { return mProfileImagePath; } set { mProfileImagePath = value; } }
        public string Telephone { get { return mTelephone; } set { mTelephone = value; } }
        //public Int32 AccountID { get { return mAccountID; } set { mAccountID = value; } }

        // valid method to go here if time allows

        //public Find methid 
        public bool Find (Int32 CustomerID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CustomerID", CustomerID);
            DB.Execute("sproc_tblCustomer_FilterByCustomerID");
            if (DB.Count == 1)
            {
                mCustomerID = Convert.ToInt32(DB.DataTable.Rows[0]["CustomerID"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mAddressLine1 = Convert.ToString(DB.DataTable.Rows[0]["AddressLine1"]);
                mAddressLine2 = Convert.ToString(DB.DataTable.Rows[0]["AddressLine2"]);
                mCity = Convert.ToString(DB.DataTable.Rows[0]["City"]);
                mRegion = Convert.ToString(DB.DataTable.Rows[0]["Region"]);
                mPostCode = Convert.ToString(DB.DataTable.Rows[0]["PostCode"]);
                mCountry = Convert.ToString(DB.DataTable.Rows[0]["Country"]);
                mProfileImagePath = Convert.ToString(DB.DataTable.Rows[0]["ProfileImagePath"]);
                mTelephone = Convert.ToString(DB.DataTable.Rows[0]["Telephone"]);
                //mAccountID = Convert.ToInt32(DB.DataTable.Rows[0]["AccountID"]);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
