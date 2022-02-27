using System;

namespace Ex04.Menus.Delegates
{
    internal class ValidInput
    {
        // The method get valid menu item input according to the current menu item
        // Parameters: i_MenuItem - the current menu item that the user can select from his items
        // Return: byte - the new menu item index on the menu item param
        internal static byte GetValidInput(MenuItem i_MenuItem)
        {
            while (true)
            {
                string currentInput = Console.ReadLine();
                bool isValidInput = byte.TryParse(currentInput, out byte menuItemInstructionCode);
                if (isValidInput && menuItemInstructionCode < i_MenuItem.GetAmountOfItems() + 1)
                {
                    return menuItemInstructionCode;
                }
                else
                {
                    Console.WriteLine(StringMessages.k_InvalidInputMsg);
                }
            }
        }
    }
}
