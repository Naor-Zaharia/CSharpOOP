using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class MenuItemsActions
    {
        public class ShowDate : IClickOnMenuItemObserver
        {
            // The method print current date
            // Parameters: None
            // Return: void
            public void StartFunctionality()
            {
                Console.WriteLine(DateTime.Today.Date.ToString("D"));
            }
        }

        public class ShowTime : IClickOnMenuItemObserver
        {
            // The method print current time
            // Parameters: None
            // Return: void
            public void StartFunctionality()
            {
                Console.Write(DateTime.Now.ToString("HH:mm:ss tt"));
            }
        }

        public class ShowVersion : IClickOnMenuItemObserver
        {
            // The method print version
            // Parameters: None
            // Return: void
            public void StartFunctionality()
            {
                Console.WriteLine(MenuTestStringMessages.k_ShowVersionMsg);
            }
        }

        public class CountCapitals : IClickOnMenuItemObserver
        {
            // The method get input string and count the capital letters in it
            // Parameters: None
            // Return: void
            public void StartFunctionality()
            {
                int capitalLettersCounter = 0;
                Console.WriteLine(MenuTestStringMessages.k_CountCapitalInputMsg);
                string inputString = Console.ReadLine();
                foreach (char currentChar in inputString)
                {
                    if (char.IsUpper(currentChar))
                    {
                        capitalLettersCounter++;
                    }
                }

                Console.WriteLine(string.Format("{0} {1}", MenuTestStringMessages.k_CountCapitalResultMsg, capitalLettersCounter));
            }
        }
    }
}
