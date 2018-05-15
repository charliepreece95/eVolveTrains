using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;


namespace ClassLibrary
{
    public class clsHomeOrderCollection
    {
        List<clsHomeOrder> nOrderList = new List<clsHomeOrder>();

        clsHomeOrder mThisOrder = new clsHomeOrder();

        public clsHomeOrderCollection()
        {
            Int32 Index = 0;
            Int32 RecordCount = 0;
            clsDataConnection DB = new clsDataConnection();

            DB.Execute("sproc_tblHomeOrders_SelectAll");

            RecordCount = DB.Count;

            while (Index < RecordCount)
            {
                clsHomeOrder AnOrder = new clsHomeOrder();

                AnOrder.OrderID = Convert.ToInt32(DB.DataTable.Rows[Index]["OrderID"]);
                AnOrder.Username = Convert.ToString(DB.DataTable.Rows[Index]["Username"]);
                AnOrder.DeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["DeliveryDate"]);
                AnOrder.Cart = Convert.ToString(DB.DataTable.Rows[Index]["Cart"]);
                AnOrder.Status = Convert.ToString(DB.DataTable.Rows[Index]["Status"]);
                AnOrder.CardNumber = Convert.ToString(DB.DataTable.Rows[Index]["CardNumber"]);
                AnOrder.ExpireDate = Convert.ToString(DB.DataTable.Rows[Index]["ExpireDate"]);
                AnOrder.CVC = Convert.ToString(DB.DataTable.Rows[Index]["CVC"]);

                mOrderList.Add(AnOrder);

                Index++;
            }
        }

        List<clsHomeOrder> mOrderList = new List<clsHomeOrder>();

        public List<clsHomeOrder> OrderList
        {
            get { return mOrderList; }
            set { mOrderList = value; }
        }

        public int Count
        {
            get { return mOrderList.Count; }
            set { }
        }

        public clsHomeOrder ThisOrder
        {
            get { return mThisOrder; }
            set { mThisOrder = value; }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@Username", mThisOrder.Username);
            DB.AddParameter("@DeliveryDate", mThisOrder.DeliveryDate);
            DB.AddParameter("@Cart", mThisOrder.Cart);
            DB.AddParameter("@Status", mThisOrder.Status);
            DB.AddParameter("@CardNumber", mThisOrder.CardNumber);
            DB.AddParameter("@ExpireDate", mThisOrder.ExpireDate);
            DB.AddParameter("@CVC", mThisOrder.CVC);

            return DB.Execute("sproc_tblHomeOrders_Insert");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();

            DB.AddParameter("@OrderID", mThisOrder.OrderID);
            DB.Execute("sproc_tblHomeOrders_Delete");
        }
    }
}
