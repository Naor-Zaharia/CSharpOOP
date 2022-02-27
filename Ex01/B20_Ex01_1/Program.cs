using System;

namespace B20_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            binarySeries();
        }
        
        // The method get valid input and print the decimal presentation of the numbers and the required statistics 
        // Parameters: none
        // Return: void
        private static void binarySeries()
        {
            string[] inputBinaryStringsArray = new string[3];
            inputBinaryStringsArray = getInputsFromUser();
            printInputsAsDecimal(inputBinaryStringsArray);
            printInputsStatistics(inputBinaryStringsArray);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); // Keep the console open
        }

        // The method get valid input from the user
        // Parameters: none
        // Return: inputStringsArray valid input string array
        private static string[] getInputsFromUser()
        {
            string[] inputStringsArray = new string[3];

            Console.WriteLine("Please enter 3 integers in binary format with 9 digits on each");
            for (int i = 0; i < 3; i++)
            {
                inputStringsArray[i] = getValidBinaryInput();
            }

            return inputStringsArray;
        }

        // The method get valid input binary string from the user
        // Parameters: none
        // Return: binaryIntAsString valid binary string
        private static string getValidBinaryInput()
        {
            while (true)
            {
                string binaryIntAsString = Console.ReadLine();

                for (int i = 0; i < 9 && binaryIntAsString != null && binaryIntAsString.Length == 9; i++)
                {
                    if (binaryIntAsString[i] != '0' && binaryIntAsString[i] != '1')
                    {
                        break;
                    }

                    if (i == 8)
                    {
                        return binaryIntAsString;
                    }
                }

                Console.WriteLine("You entered invalid input, please try again");
            }
        }

        // The method get binary strings array and print the decimal representation
        // Parameters: string [] of binary strings
        // Return: void
        private static void printInputsAsDecimal(string[] i_InputBinaryStringsArray)
        {
            Console.WriteLine("Printing of inputs values as decimal:");
            for (int i = 0; i < i_InputBinaryStringsArray.Length; i++)
            {
                Console.WriteLine(convertBinaryStringToInt(i_InputBinaryStringsArray[i]));
            }

            Console.WriteLine();
        }

        // The method get binary string and return his decimal representation
        // Parameters: string of binary number
        // Return: int inputAsInt the converted string as int
        private static int convertBinaryStringToInt(string i_InputBinaryString)
        {
            int inputAsInt = 0;

            for (int i = i_InputBinaryString.Length - 1; i >= 0; i--)
            {
                inputAsInt += (i_InputBinaryString[i] - '0') * (int)Math.Pow(2, i_InputBinaryString.Length - 1 - i);
            }

            return inputAsInt;
        }

        // The method get binary string and return his decimal representation
        // Parameters: string[] of binary numbers
        //             char the number to do average for
        // Return: float the average of i_DigitForCount on i_InputBinaryStringsArray
        private static float getAverageOfDigitOnBinaryString(string[] i_InputBinaryStringsArray, char i_DigitForCount)
        {
            int counterOfCharInString = 0;

            for (int i = 0; i < i_InputBinaryStringsArray.Length; i++)
            {
                for (int j = 0; j < i_InputBinaryStringsArray[i].Length; j++)
                {
                    if (i_InputBinaryStringsArray[i][j] == i_DigitForCount)
                    {
                        counterOfCharInString++;
                    }
                }
            }

            return (float)counterOfCharInString / i_InputBinaryStringsArray.Length;
        }

        // The method get binary string and return how much numbers are power of two
        // Parameters: string [] of binary numbers
        // Return: int counterPowOfTwoInInput the amount of numbers that power of two
        private static int getCounterOfPowerTwoInArray(string[] i_InputBinaryStringsArray)
        {
            int counterPowOfTwoInInput = 0;
            int currentOnesOnNumber;

            for (int i = 0; i < i_InputBinaryStringsArray.Length; i++)
            {
                currentOnesOnNumber = 0;
                for (int j = 0; j < i_InputBinaryStringsArray[i].Length; j++)
                {
                    if (i_InputBinaryStringsArray[i][j] == '1')
                    {
                        currentOnesOnNumber++;
                    }
                }

                if (currentOnesOnNumber == 1)
                {
                    counterPowOfTwoInInput++;
                }
            }

            return counterPowOfTwoInInput;
        }

        // The method get binary string and print the required statistics 
        // Parameters: string [] of binary numbers
        // Return: void
        private static void printInputsStatistics(string[] i_InputBinaryStringsArray)
        {
            int minNumber = getMinimalNumberOnInputArray(i_InputBinaryStringsArray);
            int maxNumber = getMaximalNumberOnInputArray(i_InputBinaryStringsArray);
            float averageOfZeros = getAverageOfDigitOnBinaryString(i_InputBinaryStringsArray, '0');
            float averageOfOnes = getAverageOfDigitOnBinaryString(i_InputBinaryStringsArray, '1');
            int counterOfNumbersPowOfTwo = getCounterOfPowerTwoInArray(i_InputBinaryStringsArray);
            int counterOfNumbersAscendingSeries = getCounterIsAscendingSerie(i_InputBinaryStringsArray);

            string statisticsMessage = string.Format(
@"The average of zeros on input is: {0} 
The average of ones on input is: {1}
The number of inputs that are power of two: {2}
The minimun input is: {3}
The maximun input is: {4}
The number of inputs that are ascending series is: {5}",
                averageOfZeros,
                averageOfOnes,
                counterOfNumbersPowOfTwo,
                minNumber,
                maxNumber,
                counterOfNumbersAscendingSeries);
            Console.WriteLine(statisticsMessage);
        }

        // The method get binary string and return the minimal number on the array 
        // Parameters: string [] of binary numbers
        // Return: int the minimal number on the array
        private static int getMinimalNumberOnInputArray(string[] i_InputBinaryStringsArray)
        {
            int currentMinNumber = convertBinaryStringToInt(i_InputBinaryStringsArray[0]);
            int currentNumberAsInt;

            for (int i = 1; i < i_InputBinaryStringsArray.Length; i++)
            {
                currentNumberAsInt = convertBinaryStringToInt(i_InputBinaryStringsArray[i]);

                if (currentMinNumber > currentNumberAsInt)
                {
                    currentMinNumber = currentNumberAsInt;
                }
            }

            return currentMinNumber;
        }

        // The method get binary string and return the maximal number on the array 
        // Parameters: string [] of binary numbers
        // Return: int the maximal number on the array
        private static int getMaximalNumberOnInputArray(string[] i_InputBinaryStringsArray)
        {
            int currentMaxNumber = convertBinaryStringToInt(i_InputBinaryStringsArray[0]);
            int currentNumberAsInt;

            for (int i = 1; i < i_InputBinaryStringsArray.Length; i++)
            {
                currentNumberAsInt = convertBinaryStringToInt(i_InputBinaryStringsArray[i]);

                if (currentMaxNumber < currentNumberAsInt)
                {
                    currentMaxNumber = currentNumberAsInt;
                }
            }

            return currentMaxNumber;
        }

        // The method get binary string and return amount of numbers that are ascending serie 
        // Parameters: string [] of binary numbers
        // Return: int the amount of numbers that are ascending serie
        private static int getCounterIsAscendingSerie(string[] i_InputBinaryStringsArray)
        {
            int counterOfNumbersAscendingSeries = 0;
            int currentInputAsInt;
            int currentDigit;

            for (int i = 0; i < i_InputBinaryStringsArray.Length; i++)
            {
                currentInputAsInt = convertBinaryStringToInt(i_InputBinaryStringsArray[i]);
                currentDigit = currentInputAsInt % 10;

                while (currentInputAsInt != 0)
                {
                    currentInputAsInt /= 10;
                    if (currentInputAsInt == 0)
                    {
                        counterOfNumbersAscendingSeries++;
                    }

                    if (currentDigit <= currentInputAsInt % 10)
                    {
                        break;
                    }

                    currentDigit = currentInputAsInt % 10;
                }
            }

            return counterOfNumbersAscendingSeries;
        }
    }
}
