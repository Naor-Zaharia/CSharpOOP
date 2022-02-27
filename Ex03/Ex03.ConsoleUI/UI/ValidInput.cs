using System;
using Ex03.ConsoleUI;

namespace Ex03.GarageLogic
{
    public class ValidInput
    {
        private const byte k_MinimalInstructionServiceType = 1;
        private const byte k_MaximalInstructionServiceType = 8;
        private const byte k_MinimalInstructionVehicleStatus = 1;
        private const byte k_MaximalInstructionVehicleStatus = 3;
        private const byte k_MinimalInstructionVehicleFuelType = 1;
        private const byte k_MaximalInstructionVehicleFuelType = 4;
        private const byte k_MinimalInstructionVehicleType = 1;
        private const byte k_MaximalInstructionVehicleType = 3;
        private const byte k_MinimalInstructionVehicleEnergySource = 1;
        private const byte k_MaximalInstructionVehicleEnergySource = 2;
        private const byte k_MinimalPlateNumberLength = 5;
        private const byte k_MaximalPlateNumberLength = 8;
        private const byte k_MinimalInstructionNumberOfDoors = 1;
        private const byte k_MaximalInstructionNumberOfDoors = 4;
        private const byte k_MinimalInstructionVehicleColor = 1;
        private const byte k_MaximalInstructionVehicleColor = 4;
        private const byte k_MinimalInstructionLicenseType = 1;
        private const byte k_MaximalInstructionLicenseType = 4;
        private const string k_YesAnswer = "Y";
        private const string k_NoAnswer = "N";

        // The method get valid instruction number 
        // Parameters: MinimalNumberInstruction - minimal instruction
        //             MaximalNumberInstruction - maximal instruction
        // Return: byte - return the instruction number
        public static byte GetValidInputInstructionNumber(byte i_MinimalNumberInstruction, byte i_MaximalNumberInstruction)
        {
            while (true)
            {
                string currentInput = Console.ReadLine();
                bool isValidInput = byte.TryParse(currentInput, out byte instructionCode);
                if (isValidInput && instructionCode >= i_MinimalNumberInstruction && instructionCode <= i_MaximalNumberInstruction)
                {
                    return instructionCode;
                }
                else
                {
                    Console.WriteLine(UIStringMessages.k_InvalidInputException);
                }
            }
        }

        internal static LogicEnums.eVehicleEnergySource GetValidInputVehicleEnergySource()
        {
            return (LogicEnums.eVehicleEnergySource)GetValidInputInstructionNumber(k_MinimalInstructionVehicleEnergySource, k_MaximalInstructionVehicleEnergySource);
        }

        internal static LogicEnums.eVehicleNumberOfDoors GetValidInputVehicleNumberOfDoors()
        {
            return (LogicEnums.eVehicleNumberOfDoors)GetValidInputInstructionNumber(k_MinimalInstructionNumberOfDoors, k_MaximalInstructionNumberOfDoors);
        }

        internal static LogicEnums.eVehicleColor GetValidInputVehicleColor()
        {
            return (LogicEnums.eVehicleColor)GetValidInputInstructionNumber(k_MinimalInstructionVehicleColor, k_MaximalInstructionVehicleColor);
        }

        internal static LogicEnums.eLicenseType GetValidInputLicenseType()
        {
            return (LogicEnums.eLicenseType)GetValidInputInstructionNumber(k_MinimalInstructionLicenseType, k_MaximalInstructionLicenseType);
        }

        internal static LogicEnums.eVehicleStatus GetValidInputVehicleStatus()
        {
            return (LogicEnums.eVehicleStatus)GetValidInputInstructionNumber(k_MinimalInstructionVehicleStatus, k_MaximalInstructionVehicleStatus);
        }

        internal static LogicEnums.eFuelType GetValidInputVehicleFuelType()
        {
            return (LogicEnums.eFuelType)GetValidInputInstructionNumber(k_MinimalInstructionVehicleFuelType, k_MaximalInstructionVehicleFuelType);
        }

        internal static LogicEnums.eVehicleType GetValidInputVehicleType()
        {
            return (LogicEnums.eVehicleType)GetValidInputInstructionNumber(k_MinimalInstructionVehicleType, k_MaximalInstructionVehicleType);
        }

        internal static UIEnums.eGarageServiceType GetValidInputServiceType()
        {
            return (UIEnums.eGarageServiceType)ValidInput.GetValidInputInstructionNumber(k_MinimalInstructionServiceType, k_MaximalInstructionServiceType);
        }

        internal static string GetValidString()
        {
            string inputString = null;
            bool isValidInput = false;
            while (!isValidInput)
            {
                inputString = Console.ReadLine();
                isValidInput = inputString.Length > 0;
                if (!isValidInput)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidEmptyInput);
                }
            }

            return inputString;
        }

        internal static byte GetValidByte()
        {
            byte inputByte = 0;
            bool isValidInput = false;
            while (!isValidInput || inputByte == 0)
            {
                string inputByteString = Console.ReadLine();
                isValidInput = byte.TryParse(inputByteString, out inputByte);
                if (!isValidInput || inputByte == 0)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidInputNumber);
                }
            }

            return inputByte;
        }

        internal static float GetValidFloat()
        {
            float inputFloat = 0f;
            bool isValidInput = false;
            while (!isValidInput || inputFloat < 0)
            {
                string inputFloatString = Console.ReadLine();
                isValidInput = float.TryParse(inputFloatString, out inputFloat);
                if (!isValidInput || inputFloat < 0)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidInputNumber);
                }
            }

            return inputFloat;
        }

        internal static int GetValidInt()
        {
            int inputInt = 0;
            bool isValidInput = false;
            while (!isValidInput || inputInt < 0)
            {
                string inputIntString = Console.ReadLine();
                isValidInput = int.TryParse(inputIntString, out inputInt);
                if (!isValidInput || inputInt < 0)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidInputNumber);
                }
            }

            return inputInt;
        }

        internal static string GetValidInputPlateNumber()
        {
            string plateNumber = Console.ReadLine();

            while (true)
            {
                if (plateNumber.Length < k_MinimalPlateNumberLength || plateNumber.Length > k_MaximalPlateNumberLength)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidLicensePlateFormatException);
                    plateNumber = Console.ReadLine();
                }
                else
                {
                    return plateNumber;
                }
            }
        }

        internal static string GetValidInputPhoneNumber()
        {
            string phoneNumber = Console.ReadLine();

            while (true)
            {
                if (!isStringOfDigits(phoneNumber) || phoneNumber.Length == 0)
                {
                    Console.WriteLine(UIStringMessages.k_InvalidInputException);
                    phoneNumber = Console.ReadLine();
                }
                else
                {
                    return phoneNumber;
                }
            }
        }

        internal static void GetCurrentValueSmallerThanMax(ref float o_VehicleRemainingEnergy, float i_VehicleMaxEnergy)
        {
            while (true)
            {
                if (o_VehicleRemainingEnergy > i_VehicleMaxEnergy)
                {
                    Console.WriteLine(UIStringMessages.k_FillUpMaxAmountException);
                    o_VehicleRemainingEnergy = GetValidFloat();
                }
                else
                {
                    return;
                }
            }
        }

        private static bool isStringOfDigits(string i_InputString)
        {
            bool resultIsDigitsString = true;
            foreach (char currentChar in i_InputString)
            {
                if (!char.IsDigit(currentChar))
                {
                    resultIsDigitsString = false;
                }
            }

            return resultIsDigitsString;
        }

        public static bool GetValidYesOrNoBoolean()
        {
            bool boolAnswer = false;
            string inputAnswer = Console.ReadLine();
            while (inputAnswer != k_YesAnswer && inputAnswer != k_NoAnswer)
            {
                Console.WriteLine(UIStringMessages.k_InvalidNoOrYesMsg);
                inputAnswer = Console.ReadLine();
            }

            if (inputAnswer == k_YesAnswer)
            {
                boolAnswer = true;
            }

            return boolAnswer;
        }
    }
}
