using System;
using System.Text;

namespace B20_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            printAnalyzeString();
        }

        // The method create a string builder of the analyze
        // Parameters: i_InputString the string to analyze
        //             i_IsPalindrome if the string is a palindrome
        //             i_StatisticsString the string builder for analyze
        // Return: StringBuilder string analyze
        private static StringBuilder createAnalyzeString(string i_InputString, bool i_IsPalindrome, StringBuilder i_StatisticsString)
        {
            if (isLettersString(i_InputString))
            {
                i_StatisticsString.AppendLine("The input is a string of letters, and the string statistics is:");
            }
            else
            {
                i_StatisticsString.AppendLine("The input is a string of digits, and the string statistics is:");
            }

            if (i_IsPalindrome)
            {
                i_StatisticsString.AppendLine("The input string is a palindrome");
            }
            else
            {
                i_StatisticsString.AppendLine("The input string is not a palindrome");
            }

            if (!IsDigitsString(i_InputString))
            {
                i_StatisticsString.AppendLine("The number of uppercase letters on the input string is: " + getNumberOfUpperCaseLetter(i_InputString));
            }
            else
            {
                if (checkIfDividedByFive(i_InputString))
                {
                    i_StatisticsString.AppendLine("The input string can be divided by 5");
                }
                else
                {
                    i_StatisticsString.AppendLine("The input string can not be divided by 5");
                }
            }

            return i_StatisticsString;
        }

        // The method get a valid string from user and print the analyze of string as required 
        // Parameters: none
        // Return: void
        private static void printAnalyzeString()
        {
            string inputString;
            StringBuilder statisticsString = new StringBuilder();

            Console.WriteLine("Please enter a string length 8 contain english letters or numbers (but no both):");
            while (true)
            {
                inputString = Console.ReadLine();
                if ((isLettersString(inputString) || IsDigitsString(inputString)) && inputString != null && inputString.Length == 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered invalid input please try again");
                }
            }

            bool isPalindrome = checkIfInputIsPalindrome(inputString, 0, inputString.Length - 1);
            Console.WriteLine(createAnalyzeString(inputString, isPalindrome, statisticsString));
            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); // Keep the console open
        }

        // The method count uppercase letters there are in the string
        // Parameters: i_InputStringForCheck string for check
        // Return: int the amount of uppercase letter
        private static int getNumberOfUpperCaseLetter(string i_InputStringForCheck)
        {
            int counterOfUpperCaseLetter = 0;

            for (int i = 0; i < i_InputStringForCheck.Length; i++)
            {
                if (char.IsUpper(i_InputStringForCheck[i]))
                {
                    counterOfUpperCaseLetter++;
                }
            }

            return counterOfUpperCaseLetter;
        }

        // The method check if number can divided by 5
        // Parameters: i_InputStringForCheck string for check
        // Return: bool true if the input can divided by 5
        private static bool checkIfDividedByFive(string i_InputStringForCheck)
        {
            return int.Parse(i_InputStringForCheck) % 5 == 0;
        }

        // The method check if string is palindrome between 2 indexes
        // Parameters: i_InputStringForCheck string for check
        //             i_IndexStartOfString the first index to check
        //             i_IndexEndOfString the last index to check
        // Return: bool true if the input is palindrome between the 2 indexes
        private static bool checkIfInputIsPalindrome(string i_InputStringForCheck, int i_IndexStartOfString, int i_IndexEndOfString)
        {
            bool isInputPalindrome = true;

            if (i_IndexStartOfString < i_IndexEndOfString)
            {
                if (i_InputStringForCheck[i_IndexStartOfString] != i_InputStringForCheck[i_IndexEndOfString])
                {
                    isInputPalindrome = false;
                }

                checkIfInputIsPalindrome(i_InputStringForCheck, i_IndexStartOfString + 1, i_IndexEndOfString - 1);
            }

            return isInputPalindrome;
        }

        // The method check if string contains only letters
        // Parameters: i_InputStringForCheck string for check
        // Return: bool true if the input contains only letters
        private static bool isLettersString(string i_InputStringForCheck)
        {
            bool isInputLettersString = true;

            for (int i = 0; i < i_InputStringForCheck.Length; i++)
            {
                if (!char.IsLetter(i_InputStringForCheck[i]))
                {
                    isInputLettersString = false;
                }
            }

            return isInputLettersString;
        }

        // The method check if string contains only numbers
        // Parameters: i_InputStringForCheck string for check
        // Return: bool true if the input contains only numbers
        public static bool IsDigitsString(string i_InputStringForCheck)
        {
            bool isInputDigitsString = true;

            for (int i = 0; i < i_InputStringForCheck.Length; i++)
            {
                if (!char.IsDigit(i_InputStringForCheck[i]))
                {
                    isInputDigitsString = false;
                }
            }

            return isInputDigitsString;
        }
    }
}
