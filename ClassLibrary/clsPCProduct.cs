using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibrary;

namespace ClassLibrary
{
    public class clsPCProduct
    {
        private Int32 mProductID;
        private string mName;
        private string mCategory;
        private Int32 mPrice;
        private string mSupplier;

        public bool Find(Int32 ProductID)
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@ProductID", ProductID);

            DB.Execute("sproc_tblPCProducts_FilterByProductID");

            if (DB.Count == 1)
            {
                mProductID = Convert.ToInt32(DB.DataTable.Rows[0]["ProductID"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mCategory = Convert.ToString(DB.DataTable.Rows[0]["Category"]);
                mPrice = Convert.ToInt32(DB.DataTable.Rows[0]["Price"]);
                mSupplier = Convert.ToString(DB.DataTable.Rows[0]["Supplier"]);


                return true;
            }
            else
            {
                return false;
            }
        }

        public Int32 ProductID
        {
            get
            {
                return mProductID;
            }
            set
            {
                mProductID = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }

        public string Category
        {
            get
            {
                return mCategory;
            }
            set
            {
                mCategory = value;
            }
        }

        public Int32 Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public string Supplier
        {
            get
            {
                return mSupplier;
            }

            set
            {
                mSupplier = value;
            }
        }

        public bool Valid(string name, Int32 price, string category, string supplier)
        {
            Boolean OK = true;

            if (name.Length == 0)
            {
                OK = false;
            }

            if (name.Length > 50)
            {
                OK = false;
            }

            if (category.Length == 0)
            {
                OK = false;
            }

            if (category.Length > 50)
            {
                OK = false;
            }

            if (supplier.Length == 0)
            {
                OK = false;
            }

            if (supplier.Length > 50)
            {
                OK = false;
            }

            return OK;
        }
    }
}
