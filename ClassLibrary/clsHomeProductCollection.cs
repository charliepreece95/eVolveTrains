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
    public class clsHomeProductCollection
    {
        //private data member for the list
        List<clsHomeProduct> nHomeProductList = new List<clsHomeProduct>();
        //private data member thislist
        clsHomeProduct mThisHomeProduct = new clsHomeProduct();
        //Class Constructor Here
        public clsHomeProductCollection()
        {
            Int32 Index = 0;
            //var to store the record
            Int32 RecordCount = 0;
            //object for the data connection
            clsDataConnection DB = new clsDataConnection();
            //execute the stored proc
            DB.Execute("sproc_tblHomeProduct_SelectAll");
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to process
            while (Index < RecordCount)
            {
                //create AProduct
                clsHomeProduct AProduct = new clsHomeProduct();
                //read in the fields from current record
                AProduct.ProductID = Convert.ToInt32(DB.DataTable.Rows[Index]["ProductID"]);
                AProduct.Name = Convert.ToString(DB.DataTable.Rows[Index]["Name"]);
                AProduct.Price = Convert.ToInt32(DB.DataTable.Rows[Index]["Price"]);
                AProduct.Type = Convert.ToString(DB.DataTable.Rows[Index]["Type"]);
                AProduct.Collection = Convert.ToString(DB.DataTable.Rows[Index]["Collection"]);
                AProduct.Description = Convert.ToString(DB.DataTable.Rows[Index]["Description"]);
                AProduct.Dimentions = Convert.ToString(DB.DataTable.Rows[Index]["Dimentions"]);
                //add the record to the private data member
                mHomeProductList.Add(AProduct);
                //pointy at the record
                Index++;

            }
        }

        //private data member for the list
        List<clsHomeProduct> mHomeProductList = new List<clsHomeProduct>();
        public List<clsHomeProduct> HomeProductList
        {
            get { return mHomeProductList; }
            set { mHomeProductList = value; }
        }

        public clsHomeProduct ThisHomeProduct
        {
            get { return mThisHomeProduct; }
            set { mThisHomeProduct = value; }
        }


        public int Count { get { return mHomeProductList.Count; } set { } }

        public int Add()
        {
            //Add new record to the DB
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Name", mThisHomeProduct.Name);
            DB.AddParameter("@Price", mThisHomeProduct.Price);
            DB.AddParameter("@Type", mThisHomeProduct.Type);
            DB.AddParameter("@Collection", mThisHomeProduct.Collection);
            DB.AddParameter("@Description", mThisHomeProduct.Description);
            DB.AddParameter("@Dimentions", mThisHomeProduct.Dimentions);
            //execute the query
            return DB.Execute("sproc_tblHomeProduct_Insert");
        }


        public void Delete()
        {
            //To Remove a record
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("ProductID", mThisHomeProduct.ProductID);
            //execute the sproc
            DB.Execute("sproc_tblHomeProduct_Delete");
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}