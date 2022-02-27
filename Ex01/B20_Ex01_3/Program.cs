using System;

namespace B20_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            createSandClockByInput();
        }

        // The method get the length of the first line and print sand clock 
        // Parameters: none
        // Return: void
        private static void createSandClockByInput()
        {
            string sandClockHeightString;
            int sandClockHeightInt;
            bool isValidInput = false;

            Console.WriteLine("Please enter height for the sandclock:");
            while (true)
            {
                sandClockHeightString = Console.ReadLine();
                isValidInput = int.TryParse(sandClockHeightString, out sandClockHeightInt);
                if (isValidInput && sandClockHeightInt > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered invalid input please try again");
                }
            }

            if (sandClockHeightInt % 2 == 0)
            {
                sandClockHeightInt--;
            }

            B20_Ex01_2.Program.PrintSandClock(sandClockHeightInt);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); // Keep the console open
        }
    }
}
