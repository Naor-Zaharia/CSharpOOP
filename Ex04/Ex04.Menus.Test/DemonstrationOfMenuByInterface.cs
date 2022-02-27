using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class DemonstrationOfMenuByInterface
    {
        internal static void StartDemonstrationOfMenuByInterface()
        {
            // Create menu items
            MainMenu mainMenuByInterface = new MainMenu(MenuTestStringMessages.k_MainMenuTitleInterface);
            MenuItem versionAndCapitalsMainMenuItemByInterface = new MenuItem(MenuTestStringMessages.k_VersionAndCapitalsTitle);
            MenuItem showDateAndTimeMainMenuItemByInterface = new MenuItem(MenuTestStringMessages.k_ShowDateAndTimeTitle);
            MenuItem versionMenuItemByInterface = new MenuItem(new List<IClickOnMenuItemObserver>() { new MenuItemsActions.ShowVersion() }, MenuTestStringMessages.k_VersionTitle);
            MenuItem capitalsMenuItemByInterface = new MenuItem(new List<IClickOnMenuItemObserver>() { new MenuItemsActions.CountCapitals() }, MenuTestStringMessages.k_CapitalsTitle);
            MenuItem showTimeMenuItemByInterface = new MenuItem(new List<IClickOnMenuItemObserver>() { new MenuItemsActions.ShowTime() }, MenuTestStringMessages.k_ShowTimesTitle);
            MenuItem showDateMenuItemByInterface = new MenuItem(new List<IClickOnMenuItemObserver>() { new MenuItemsActions.ShowDate() }, MenuTestStringMessages.k_ShowDateTitle);

            // Main menu items list
            List<MenuItem> mainMenuByInterfaceItemList = new List<MenuItem>
            {
                versionAndCapitalsMainMenuItemByInterface,
                showDateAndTimeMainMenuItemByInterface
            };

            // Version and Capitals items list
            List<MenuItem> firstMenuByInterfaceItemList = new List<MenuItem>
            {
                capitalsMenuItemByInterface,
                versionMenuItemByInterface
            };

            // Show Date/Time items list
            List<MenuItem> secondMenuByInterfaceItemList = new List<MenuItem>
            {
                showTimeMenuItemByInterface,
                showDateMenuItemByInterface
            };

            // Attach lists
            mainMenuByInterface.AttachMenuItemsToMainMenu(mainMenuByInterfaceItemList);
            versionAndCapitalsMainMenuItemByInterface.AttachClickOnMenuItemObserver(firstMenuByInterfaceItemList);
            showDateAndTimeMainMenuItemByInterface.AttachClickOnMenuItemObserver(secondMenuByInterfaceItemList);

            mainMenuByInterface.Show();
        }
    }
}
