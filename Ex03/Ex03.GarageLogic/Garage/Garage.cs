using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly ManageValidVehicles r_ManageValidVehicles;
        private readonly Dictionary<string, VehicleAtGarage> r_VehiclesAtGarageDictionary;

        public Garage(List<ValidVehiclesForGarage> i_ValidVehiclesForGaragesList)
        {
            this.r_ManageValidVehicles = new ManageValidVehicles();
            this.r_VehiclesAtGarageDictionary = new Dictionary<string, VehicleAtGarage>();
        }

        // The method check if vehicle is electric vehicle
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        // Return: bool - return true if electric vehicle
        private bool isElectricVehicle(string i_PlateNumber)
        {
            bool isElectricVehicle = false;

            if (IsVehicleExistInGarage(i_PlateNumber))
            {
                this.r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicleAtGarage);
                if (currentVehicleAtGarage.Vehicle.VehicleEngine.GetFuelType() == LogicEnums.eFuelType.Electric)
                {
                    isElectricVehicle = true;
                }
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageException);
            }

            return isElectricVehicle;
        }

        // The method check if vehicle exist in garage
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        // Return: bool - return true if vehicle exist
        public bool IsVehicleExistInGarage(string i_PlateNumber)
        {
            return this.r_VehiclesAtGarageDictionary.ContainsKey(i_PlateNumber);
        }

        // The method get vehicle status
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        // Return: eVehicleStatus - return vehicle status
        public LogicEnums.eVehicleStatus? GetStatusOfVehicle(string i_PlateNumber)
        {
            LogicEnums.eVehicleStatus? currentVehicleStatus = null;
            if (this.IsVehicleExistInGarage(i_PlateNumber))
            {
                this.r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicle);
                currentVehicleStatus = currentVehicle.VehicleStatus;
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageException);
            }

            return currentVehicleStatus;
        }

        // The method set vehicle status
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        //             VehicleStatus - the new status for update
        // Return: void
        public void UpdateVehicleStatus(string i_PlateNumber, LogicEnums.eVehicleStatus i_VehicleStatus)
        {
            if (IsVehicleExistInGarage(i_PlateNumber))
            {
                r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicleAtGarage);
                currentVehicleAtGarage.VehicleStatus = i_VehicleStatus;
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageException);
            }
        }

        // The method inflate vehicle wheels
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        // Return: void
        public void InflateWheelsToMaximalAirPressure(string i_PlateNumber)
        {
            if (IsVehicleExistInGarage(i_PlateNumber))
            {
                r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicleAtGarage);

                foreach (Wheel currentWheel in currentVehicleAtGarage.Vehicle.VehicleWheelList)
                {
                    currentWheel.FillUpWheelToMax();
                }
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageException);
            }
        }

        // The method fill up fuel in to vehicle
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        //             FuelType - the fuel type to fill
        //             AmountOfFuelToFill - the amount of fuel to fill
        // Return: void
        public void FillUpFuelInToVehicle(string i_PlateNumber, LogicEnums.eFuelType i_FuelType, float i_AmountOfFuelToFill)
        {
            if (IsVehicleExistInGarage(i_PlateNumber)
                && !isElectricVehicle(i_PlateNumber))
            {
                r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicleAtGarage);
                currentVehicleAtGarage.Vehicle.VehicleEngine.FillUpEnergy(i_AmountOfFuelToFill, i_FuelType);
                currentVehicleAtGarage.Vehicle.UpdateRemainingEnergyPercentage();
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_VehicleOperationException);
            }
        }

        // The method fill up electricity in to vehicle battery
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        //             AmountOfElectricityToFill - the amount of electricity to fill on hours
        // Return: void
        public void FillUpElectricityInToBattery(string i_PlateNumber, float i_AmountOfElectricityToFill)
        {
            if (IsVehicleExistInGarage(i_PlateNumber)
                && isElectricVehicle(i_PlateNumber))
            {
                r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage currentVehicleAtGarage);
                currentVehicleAtGarage.Vehicle.VehicleEngine.FillUpEnergy(i_AmountOfElectricityToFill, LogicEnums.eFuelType.Electric);
                currentVehicleAtGarage.Vehicle.UpdateRemainingEnergyPercentage();
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_VehicleOperationException);
            }
        }

        // The method insert vehicle in to garage
        // Parameters: VehicleAtGarage - the vehicle for insertion
        //             VehicleType - vehicle type
        // Return: void
        public void InsertVehicleInToGarage(VehicleAtGarage i_VehicleAtGarage, LogicEnums.eVehicleType i_VehicleType)
        {
            ValidVehiclesForGarage currentValidParamsOfVehiclesForGarage = new ValidVehiclesForGarage(
                i_VehicleType,
                i_VehicleAtGarage.Vehicle.NumberOfWheels,
                i_VehicleAtGarage.Vehicle.VehicleWheelList[0].MaxAirPressure,
                i_VehicleAtGarage.Vehicle.VehicleEngine.MaxSourceQuantity,
                i_VehicleAtGarage.Vehicle.VehicleEngine.GetFuelType());
            ManageValidVehicles allCurrentValidVehicles = new ManageValidVehicles();

            if (!r_ManageValidVehicles.IsVehicleValidForGarage(currentValidParamsOfVehiclesForGarage))
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageUnsupportedException);
            }

            r_VehiclesAtGarageDictionary.Add(i_VehicleAtGarage.Vehicle.PlateNumber, i_VehicleAtGarage);
        }

        // The method return string of all plate numbers of vehicle with status
        // Parameters: VehicleStatus - the vehicle status
        // Return: string - the string of all plate numbers
        public string PrintVehiclesPlateNumberByStatus(LogicEnums.eVehicleStatus i_VehicleStatus)
        {
            StringBuilder stringBuilderOfPlateNumbersByStatus = new StringBuilder();

            foreach (KeyValuePair<string, VehicleAtGarage> currentVehicle in r_VehiclesAtGarageDictionary)
            {
                if (GetStatusOfVehicle(currentVehicle.Key) == i_VehicleStatus)
                {
                    stringBuilderOfPlateNumbersByStatus.AppendFormat(
@"{0}
",
currentVehicle.Value.Vehicle.PlateNumber);
                }
            }

            return stringBuilderOfPlateNumbersByStatus.ToString();
        }

        // The method return string of all plate numbers of vehicle in garage
        // Parameters: None
        // Return: string - the string of all plate numbers
        public string PrintPlateNumberOfAllVehicles()
        {
            StringBuilder stringBuilderOfAllPlateNumbers = new StringBuilder();
            foreach (KeyValuePair<string, VehicleAtGarage> currentVehicle in r_VehiclesAtGarageDictionary)
            {
                stringBuilderOfAllPlateNumbers.AppendFormat(
@"{0}
",
currentVehicle.Value.Vehicle.PlateNumber);
            }

            return stringBuilderOfAllPlateNumbers.ToString();
        }

        // The method return the vehicle string details
        // Parameters: PlateNumber - the vehicle plate number for make operation on
        // Return: string - the string that represent the vehicle
        public string GetFullDetailsOfVehicle(string i_PlateNumber)
        {
            if (IsVehicleExistInGarage(i_PlateNumber))
            {
                r_VehiclesAtGarageDictionary.TryGetValue(i_PlateNumber, out VehicleAtGarage vehicleAtGarage);
                return vehicleAtGarage.ToString();
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_InsertVehicleToGarageException);
            }
        }

        // The method return the vehicle string details, of all valid vehicle
        // Parameters: None
        // Return: string - the string that represent all of the valid vehicles for the garage
        public string GetValidVehiclesString()
        {
            return r_ManageValidVehicles.ToString();
        }
    }
}
