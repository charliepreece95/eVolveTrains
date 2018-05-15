using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class clsCalculator
    {

        private decimal mWeight;
        private Int32 mGoal;
        private Int32 mLevel;

        public clsCalculator(decimal Weight,Int32 Goal, Int32 Level)
        {
            mWeight = Weight;
            mGoal = Goal;
            mLevel = Level;
        }

        public Int32 Cal
        {
            get
            {
                decimal mCal;
                mCal = mWeight * mGoal + mLevel;
                return Convert.ToInt32(mCal);
            }
        }

        public bool Valid(decimal weight, int goal, int level)
        {
            Boolean OK = true;
            //if the weight is null
            if (weight == 0)
            {
                OK = false;
            }
            //if the weight is less than 20 (unrealistic weight)
            if (weight < 20)
            {
                OK = false;
            }
            //if weight is greater than 1000
            if (weight > 999)
            {
                OK = false;
            }

            return OK;
        }
    }
}
