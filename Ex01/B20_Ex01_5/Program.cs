using System;
using System.Text;

namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            printInputNumberStatistics();
        }

        // The method get a digits string and print the required number statistics
        // Parameters: none
        // Return: void
        private static void printInputNumberStatistics()
        {
            string inputString;
            StringBuilder statisticsString = new StringBuilder();

            Console.WriteLine("Please enter a digits string length 9:");
            while (true)
            {
                inputString = Console.ReadLine();
                if (B20_Ex01_4.Program.IsDigitsString(inputString) && inputString != null && inputString.Length == 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered invalid input please try again");
                }
            }

            statisticsString.AppendLine("The input number statistics are:");
            statisticsString.AppendLine("The maximal digit that appear on the number was: " + getMaximalDigitOnString(inputString));
            statisticsString.AppendLine("The minimal digit that appear on the number was: " + getMinimalDigitOnString(inputString));
            statisticsString.AppendLine("The amount of digits that can be divided by 3 is: " + getCounterOfDigitsDividedByThree(inputString));
            statisticsString.AppendLine("The amount of digits that are bigger than the rightest digit is: " + getCounterOfDigitsBiggerTheUnitDigit(inputString));
            Console.WriteLine(statisticsString);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); // Keep the console open
        }

        // The method get a digits string and return the maximal digit in the input number
        // Parameters: i_InputString string of digits
        // Return: int the maximal digit on string
        private static int getMaximalDigitOnString(string i_InputString)
        {
            int maximalDigit = 0;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                int currentDigit = i_InputString[i] - '0';

                if (currentDigit > maximalDigit)
                {
                    maximalDigit = currentDigit;
                }
            }

            return maximalDigit;
        }

        // The method get a digits string and return the minimal digit in the input number
        // Parameters: i_InputString string of digits
        // Return: int the minimal digit on string
        private static int getMinimalDigitOnString(string i_InputString)
        {
            int minimalDigit = 9;

            for (int i = 0; i < i_InputString.Length; i++)
            {
                int currentDigit = i_InputString[i] - '0';

                if (currentDigit < minimalDigit)
                {
                    minimalDigit = currentDigit;
                }
            }

            return minimalDigit;
        }

        // The method get a digits string and counts the number of digits that can be divided by 3
        // Parameters: i_InputString string of digits
        // Return: int the amount of digits that can be divided by 3
        private static int getCounterOfDigitsDividedByThree(string i_InputString)
        {
            int counterOfDigitsDividedByThree = 0;
            for (int i = 0; i < i_InputString.Length; i++)
            {
                int currentDigit = i_InputString[i] - '0';

                if (currentDigit % 3 == 0)
                {
                    counterOfDigitsDividedByThree++;
                }
            }

            return counterOfDigitsDividedByThree;
        }

        // The method get a digits string and counts the number of digits that are bigger than the rightest digit
        // Parameters: i_InputString string of digits
        // Return: int the amount of digits bigger than the rightest digit
        private static int getCounterOfDigitsBiggerTheUnitDigit(string i_InputString)
        {
            int counterDigitsThatBigger = 0;
            int rightestDigit = i_InputString[i_InputString.Length - 1] - '0';

            for (int i = 0; i < i_InputString.Length - 1; i++)
            {
                int currentDigit = i_InputString[i] - '0';

                if (currentDigit > rightestDigit)
                {
                    counterDigitsThatBigger++;
                }
            }

            return counterDigitsThatBigger;
        }
    }
}
