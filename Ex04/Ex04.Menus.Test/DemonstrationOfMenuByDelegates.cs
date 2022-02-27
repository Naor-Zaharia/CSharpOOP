using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class DemonstrationOfMenuByDelegates
    {
        internal static void StartDemonstrationOfMenuByDelegate()
        {
            // Create menu items
            MainMenu mainMenuByDelegates = new MainMenu(MenuTestStringMessages.k_MainMenuTitleDelegate);
            MenuItem versionAndCapitalsItemByDelegates = new MenuItem(MenuTestStringMessages.k_VersionAndCapitalsTitle);
            MenuItem showDateAndTimeMainMenuItemByDelegates = new MenuItem(MenuTestStringMessages.k_ShowDateAndTimeTitle);
            MenuItem versionMenuItemByDelegates = new MenuItem(new MenuItemsActions.ShowVersion().StartFunctionality, MenuTestStringMessages.k_VersionTitle);
            MenuItem capitalsMenuItemByDelegates = new MenuItem(new MenuItemsActions.CountCapitals().StartFunctionality, MenuTestStringMessages.k_CapitalsTitle);
            MenuItem showTimeMenuItemByDelegates = new MenuItem(new MenuItemsActions.ShowTime().StartFunctionality, MenuTestStringMessages.k_ShowTimesTitle);
            MenuItem showDateMenuItemByDelegates = new MenuItem(new MenuItemsActions.ShowDate().StartFunctionality, MenuTestStringMessages.k_ShowDateTitle);

            // Main menu items list
            List<MenuItem> mainMenuByDelegatesItemList = new List<MenuItem>
                                                                 {
                                                                     versionAndCapitalsItemByDelegates,
                                                                     showDateAndTimeMainMenuItemByDelegates
                                                                 };

            // Version and Capitals items list
            List<MenuItem> firstMenuByDelegatesItemList = new List<MenuItem>
                                                                  {
                                                                      capitalsMenuItemByDelegates,
                                                                      versionMenuItemByDelegates
                                                                  };

            // Show Date/Time items list
            List<MenuItem> secondMenuByDelegatesItemList = new List<MenuItem>
                                                                   {
                                                                       showTimeMenuItemByDelegates,
                                                                       showDateMenuItemByDelegates
                                                                   };

            // Attach lists
            mainMenuByDelegates.AttachMenuItemsToMainMenu(mainMenuByDelegatesItemList);
            versionAndCapitalsItemByDelegates.AttachClickOnMenuItemObserver(firstMenuByDelegatesItemList);
            showDateAndTimeMainMenuItemByDelegates.AttachClickOnMenuItemObserver(secondMenuByDelegatesItemList);

            mainMenuByDelegates.Show();
        }
    }
}
