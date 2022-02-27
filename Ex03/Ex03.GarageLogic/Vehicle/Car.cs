namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly LogicEnums.eVehicleColor? r_VehicleColor;
        private readonly LogicEnums.eVehicleNumberOfDoors? r_AmountOfDoors;

        public Car(
            LogicEnums.eVehicleColor? i_VehicleColor,
            LogicEnums.eVehicleNumberOfDoors? i_AmountOfDoors,
            string i_ModelName,
            string i_PlateNumber,
            Wheel i_Wheel,
            byte i_NumberOfWheels,
            Engine i_VehicleEngine)
            : base(i_ModelName, i_PlateNumber, i_Wheel, i_NumberOfWheels, i_VehicleEngine)
        {
            this.r_AmountOfDoors = i_AmountOfDoors;
            this.r_VehicleColor = i_VehicleColor;
        }

        public LogicEnums.eVehicleColor? VehicleColor
        {
            get
            {
                return r_VehicleColor;
            }
        }

        public LogicEnums.eVehicleNumberOfDoors? AmountOfDoors
        {
            get
            {
                return r_AmountOfDoors;
            }
        }

        public override string ToString()
        {
            return string.Format(
@" Car color is: {0}
 Amount of doors is: {1}",
this.VehicleColor,
this.AmountOfDoors);
        }
    }
}
