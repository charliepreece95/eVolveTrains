using System;

namespace ClassLibrary
{
    public class clsTrain
    {
        //private data members
        private Int32 mTrainID;
        private string mTrain;
        private string mCapacity;
        private string mActive;
       
        public Int32 TrainID
        {
            get
            {
                return mTrainID;
            }
            set
            {
                mTrainID = value;
            }
        }

        public string Train
        {
            get
            {
                return mTrain;
            }
            set
            {
                mTrain = value;
            }
        }

        public string Capacity
        {
            get
            {
                return mCapacity;
            }
            set
            {
                mCapacity = value;
            }
        }

        public string Active
        {
            get
            {
                return mActive;
            }
            set
            {
                mActive = value;
            }
        }

        public bool Find(Int32 TrainID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@TrainID", TrainID);
            DB.Execute("sproc_tblTrain_FilterByTrainID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mTrainID = Convert.ToInt32(DB.DataTable.Rows[0]["TrainID"]);
                mTrain = Convert.ToString(DB.DataTable.Rows[0]["Train"]);
                mCapacity = Convert.ToString(DB.DataTable.Rows[0]["Capacity"]);
                mActive = Convert.ToString(DB.DataTable.Rows[0]["Active"]);
                return true;
            }
            //if no record found?
            else
            {
                return false;
            }
        }

        public bool Valid(string Train, string Capacity, string Active)
        {
            Boolean OK = true;

            //if train is null
            if (Train.Length < 1)
            {
                OK = false;
            }
            if (Train.Length > 50)
            {
                OK = false;
            }
            if (Capacity.Length < 1)
            {
                OK = false;
            }
            if (Capacity.Length > 3)
            {
                OK = false;
            }
            if (Active.Length < 1)
            {
                OK = false;
            }
            if (Active.Length > 3)
            {
                OK = false;
            }
            return OK;
        }
    }
}