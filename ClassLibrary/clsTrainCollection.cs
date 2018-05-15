using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class clsTrainCollection
    {
        public clsTrainCollection()
        {
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure 
            DB.Execute("sproc_tblTrain_SelectAll");
            PopulateArray(DB);
        }
    
        //private data members for the allTrains lists
        private List<clsTrain> mTrainList = new List<clsTrain>();
        //private data member for thisTrain
        clsTrain mThisTrain = new clsTrain();

        //public property for allTrains
        public List<clsTrain> TrainList
        {
            get
            {
                //return the private data member
                return mTrainList;
            }
            set
            {
                //assign the incoming value to the private data member
                mTrainList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                return mTrainList.Count;
            }
            set
            {

            }
        }

        public clsTrain ThisTrain
        {
            get
            {
                return mThisTrain;
            }
            set
            {
                mThisTrain = value;
            }
        }

        //public constructor for the class
        void PopulateArray(clsDataConnection DB)
        {
            //could change to from int32 to var
            Int32 Index = 0;
            Int32 RecordCount = 0;
            //get the count of records
            RecordCount = DB.Count;
            //list all records
            mTrainList = new List<clsTrain>();
            //while there are records to procress
            while (Index < RecordCount)
            {
                //create a new instance of Train clas
                clsTrain ATrain = new clsTrain();
                ATrain.TrainID = Convert.ToInt32(DB.DataTable.Rows[Index]["TrainID"]);
                ATrain.Train = Convert.ToString(DB.DataTable.Rows[Index]["Train"]);
                ATrain.Capacity = Convert.ToString(DB.DataTable.Rows[Index]["Capacity"]);
                ATrain.Active = Convert.ToString(DB.DataTable.Rows[Index]["Active"]);
                //add the Train to the private data member
                mTrainList.Add(ATrain);
                Index++;
            }
        }

        public void FilterByTrain(string Train)
        {
            //create an instance
            clsDataConnection DB = new clsDataConnection();
            //parameter firstname to be filtered
            DB.AddParameter("@Train", Train);
            //execute the filter stored procedure
            DB.Execute("sproc_tblTrain_FilterByTrain");
            //call the populateArray function
            PopulateArray(DB);
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored proc
            DB.AddParameter("Train", mThisTrain.Train);
            DB.AddParameter("Capacity", mThisTrain.Capacity);
            DB.AddParameter("Active", mThisTrain.Active);
            //execute the query
            return DB.Execute("sproc_tblTrain_Insert"); //tblCustomer
        }

        public void Update()
        {
            //update an existing record based on the values of thisTrain
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("TrainID", mThisTrain.TrainID);
            DB.AddParameter("Train", mThisTrain.Train);
            DB.AddParameter("Capacity", mThisTrain.Capacity);
            DB.AddParameter("Active", mThisTrain.Active);
            //execute the stored procedure
            DB.Execute("sproc_tblTrain_Update");
        }

        public void Delete()
        {
            //delete the record pointed to by thisTrain
            //connect to the DB
            clsDataConnection DB = new clsDataConnection();
            //set the params for the stored proc
            DB.AddParameter("@TrainID", mThisTrain.TrainID);
            //execute the stored proc
            DB.Execute("sproc_tblTrain_Delete");
        }
    }
}