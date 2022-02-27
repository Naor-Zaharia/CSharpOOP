using System;

namespace Ex04.Menus.Delegates
{
    internal class UserChosenMenuItem
    {
        // The method take a menu item pick from user until, he press on exit menu item
        // Parameters: i_MenuItem - the current menu item that the user can select from his items
        // Return: void
        internal static void UserMenuItemPick(MenuItem i_MenuItem)
        {
            MenuItem currentMenuItem = i_MenuItem;
            bool isExitPressed = false;
            while (!isExitPressed)
            {
                Console.WriteLine(StringMessages.k_InsertInputMsg);
                byte userInput = ValidInput.GetValidInput(currentMenuItem);
                if (userInput == 0)
                {
                    executeExitOrBack(ref currentMenuItem, ref isExitPressed);
                }
                else
                {
                    Console.Clear();
                    currentMenuItem.GetMenuItemOnIndex(userInput - 1).DoWhenMenuItemSelected();
                    if (currentMenuItem.GetMenuItemOnIndex(userInput - 1).IsLeafItem())
                    {
                        Console.WriteLine(
                            string.Format(
@"
{0}",
StringMessages.k_ContinueMsg));
                        Console.ReadLine();
                        currentMenuItem.ShowAllSubMenuItems();
                    }
                    else
                    {
                        currentMenuItem = currentMenuItem.GetMenuItemOnIndex(userInput - 1);
                    }
                }
            }
        }

        // The method handle user press on back or exit items
        // Parameters: io_MenuItem - the current menu item that the user on
        //             o_IsExitPressed - reference to boolean that check if exit menu item pressed
        // Return: void
        private static void executeExitOrBack(ref MenuItem io_MenuItem, ref bool o_IsExitPressed)
        {
            if (io_MenuItem.GetMenuItemFather() == null)
            {
                o_IsExitPressed = true;
            }
            else
            {
                io_MenuItem = io_MenuItem.GetMenuItemFather();
                io_MenuItem.ShowAllSubMenuItems();
            }
        }
    }
}
