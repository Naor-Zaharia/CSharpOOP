using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string k_ValueOutOfRangeException =
            "Got ValueOutOfRangeException - the minimal value the possible is: {0}  and the maximal is: {1}";

        private readonly float r_MinimalValueOfRange;
        private readonly float r_MaximalValueOfRange;

        public ValueOutOfRangeException(float i_MinimalValueOfRange, float i_MaximalValueOfRange)
            : base(string.Format(k_ValueOutOfRangeException, i_MinimalValueOfRange, i_MaximalValueOfRange))
        {
            this.r_MinimalValueOfRange = i_MinimalValueOfRange;
            this.r_MaximalValueOfRange = i_MaximalValueOfRange;
        }

        public float MinimalValueOfRange
        {
            get
            {
                return r_MinimalValueOfRange;
            }
        }

        public float MaximalValueOfRange
        {
            get
            {
                return r_MaximalValueOfRange;
            }
        }
    }
}
