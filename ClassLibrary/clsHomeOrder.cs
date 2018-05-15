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
    public class clsHomeOrder
    {
        private Int32 mOrderID;
        private string mUsername;
        private DateTime mDeliveryDate;
        private string mCart;
        private string mStatus;
        private string mCardNumber;
        private string mExpireDate;
        private string mCVC;

        public int OrderID { get { return mOrderID; } set { mOrderID = value; } }
        public string Username { get { return mUsername; } set { mUsername = value; } }
        public DateTime DeliveryDate { get { return mDeliveryDate; } set { mDeliveryDate = value; } }
        public string Cart { get { return mCart; } set { mCart = value; } }
        public string Status { get { return mStatus; } set { mStatus = value; } }
        public string CardNumber { get { return mCardNumber; } set { mCardNumber = value; } }
        public string ExpireDate { get { return mExpireDate; } set { mExpireDate = value; } }
        public string CVC { get { return mCVC; } set { mCVC = value; } }



        public bool Find(int OrderID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@OrderID", OrderID);
            DB.Execute("sproc_tblHomeOrders_FilterByOrderID");

            if (DB.Count == 1)
            {
                mOrderID = Convert.ToInt32(DB.DataTable.Rows[0]["OrderID"]);
                mUsername = Convert.ToString(DB.DataTable.Rows[0]["Username"]);
                mDeliveryDate = Convert.ToDateTime(DB.DataTable.Rows[0]["DeliveryDate"]);
                mCart = Convert.ToString(DB.DataTable.Rows[0]["Cart"]);
                mStatus = Convert.ToString(DB.DataTable.Rows[0]["Status"]);
                mCardNumber = Convert.ToString(DB.DataTable.Rows[0]["CardNumber"]);
                mExpireDate = Convert.ToString(DB.DataTable.Rows[0]["ExpireDate"]);
                mCVC = Convert.ToString(DB.DataTable.Rows[0]["CVC"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Valid(string DeliveryDate, string Status, string CardNumber, string ExpireDate, string CVC)
        {
            Boolean OK = true;

            DateTime DateTemp;

            try
            {
                DateTemp = Convert.ToDateTime(DeliveryDate);
                if (DateTemp <= DateTime.Now.Date)
                {
                    OK = false;
                }
                if (DateTemp > DateTime.Now.Date.AddYears(2))
                {
                    OK = false;
                }
            }
            catch
            {
                OK = false;
            }
            /*
            if (Cart.Length == 0)
            {
                OK = false;
            }
            */
            if (Status.Length == 0)
            {
                OK = false;
            }

            if (CardNumber.Length == 0)
            {
                OK = false;
            }

            if (ExpireDate.Length == 0)
            {
                OK = false;
            }

            if (CVC.Length == 0)
            {
                OK = false;
            }
            return OK;
        }
    }
}
