using System;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class UIStringMessages
    {
        // Main Menu Msg
        public const string k_MainMenuFunctionalityFirstPart = "Welcome to Zahari's & Zaharia's Autoshop ";
        public const string k_MainMenuFunctionalitySecondPart = "Please enter the relvent service by number:";
        public const string k_MainMenuFunctionalityInsertVehicleToGarage = "1. Insert new vehicle to the garage";
        public const string k_MainMenuFunctionalityPrintVehiclesPlateNumbersByStatus = "2. Print vehiceles plate numbers by status ";
        public const string k_MainMenuFunctionalityUpdateVehicleStatus = "3. Update vehicle status";
        public const string k_MainMenuFunctionalityInflateWheelsToMaximalAirPressure = "4. Inflate wheels to maximum air pressure";
        public const string k_MainMenuFunctionalityFillUpFuelInVehicle = "5. Fill up vehicle's fuel tank";
        public const string k_MainMenuFunctionalityFillUpElectricityInBattery = "6. Charge vehicle battery";
        public const string k_MainMenuFunctionalityPrintFullDetailsOfVehicle = "7. Print all of the vehicle detailes";
        public const string k_MainMenuFunctionalityExit = "8. Exit";

        // Main Menu Exit Msg
        public const string k_Return = "Enter any key to return to the main menu";
        public const string k_ExitValidation = "Are you sure you want exit ? enter Y/N";

        // General Msg
        public const string k_GeneralFunctionalityEnterVehiclePlateNumber = "Please enter the vehicele's license plate number";
        public const string k_GeneralFunctionalityAskFuelType = "Please enter the car's fuel type by number:";
        public const string k_GeneralFunctionalityAskStatus = "Please enter the desierd status by number:";

        // Operations On Vehicles
        public const string k_AskForAmountOfFuelToFill = "Please enter the amount of fuel liters you want to fill";
        public const string k_AskForAmountOfElectricityToFill = "Please enter the amount of electricty you would like to charge in to the engine on hours";

        // Insert Vehicle Msg
        public const string k_InsertVehicleToGarageFunctionalityEnterOwnerName = "Please enter the customer name";
        public const string k_InsertVehicleToGarageFunctionalityEnterOwnerPhoneNumber = "Please enter the customer phone number";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleType = "Please enter the vehicle type by number:";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleEnergyType = "Please enter the vehicle energy type by number:";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleFuelType = "Please enter the vehicle Fuel type by number:";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsAmount = "Please enter the vehicele's wheels amount";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsManufacturer = "Please enter the wheels manufacturer";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsMaxAirPressure = "Please enter the wheels max pressure";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleWheelsCurrentAirPressure = "Please enter the wheels current pressure";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleModel = "Please enter the vehicele's Model";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleRemainingBatteryTime = "Please enter the vehicele's remaining battery time";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleRemainingFuel = "Please enter the vehicele's remaining amount of fuel";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleMaxBatteryTime = "Please enter the vehicele's max battery time";
        public const string k_InsertVehicleToGarageFunctionalityEnterVehicleMaxFuel = "Please enter the vehicele's max amount of fuel";

        // Insert Vehicle Msg - Bike
        public const string k_InsertVehicleToGarageFunctionalityLicenseType = "Please enter the license type by number:";
        public const string k_InsertVehicleToGarageFunctionalityEngineVolume = "Please enter the engine volume in cubic centimeter's";

        // Insert Vehicle Msg - Car
        public const string k_InsertVehicleToGarageFunctionalityColor = "Please enter the car color by number:";
        public const string k_InsertVehicleToGarageFunctionalityDoor = "Please enter the number of doors on the car:";

        // Insert Vehicle Msg - Truck
        public const string k_InsertVehicleToGarageFunctionalityHazard = "Does the truck have hazardous materials Y/N";
        public const string k_InsertVehicleToGarageFunctionalityCargo = "Please enter the volume of the trucks cargo";

        // Print Vehicle (OutputGarageData)
        public const string k_PrintVehiclesPlateNumbersFunctionalityAskByStatus = "Would you like to print the list of cars by status? enter Y/N";
        public const string k_PrintVehiclesPlateNumbersFunctionalityChoseStatus = "Please enter the relvent status by number:";

        // Exceptions Msg
        public const string k_InvalidInputException = "Invalid input, please try again";
        public const string k_FillUpMaxAmountException = "Invalid input current amount of energy cant be bigger than the maximal amount";
        public const string k_InvalidLicensePlateFormatException = "License plate can only be 5-8 characters";
        public const string k_InvalidInputNumber = "Invalid input, please enter a number";
        public const string k_InvalidNoOrYesMsg = "Invalid please enter Y/N";
        public const string k_InvalidEmptyInput = "Invalid input, the string is empty";
        public const string k_UpdateVehicleStatusException = "This vehicle already exist in the system, changed vehicle status to processed";
        
        // Create dynamic enum option strings
        public static StringBuilder BuildDynamicEnumStringBuilder(Type i_EnumType)
        {
            int currentOptionIndex = 1;
            StringBuilder currentResultStringBuilder = new StringBuilder();
            string[] currentEnumString = Enum.GetNames(i_EnumType);
            foreach (string currentString in currentEnumString)
            {
                currentResultStringBuilder.AppendFormat("{0}. {1}   ", currentOptionIndex, currentString);
                currentOptionIndex++;
            }

            return currentResultStringBuilder;
        }
    }
}
