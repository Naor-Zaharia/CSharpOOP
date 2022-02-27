using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ManageValidVehicles
    {
        private readonly List<ValidVehiclesForGarage> r_ValidVehiclesList;

        public ManageValidVehicles()
        {
            r_ValidVehiclesList = new List<ValidVehiclesForGarage>();
            createValidVehiclesList();
        }

        // The method create the valid vehicles list
        // Parameters: None
        // Return: None
        private void createValidVehiclesList()
        {
            r_ValidVehiclesList.Add(new ValidVehiclesForGarage(LogicEnums.eVehicleType.Motorcycle, 2, 30, 7, LogicEnums.eFuelType.Octan95));
            r_ValidVehiclesList.Add(new ValidVehiclesForGarage(LogicEnums.eVehicleType.Motorcycle, 2, 30, 1.2f, LogicEnums.eFuelType.Electric));
            r_ValidVehiclesList.Add(new ValidVehiclesForGarage(LogicEnums.eVehicleType.Car, 4, 32, 60, LogicEnums.eFuelType.Octan96));
            r_ValidVehiclesList.Add(new ValidVehiclesForGarage(LogicEnums.eVehicleType.Car, 4, 32, 2.1f, LogicEnums.eFuelType.Electric));
            r_ValidVehiclesList.Add(new ValidVehiclesForGarage(LogicEnums.eVehicleType.Truck, 16, 28, 120, LogicEnums.eFuelType.Soler));
        }

        public List<ValidVehiclesForGarage> ValidVehiclesList
        {
            get
            {
                return r_ValidVehiclesList;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilderValidVehiclesForGarage = new StringBuilder();
            stringBuilderValidVehiclesForGarage.AppendFormat("{0} The vehicles that our garage support them have to be with one of the following parameters{1}", Environment.NewLine, Environment.NewLine);

            foreach (ValidVehiclesForGarage currentVehicle in this.r_ValidVehiclesList)
            {
                stringBuilderValidVehiclesForGarage.Append(currentVehicle.ToString());
            }

            return stringBuilderValidVehiclesForGarage.ToString();
        }

        // The method check vehicle input is valid for garage
        // Parameters: ValidVehiclesForGarage - the vehicle for valid check 
        // Return: bool - return true if vehicle is valid for garage
        public bool IsVehicleValidForGarage(ValidVehiclesForGarage i_Vehicle)
        {
            bool isValidVehicle = false;

            foreach (ValidVehiclesForGarage currentVehicle in this.r_ValidVehiclesList)
            {
                if (currentVehicle.VehicleType == i_Vehicle.VehicleType && currentVehicle.AmountOfWheels == i_Vehicle.AmountOfWheels && currentVehicle.MaximalAirPressure == i_Vehicle.MaximalAirPressure &&
                   currentVehicle.MaximalAmountOfEnergy >= i_Vehicle.MaximalAmountOfEnergy && currentVehicle.FuelType == i_Vehicle.FuelType)
                {
                    isValidVehicle = true;
                }
            }

            return isValidVehicle;
        }
    }
}
