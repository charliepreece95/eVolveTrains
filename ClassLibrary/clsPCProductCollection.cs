using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class clsPCProductCollection
    {

        List<clsPCProduct> mProductsList = new List<clsPCProduct>();

        clsPCProduct mThisProduct = new clsPCProduct();

        public clsPCProductCollection()
        {
            Int32 Index = 0;

            Int32 RecordCount = 0;

            clsDataConnection DB = new clsDataConnection();

            DB.Execute("sproc_tblPCProducts_SelectAll");

            RecordCount = DB.Count;

            while (Index < RecordCount)
            {
                clsPCProduct AProduct = new clsPCProduct();

                AProduct.ProductID = Convert.ToInt32(DB.DataTable.Rows[Index]["ProductID"]);
                AProduct.Name = Convert.ToString(DB.DataTable.Rows[Index]["Name"]);
                AProduct.Price = Convert.ToInt32(DB.DataTable.Rows[Index]["Price"]);
                AProduct.Category = Convert.ToString(DB.DataTable.Rows[Index]["Category"]);
                AProduct.Supplier = Convert.ToString(DB.DataTable.Rows[Index]["Supplier"]);

                mProductsList.Add(AProduct);

                Index++;
            }
        }

        public List<clsPCProduct> ProductsList
        {
            get
            {
                return mProductsList;
            }
            set
            {
                mProductsList = value;
            }
        }

        public clsPCProduct ThisProduct
        {
            get
            {
                return mThisProduct;
            }

            set
            {
                mThisProduct = value;
            }
        }



        public int Count
        {
            get
            {
                return mProductsList.Count;
            }

            set
            {

            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@ProductID", mThisProduct.ProductID);
            DB.AddParameter("@Name", mThisProduct.Name);
            DB.AddParameter("@Price", mThisProduct.Price);
            DB.AddParameter("@Category", mThisProduct.Category);
            DB.AddParameter("@Supplier", mThisProduct.Supplier);

            return DB.Execute("sproc_tblPCProducts_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("ProductID", mThisProduct.ProductID);

            DB.Execute("sproc_tblPCProducts_Delete");
        }
    }
}
