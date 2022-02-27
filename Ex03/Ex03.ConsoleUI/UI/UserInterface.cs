using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        // The method create new garage and run his functionality
        // Parameters: None
        // Return: void
        public static void StartGarage()
        {
            ManageValidVehicles currentManageValidVehicles = new ManageValidVehicles();
            Garage currentGarage = new Garage(currentManageValidVehicles.ValidVehiclesList);
            startGarageMainMenuFunctionality(currentGarage);
        }

        // The method manage main menu functionality
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void startGarageMainMenuFunctionality(Garage i_Garage)
        {
            while (true)
            {
                Console.Clear();
                printGarageMainMenuFunctionality();
                UIEnums.eGarageServiceType serviceType = ValidInput.GetValidInputServiceType();
                switch (serviceType)
                {
                    case UIEnums.eGarageServiceType.InsertVehicleInToGarage:
                        insertVehicleInToGarage(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.PrintVehiclesPlateNumbersByStatus:
                        printVehiclesPlateNumberDetailsByStatusOrAll(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.UpdateVehicleStatus:
                        updateVehicleStatus(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.InflateWheelsToMaximalAirPressure:
                        inflateWheelsToMaximalAirPressure(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.FillUpFuelInToVehicle:
                        fillUpFuelInToVehicle(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.FillUpElectricityInToBattery:
                        fillUpElectricityInToBattery(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.PrintFullDetailsOfVehicle:
                        printFullDetailsOfVehicle(i_Garage);
                        break;
                    case UIEnums.eGarageServiceType.Exit:
                        exitFromGarage();
                        break;
                }
            }
        }

        // The method pause screen console before back to mean menu
        // Parameters: None
        // Return: void
        private static void backToMainMenu()
        {
            Console.WriteLine(UIStringMessages.k_Return);
            Console.ReadLine();
        }

        // The method pause screen console before 
        // Parameters: None
        // Return: void
        private static void exitFromGarage()
        {
            Console.WriteLine(UIStringMessages.k_ExitValidation);
            bool exitStatus = ValidInput.GetValidYesOrNoBoolean();
            if (exitStatus == true)
            {
                Environment.Exit(0);
            }
        }

        // The method start process of receiving vehicle to garage
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void insertVehicleInToGarage(Garage i_Garage)
        {
            Console.Clear();
            try
            {
                UIReceiveVehicleAtGarage.InsertVehicleInToGarage(i_Garage);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(i_Garage.GetValidVehiclesString());
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method start process of update vehicle status on garage
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void updateVehicleStatus(Garage i_Garage)
        {
            try
            {
                Console.Clear();
                string plateNumber = getInputPlateNumber();
                Console.WriteLine(UIStringMessages.k_GeneralFunctionalityAskStatus);
                Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleStatus)));
                LogicEnums.eVehicleStatus newVehicleStatus = ValidInput.GetValidInputVehicleStatus();
                i_Garage.UpdateVehicleStatus(plateNumber, newVehicleStatus);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method start process of inflate wheels to maximal air pressure
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void inflateWheelsToMaximalAirPressure(Garage i_Garage)
        {
            Console.Clear();
            string plateNumber = getInputPlateNumber();
            try
            {
                i_Garage.InflateWheelsToMaximalAirPressure(plateNumber);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method start process of fill fuel in to vehicle
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void fillUpFuelInToVehicle(Garage i_Garage)
        {
            try
            {
                Console.Clear();
                string plateNumber = getInputPlateNumber();
                Console.WriteLine(UIStringMessages.k_GeneralFunctionalityAskFuelType);
                Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eFuelType)));
                LogicEnums.eFuelType fuelType = ValidInput.GetValidInputVehicleFuelType();
                Console.WriteLine(UIStringMessages.k_AskForAmountOfFuelToFill);
                float amountOfFuelToFill = ValidInput.GetValidFloat();
                i_Garage.FillUpFuelInToVehicle(plateNumber, fuelType, amountOfFuelToFill);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method start process of fill electricity in to vehicle battery
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void fillUpElectricityInToBattery(Garage i_Garage)
        {
            try
            {
                Console.Clear();
                string plateNumber = getInputPlateNumber();
                Console.WriteLine(UIStringMessages.k_AskForAmountOfElectricityToFill);
                float amountOfElectricityToFill = ValidInput.GetValidFloat();
                i_Garage.FillUpElectricityInToBattery(plateNumber, amountOfElectricityToFill);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method start process of print vehicles plate number details by status or all vehicle on garage
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void printVehiclesPlateNumberDetailsByStatusOrAll(Garage i_Garage)
        {
            string stringVehiclesPlateNumberDetails;
            Console.Clear();
            Console.WriteLine(UIStringMessages.k_PrintVehiclesPlateNumbersFunctionalityAskByStatus);
            bool filterStatus = ValidInput.GetValidYesOrNoBoolean();
            Console.Clear();

            if (filterStatus)
            {
                Console.WriteLine(UIStringMessages.k_PrintVehiclesPlateNumbersFunctionalityChoseStatus);
                Console.WriteLine(UIStringMessages.BuildDynamicEnumStringBuilder(typeof(LogicEnums.eVehicleStatus)));
                LogicEnums.eVehicleStatus vehicleStatus = ValidInput.GetValidInputVehicleStatus();
                stringVehiclesPlateNumberDetails = i_Garage.PrintVehiclesPlateNumberByStatus(vehicleStatus);
            }
            else
            {
                stringVehiclesPlateNumberDetails = i_Garage.PrintPlateNumberOfAllVehicles();
            }

            Console.WriteLine(stringVehiclesPlateNumberDetails);
            backToMainMenu();
        }

        // The method start process of print full vehicle details
        // Parameters: Garage - the garage that we make operation on
        // Return: void
        private static void printFullDetailsOfVehicle(Garage i_Garage)
        {
            string plateNumber = getInputPlateNumber();
            Console.Clear();
            try
            {
                Console.WriteLine(i_Garage.GetFullDetailsOfVehicle(plateNumber));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            backToMainMenu();
        }

        // The method get valid plate number input
        // Parameters: None
        // Return: void
        private static string getInputPlateNumber()
        {
            Console.Clear();
            Console.WriteLine(UIStringMessages.k_GeneralFunctionalityEnterVehiclePlateNumber);
            return ValidInput.GetValidInputPlateNumber();
        }

        // The method print main menu functionality
        // Parameters: None
        // Return: void
        private static void printGarageMainMenuFunctionality()
        {
            string mainMenuFullString = string.Format(
@"{0}

{1}

{2}
{3}
{4}
{5}
{6}
{7}
{8}
{9}",
UIStringMessages.k_MainMenuFunctionalityFirstPart,
UIStringMessages.k_MainMenuFunctionalitySecondPart,
UIStringMessages.k_MainMenuFunctionalityInsertVehicleToGarage,
UIStringMessages.k_MainMenuFunctionalityPrintVehiclesPlateNumbersByStatus,
UIStringMessages.k_MainMenuFunctionalityUpdateVehicleStatus,
UIStringMessages.k_MainMenuFunctionalityInflateWheelsToMaximalAirPressure,
UIStringMessages.k_MainMenuFunctionalityFillUpFuelInVehicle,
UIStringMessages.k_MainMenuFunctionalityFillUpElectricityInBattery,
UIStringMessages.k_MainMenuFunctionalityPrintFullDetailsOfVehicle,
UIStringMessages.k_MainMenuFunctionalityExit);
            Console.WriteLine(mainMenuFullString);
        }
    }
}
