using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    public class clsPersonCollection
    {
        public clsPersonCollection(string Username)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Username", Username);
            DB.Execute("sproc_tblPerson_FilterByUsername");
            PopulateArray(DB);
        }

        public clsPersonCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure 
            DB.Execute("sproc_tblPerson_SelectAll");
            PopulateArray(DB);
        }

        //private data members for the allPersons lists
        private List<clsPerson> mPersonList = new List<clsPerson>();
        //private data member for thisPerson
        clsPerson mThisPerson = new clsPerson();


        //public property for allPersons
        public List<clsPerson> PersonList
        {
            get
            {
                //return the private data member
                return mPersonList;
            }
            set
            {
                //assign the incoming value to the private data member
                mPersonList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mPersonList.Count;
            }
            set
            {

            }
        }

        public clsPerson ThisPerson
        {
            get
            {
                return mThisPerson;
            }
            set
            {
                mThisPerson = value;
            }
        }

        void PopulateArray(clsDataConnection DB)
        {
            //could change to from int32 to var
            Int32 Index = 0;
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = DB.Count;
            //list all records
            mPersonList = new List<clsPerson>();
            //while there are records to procress
            while (Index < RecordCount)
            {
                //create a new instance of Person clas
                clsPerson APerson = new clsPerson();
                APerson.PersonID = Convert.ToInt32(DB.DataTable.Rows[Index]["PersonID"]);
                APerson.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                APerson.LastName = Convert.ToString(DB.DataTable.Rows[Index]["LastName"]);
                APerson.Address = Convert.ToString(DB.DataTable.Rows[Index]["Address"]);
                APerson.TeleNo = Convert.ToString(DB.DataTable.Rows[Index]["TeleNo"]);
                APerson.Email = Convert.ToString(DB.DataTable.Rows[Index]["Email"]);
                APerson.DoB = Convert.ToString(DB.DataTable.Rows[Index]["DoB"]);
                APerson.Postcode = Convert.ToString(DB.DataTable.Rows[Index]["Postcode"]);
                APerson.Town = Convert.ToString(DB.DataTable.Rows[Index]["Town"]);
                APerson.Postcode = Convert.ToString(DB.DataTable.Rows[Index]["Postcode"]);
                APerson.Country = Convert.ToString(DB.DataTable.Rows[Index]["Country"]);
                APerson.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                //add the Person to the private data member
                mPersonList.Add(APerson);
                Index++;
            }
        }

        public void FilterByName(string Username)
        {
            //create an instance
            clsDataConnection DB = new clsDataConnection();
            //parameter firstname to be filtered
            DB.AddParameter("@Username", Username);
            //execute the filter stored procedure
            DB.Execute("sproc_tblPerson_FilterByUsername");
            //call the populateArray function
            PopulateArray(DB);
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored proc
            DB.AddParameter("FirstName", mThisPerson.FirstName);
            DB.AddParameter("LastName", mThisPerson.LastName);
            DB.AddParameter("Address", mThisPerson.Address);
            DB.AddParameter("TeleNo", mThisPerson.TeleNo);
            DB.AddParameter("Email", mThisPerson.Email);
            DB.AddParameter("DoB", mThisPerson.DoB);
            DB.AddParameter("Postcode", mThisPerson.Postcode);
            DB.AddParameter("Town", mThisPerson.Town);
            DB.AddParameter("Country", mThisPerson.Country);
            DB.AddParameter("Username", mThisPerson.Username);
            //execute the query
            return DB.Execute("sproc_tblPerson_Insert_User");

        }

        public void Update()
        {
            //update an existing record based on the values of thisPerson
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("PersonID", mThisPerson.PersonID);
            DB.AddParameter("FirstName", mThisPerson.FirstName);
            DB.AddParameter("LastName", mThisPerson.LastName);
            DB.AddParameter("Address", mThisPerson.Address);
            DB.AddParameter("TeleNo", mThisPerson.TeleNo);
            DB.AddParameter("Email", mThisPerson.Email);
            DB.AddParameter("DoB", mThisPerson.DoB);
            DB.AddParameter("Postcode", mThisPerson.Postcode);
            DB.AddParameter("Town", mThisPerson.Town);
            DB.AddParameter("Country", mThisPerson.Country);
            DB.AddParameter("Username", mThisPerson.Username);
            //execute the stored procedure
            DB.Execute("sproc_tblPerson_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisPerson
            //connect to the DB
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            DB.AddParameter("@PersonID", mThisPerson.PersonID);
            //execute the stored proc
            DB.Execute("sproc_tblPerson_Delete");
        }
    }
}