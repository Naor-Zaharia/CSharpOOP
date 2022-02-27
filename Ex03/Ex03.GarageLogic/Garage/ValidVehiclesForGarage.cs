namespace Ex03.GarageLogic
{
    public class ValidVehiclesForGarage
    {
        private readonly int r_AmountOfWheels;
        private readonly float r_MaximalAirPressure;
        private readonly float r_MaximalAmountOfEnergy;
        private readonly LogicEnums.eFuelType? r_FuelType;
        private readonly LogicEnums.eVehicleType? r_VehicleType;

        public ValidVehiclesForGarage(LogicEnums.eVehicleType? i_VehicleType, int i_AmountOfWheels, float i_MaximalAirPressure, float i_MaximalAmountOfEnergy, LogicEnums.eFuelType? i_FuelType)
        {
            this.r_VehicleType = i_VehicleType;
            this.r_AmountOfWheels = i_AmountOfWheels;
            this.r_MaximalAirPressure = i_MaximalAirPressure;
            this.r_MaximalAmountOfEnergy = i_MaximalAmountOfEnergy;
            this.r_FuelType = i_FuelType;
        }

        public int AmountOfWheels
        {
            get
            {
                return r_AmountOfWheels;
            }
        }

        public float MaximalAirPressure
        {
            get
            {
                return r_MaximalAirPressure;
            }
        }

        public float MaximalAmountOfEnergy
        {
            get
            {
                return r_MaximalAmountOfEnergy;
            }
        }

        public LogicEnums.eFuelType? FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public LogicEnums.eVehicleType? VehicleType
        {
            get
            {
                return r_VehicleType;
            }
        }

        public override string ToString()
        {
            return string.Format(
@" Vehicle type: {0}, Amount of wheels: {1}, Wheel maximal air pressure: {2}, Maximal amount of energy: {3}, Type of energy: {4}
",
                VehicleType,
                AmountOfWheels,
                MaximalAirPressure,
                MaximalAmountOfEnergy,
                FuelType);
        }
    }
}
