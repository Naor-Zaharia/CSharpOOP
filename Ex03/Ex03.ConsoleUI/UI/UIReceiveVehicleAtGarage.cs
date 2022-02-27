using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UIReceiveVehicleAtGarage
    {
        // The method start the insertion vehicle process
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        public static void InsertVehicleInToGarage(Garage i_Garage)
        {
            Console.WriteLine(UIStringMessages.k_GeneralFunctionalityEnterVehiclePlateNumber);
            string plateNumber = ValidInput.GetValidInputPlateNumber();
            if (i_Garage.IsVehicleExistInGarage(plateNumber))
            {
                i_Garage.UpdateVehicleStatus(plateNumber, LogicEnums.eVehicleStatus.Processed);
                Console.WriteLine(UIStringMessages.k_UpdateVehicleStatusException);
            }
            else
            {
                VehicleAtGarage currentVehicleAtGarage = startProcessOfVehicleAtGarageInsertion(
                    ref i_Garage,
                    out LogicEnums.eVehicleType vehicleType,
                    plateNumber);
                i_Garage.InsertVehicleInToGarage(currentVehicleAtGarage, vehicleType);
            }
        }

        // The method get vehicle input for insertion and create VehicleAtGarage
        // Parameters: Garage - the garage that we make operation on
        //             VehicleType - the vehicle type for insertion
        //             PlateNumber - the vehicle plate number for insertion
        // Return: VehicleAtGarage - return the VehicleAtGarage for insertion to garage
        private static VehicleAtGarage startProcessOfVehicleAtGarageInsertion(ref Garage io_Garage, out LogicEnums.eVehicleType o_VehicleType, string i_PlateNumber)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterOwnerName);
            string ownerName = ValidInput.GetValidString();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterOwnerPhoneNumber);
            string ownerPhoneNumber = ValidInput.GetValidInputPhoneNumber();
            VehicleAtGarage currentInsertionVehicleAtGarage = new VehicleAtGarage(null, ownerName, ownerPhoneNumber);
            insertVehicleToGarage(ref currentInsertionVehicleAtGarage, out o_VehicleType, i_PlateNumber);
            return currentInsertionVehicleAtGarage;
        }

        // The method create the engine for vehicle
        // Parameters: VehicleAtGarage - the VehicleAtGarage that we make operation on
        // Return: Engine - return the Engine for vehicle
        private static Engine createEngineForVehicleInsertion(ref VehicleAtGarage io_VehicleAtGarage)
        {
            LogicEnums.eVehicleEnergySource? currentVehicleEnergySource = null;
            LogicEnums.eFuelType? fuelType = null;
            float vehicleCurrentAmountOfEnergy = 0;
            float vehicleMaxEnergy = 0;
            Engine vehicleEngine;

            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleEnergyType);
            Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleEnergySource)));
            currentVehicleEnergySource = ValidInput.GetValidInputVehicleEnergySource();
            if (currentVehicleEnergySource == LogicEnums.eVehicleEnergySource.Fuel)
            {
                Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleFuelType);
                Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eFuelType)));
                fuelType = ValidInput.GetValidInputVehicleFuelType();
                getInputOfFuelVehicle(out vehicleCurrentAmountOfEnergy, out vehicleMaxEnergy);
                FuelEngine fuelEngineForVehicleInsertion = new FuelEngine(vehicleCurrentAmountOfEnergy, vehicleMaxEnergy, fuelType);
                vehicleEngine = fuelEngineForVehicleInsertion;
            }
            else
            {
                fuelType = LogicEnums.eFuelType.Electric;
                getInputOfElectricityVehicle(out vehicleCurrentAmountOfEnergy, out vehicleMaxEnergy);
                ElectricEngine electricEngineForVehicleInsertion = new ElectricEngine(vehicleCurrentAmountOfEnergy, vehicleMaxEnergy, fuelType);
                vehicleEngine = electricEngineForVehicleInsertion;
            }

            return vehicleEngine;
        }

        // The method create vehicle and set it on VehicleAtGarage
        // Parameters: VehicleAtGarage - the VehicleAtGarage that we make operation on
        //             VehicleType - the vehicle type for insertion
        //             PlateNumber - the vehicle plate number for insertion
        // Return: void
        private static void insertVehicleToGarage(ref VehicleAtGarage io_VehicleAtGarage, out LogicEnums.eVehicleType o_VehicleType, string i_PlateNumber)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleType);
            Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleType)));
            o_VehicleType = ValidInput.GetValidInputVehicleType();
            Vehicle vehicle = createVehicleForInsertion(ref io_VehicleAtGarage, o_VehicleType, i_PlateNumber);
            io_VehicleAtGarage.Vehicle = vehicle;
        }

        // The method create specific vehicle
        // Parameters: VehicleAtGarage - the VehicleAtGarage that we make operation on
        //             VehicleType - the vehicle type for insertion
        //             PlateNumber - the vehicle plate number for insertion
        // Return: Vehicle - the specific vehicle for insertion
        private static Vehicle createVehicleForInsertion(ref VehicleAtGarage io_VehicleAtGarage, LogicEnums.eVehicleType? i_VehicleType, string i_PlateNumber)
        {
            Vehicle vehicleForInsertion = null;
            LogicEnums.eVehicleColor? carColor = null;
            LogicEnums.eVehicleNumberOfDoors? carNumberOfDoors = null;
            LogicEnums.eLicenseType? licenseType = null;
            int engineVolumeMotorcycle;
            float truckAmountOfCargo;
            byte amountOfWheels;
            bool isTruckHazardMaterials = false;

            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleModel);
            string vehicleModelName = ValidInput.GetValidString();
            Engine vehicleEngine = createEngineForVehicleInsertion(ref io_VehicleAtGarage);
            Wheel vehicleWheel = createWheelForVehicleInsertion();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsAmount);
            amountOfWheels = ValidInput.GetValidByte();

            switch (i_VehicleType)
            {
                case LogicEnums.eVehicleType.Car:
                    getInputForCar(out carColor, out carNumberOfDoors);
                    Car vehicleCar = new Car(carColor, carNumberOfDoors, vehicleModelName, i_PlateNumber, vehicleWheel, amountOfWheels, vehicleEngine);
                    vehicleForInsertion = vehicleCar;
                    break;
                case LogicEnums.eVehicleType.Motorcycle:
                    getInputForMotorcycle(out licenseType, out engineVolumeMotorcycle);
                    Motorcycle vehicleMotorcycle = new Motorcycle(licenseType, engineVolumeMotorcycle, vehicleModelName, i_PlateNumber, vehicleWheel, amountOfWheels, vehicleEngine);
                    vehicleForInsertion = vehicleMotorcycle;
                    break;
                case LogicEnums.eVehicleType.Truck:
                    getInputForTruck(out isTruckHazardMaterials, out truckAmountOfCargo);
                    Truck vehicleTruck = new Truck(isTruckHazardMaterials, truckAmountOfCargo, vehicleModelName, i_PlateNumber, vehicleWheel, amountOfWheels, vehicleEngine);
                    vehicleForInsertion = vehicleTruck;
                    break;
            }

            return vehicleForInsertion;
        }

        // The method create vehicle wheel
        // Parameters: None
        // Return: Wheel - the vehicle wheel for insertion
        private static Wheel createWheelForVehicleInsertion()
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsManufacturer);
            string wheelsManufacturerName = ValidInput.GetValidString();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsMaxAirPressure);
            float wheelMaximalAirPressure = ValidInput.GetValidFloat();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsCurrentAirPressure);
            float wheelCurrentAirPressure = ValidInput.GetValidFloat();
            Wheel currentWheel = new Wheel(wheelsManufacturerName, wheelCurrentAirPressure, wheelMaximalAirPressure);
            return currentWheel;
        }

        // The method get car specific input 
        // Parameters: CarColor - the vehicle color
        //             CarNumberOfDoors - the amount of door on car
        // Return: void
        private static void getInputForCar(out LogicEnums.eVehicleColor? o_CarColor, out LogicEnums.eVehicleNumberOfDoors? o_CarNumberOfDoors)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityColor);
            Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleColor)));
            o_CarColor = ValidInput.GetValidInputVehicleColor();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityDoor);
            Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleNumberOfDoors)));
            o_CarNumberOfDoors = ValidInput.GetValidInputVehicleNumberOfDoors();
        }

        // The method get motorcycle specific input 
        // Parameters: LicenseType - the license type
        //             EngineVolume - the engine volume
        // Return: void
        private static void getInputForMotorcycle(out LogicEnums.eLicenseType? o_LicenseTypeMotorcycle, out int o_EngineVolumeMotorcycle)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityLicenseType);
            Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eLicenseType)));
            o_LicenseTypeMotorcycle = ValidInput.GetValidInputLicenseType();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEngineVolume);
            o_EngineVolumeMotorcycle = ValidInput.GetValidInt();
        }

        // The method get truck specific input 
        // Parameters: IsTruckHazardMaterials - is the truck deliver hazard materials
        //             TruckAmountOfCargo - the maximal cargo capacity
        // Return: void
        private static void getInputForTruck(out bool o_IsTruckHazardMaterials, out float o_TruckAmountOfCargo)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityHazard);
            o_IsTruckHazardMaterials = ValidInput.GetValidYesOrNoBoolean();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityCargo);
            o_TruckAmountOfCargo = ValidInput.GetValidFloat();
        }

        // The method get electricity vehicle specific input 
        // Parameters: VehicleRemainingBatteryTime - the remaining battery time capacity
        //             VehicleMaxBatteryTime - the maximal battery time capacity
        // Return: void
        private static void getInputOfElectricityVehicle(out float o_VehicleRemainingBatteryTime, out float o_VehicleMaxBatteryTime)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleRemainingBatteryTime);
            o_VehicleRemainingBatteryTime = ValidInput.GetValidFloat();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleMaxBatteryTime);
            o_VehicleMaxBatteryTime = ValidInput.GetValidFloat();
            ValidInput.GetCurrentValueSmallerThanMax(ref o_VehicleRemainingBatteryTime, o_VehicleMaxBatteryTime);
        }

        // The method get fuel vehicle specific input 
        // Parameters: VehicleRemainingFuel - the remaining fuel capacity
        //             VehicleMaxFuel - the maximal fuel capacity
        // Return: void
        private static void getInputOfFuelVehicle(out float o_VehicleRemainingFuel, out float o_VehicleMaxFuel)
        {
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleMaxFuel);
            o_VehicleMaxFuel = ValidInput.GetValidFloat();
            Console.WriteLine(UIStringMessages.k_InsertVehicleToGarageFunctionalityEnterVehicleRemainingFuel);
            o_VehicleRemainingFuel = ValidInput.GetValidFloat();
            ValidInput.GetCurrentValueSmallerThanMax(ref o_VehicleRemainingFuel, o_VehicleMaxFuel);
        }
    }
}
