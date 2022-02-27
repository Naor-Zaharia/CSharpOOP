namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly LogicEnums.eLicenseType? r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(
            LogicEnums.eLicenseType? i_LicenseType,
            int i_EngineCapacity,
            string i_ModelName,
            string i_PlateNumber,
            Wheel i_Wheel,
            byte i_NumberOfWheels,
            Engine i_VehicleEngine)
            : base(i_ModelName, i_PlateNumber, i_Wheel, i_NumberOfWheels, i_VehicleEngine)
        {
            this.r_EngineCapacity = i_EngineCapacity;
            this.r_LicenseType = i_LicenseType;
        }

        public LogicEnums.eLicenseType? LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public override string ToString()
        {
            return string.Format(
 @" Motorcycle license type is: {0}
 Engine capacity is: {1}",
 this.LicenseType,
 this.r_EngineCapacity);
        }
    }
}
