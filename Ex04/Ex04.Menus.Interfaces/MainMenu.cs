using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenuItem;
       
        public MainMenu(string i_MainMenuName)
        {
            this.r_MainMenuItem = new MenuItem(i_MainMenuName);
        }
        
        public MenuItem MainMenuItem
        {
            get { return r_MainMenuItem; }
        }

        // The method attach menu items under the main menu 
        // Parameters: i_SubMenuItemList - menu items that the user want add under main menu
        // Return: void
        public void AttachMenuItemsToMainMenu(List<MenuItem> i_SubMenuItemList)
        {
            r_MainMenuItem.AttachClickOnMenuItemObserver(i_SubMenuItemList);
        }

        // The method detach menu items from the main menu 
        // Parameters: i_SubMenuItemList - menu items that the user want remove from main menu
        // Return: void
        public void DetachMenuItemToMainMenu(List<MenuItem> i_SubMenuItemList)
        {
            r_MainMenuItem.DetachClickOnMenuItemObserver(i_SubMenuItemList);
        }

        // The method print the main menu and let the user select from the menu items 
        // Parameters: None
        // Return: void
        public void Show()
        {
            this.r_MainMenuItem.ShowAllSubMenuItems();
            UserChosenMenuItem.UserMenuItemPick(r_MainMenuItem);
        }
    }
}
