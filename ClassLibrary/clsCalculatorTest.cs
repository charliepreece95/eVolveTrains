using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCalculatorTest
    {
        //private data members
        private Int32 mCalcID;
        private string mWeight;
        private string mExLvl;
        private string mGoalType;


        public Int32 CalcID
        {
            get
            {
                return mCalcID;
            }
            set
            {
                mCalcID = value;
            }
        }

        public string Weight
        {
            get
            {
                return mWeight;
            }
            set
            {
                mWeight = value;
            }
        }

        public string ExLvl
        {
            get
            {
                return mExLvl;
            }
            set
            {
                mExLvl = value;
            }
        }

        public string GoalType
        {
            get
            {
                return mGoalType;
            }
            set
            {
                mGoalType = value;
            }
        }

        public bool Find(Int32 CalcID)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@CalcID", CalcID);
            DB.Execute("sproc_tblCalorieCalc_FilterByCalcID");
            if (DB.Count == 1)
            {
                //copy the data from the db to the private data members
                mCalcID = Convert.ToInt32(DB.DataTable.Rows[0]["CalcID"]);
                mWeight = Convert.ToString(DB.DataTable.Rows[0]["Weight"]);
                mExLvl = Convert.ToString(DB.DataTable.Rows[0]["ExLvl"]);
                mGoalType = Convert.ToString(DB.DataTable.Rows[0]["GoalType"]);

                return true;
            }
            //if no record was found
            else
            {
                //indicate a problem by returning false
                return false;
            }
        }

        /*public bool CalculateCal()
        {
            //method for the calorie calculation
        }*/
    }
}
