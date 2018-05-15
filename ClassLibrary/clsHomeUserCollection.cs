using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using ClassLibrary;

namespace ClassLibrary
{
    public class clsHomeUserCollection
    {
        List<clsHomeUser> nHomeUserList = new List<clsHomeUser>();
        clsHomeUser mThisUser = new clsHomeUser();

        public clsHomeUserCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();
            DB.Execute("sproc_tblCustomer_SelectAll");
            RecordCount = DB.Count;

            while (Index < RecordCount)
            {
                clsHomeUser AUser = new clsHomeUser();

                AUser.CustomerID = Convert.ToInt32(DB.DataTable.Rows[Index]["CustomerID"]);
                AUser.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                AUser.LastName = Convert.ToString(DB.DataTable.Rows[Index]["LastName"]);
                AUser.Email = Convert.ToString(DB.DataTable.Rows[Index]["Email"]);
                AUser.AddressLine1 = Convert.ToString(DB.DataTable.Rows[Index]["AddressLine1"]);
                AUser.AddressLine2 = Convert.ToString(DB.DataTable.Rows[Index]["AddressLine2"]);
                AUser.City = Convert.ToString(DB.DataTable.Rows[Index]["City"]);
                AUser.Region = Convert.ToString(DB.DataTable.Rows[Index]["Region"]);
                AUser.PostCode = Convert.ToString(DB.DataTable.Rows[Index]["PostCode"]);
                AUser.Country = Convert.ToString(DB.DataTable.Rows[Index]["Country"]);
                AUser.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                AUser.ProfileImagePath = Convert.ToString(DB.DataTable.Rows[Index]["ProfileImagePath"]);
                AUser.Telephone = Convert.ToString(DB.DataTable.Rows[Index]["Telephone"]);
                //AUser.AccountID = Convert.ToInt32(DB.DataTable.Rows[Index]["AccountID"]);

                mHomeUserList.Add(AUser);

                Index++;
            }
        }

        List<clsHomeUser> mHomeUserList = new List<clsHomeUser>();
        public List<clsHomeUser> HomeUserList
        {
            get { return mHomeUserList; } set { mHomeUserList = value; }
        }
        public clsHomeUser ThisHomeUser
        {
            get { return mThisUser; } set { mThisUser = value; }
        }

        public int Count { get { return mHomeUserList.Count; } set { } }

        //
        // Add / Edit / Delete Not Required
        //
        //

    }
}
