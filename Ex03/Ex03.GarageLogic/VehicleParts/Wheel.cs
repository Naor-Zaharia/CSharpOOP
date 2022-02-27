namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_ManufacturerName = i_ManufacturerName;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel ShallowCloneWheel()
        {
            return this.MemberwiseClone() as Wheel;
        }

        public void FillUpWheelToMax()
        {
            this.m_CurrentAirPressure = this.MaxAirPressure;
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }
    }
}