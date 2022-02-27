using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private const string k_ExitString = "Exit";
        private const string k_BackString = "Back";
        private readonly List<MenuItem> r_MenuItemList;
        private readonly List<IClickOnMenuItemObserver> r_ClickOnMenuItemObserverList;
        private MenuItem m_FatherMenuItem;
        private string m_ItemName;

        public MenuItem(List<IClickOnMenuItemObserver> i_ClickOnMenuItemObserverList, string i_ItemName)
        {
            this.r_MenuItemList = new List<MenuItem>();
            this.r_ClickOnMenuItemObserverList = i_ClickOnMenuItemObserverList;
            this.m_FatherMenuItem = null;
            this.m_ItemName = i_ItemName;
        }

        public MenuItem(string i_ItemName)
        {
            this.r_MenuItemList = new List<MenuItem>();
            this.r_ClickOnMenuItemObserverList = null;
            this.m_FatherMenuItem = null;
            this.m_ItemName = i_ItemName;
        }
        
        public string ItemName
        {
            get { return m_ItemName; }

            set { m_ItemName = value; }
        }

        // The method return the current menu item father
        // Parameters: None
        // Return: MenuItem - current menu item father
        public MenuItem GetMenuItemFather()
        {
            return this.m_FatherMenuItem;
        }

        // The method return amount of menu items under this item
        // Parameters: None
        // Return: int - amount of menu items under this item
        public int GetAmountOfItems()
        {
            return this.r_MenuItemList.Count;
        }

        // The method return menu item under this, by index
        // Parameters: i_MenuItemIndex - the index of the required menu item
        // Return: MenuItem - the required menu item
        internal MenuItem GetMenuItemOnIndex(int i_MenuItemIndex)
        {
            return this.r_MenuItemList[i_MenuItemIndex];
        }

        // The method do menu item functionality on click
        // Parameters: None
        // Return: void
        public void OnMenuItemClick()
        {
            if (this.IsLeafItem())
            {
                this.doItemFunctionality();
            }
            else
            {
                this.ShowAllSubMenuItems();
            }
        }

        // The method attach menu items under current menu item 
        // Parameters: i_SubMenuItemList - menu items that the user want add under current menu item
        // Return: void
        public void AttachClickOnMenuItemObserver(List<MenuItem> i_SubMenuItemList)
        {
            foreach (MenuItem currentMenuItem in i_SubMenuItemList)
            {
                r_MenuItemList.Add(currentMenuItem);
                currentMenuItem.m_FatherMenuItem = this;
            }
        }

        // The method detach menu items from current menu item 
        // Parameters: i_SubMenuItemList - menu items that the user want remove from current menu item
        // Return: void
        public void DetachClickOnMenuItemObserver(List<MenuItem> i_SubMenuItemList)
        {
            foreach (MenuItem currentMenuItem in i_SubMenuItemList)
            {
                r_MenuItemList.Remove(currentMenuItem);
            }
        }

        // The method create string line of menu item
        // Parameters: i_ItemIndexOnMenu - line index
        // Return: string - the line that represent the line
        internal string GetLineOfMenu(int i_ItemIndexOnMenu)
        {
            return string.Format(
@"{0}. {1}
",
i_ItemIndexOnMenu,
this.m_ItemName);
        }

        // The method check if this menu item is leaf (have functionality)
        // Parameters: None
        // Return: bool - true if item is leaf
        internal bool IsLeafItem()
        {
            return this.r_ClickOnMenuItemObserverList != null;
        }

        // The method execute all the functionality of menu item on click
        // Parameters: None
        // Return: void
        private void doItemFunctionality()
        {
            foreach (IClickOnMenuItemObserver currentClickOnMenuItemFunctionality in r_ClickOnMenuItemObserverList)
            {
                currentClickOnMenuItemFunctionality.StartFunctionality();
            }
        }

        // The method print the current menu level
        // Parameters: None
        // Return: void
        internal void ShowAllSubMenuItems()
        {
            Console.Clear();
            StringBuilder currentMenuStringBuilder = new StringBuilder();
            currentMenuStringBuilder.Append(string.Format(
@"{0}:
",
this.ItemName));
            currentMenuStringBuilder.Append(createBackOrExitString());
            int itemIndex = 1;
            foreach (MenuItem observer in r_MenuItemList)
            {
                currentMenuStringBuilder.Append(observer.GetLineOfMenu(itemIndex++));
            }

            Console.WriteLine(currentMenuStringBuilder.ToString());
        }

        // The method add string of exit or back to current menu level
        // Parameters: None
        // Return: string - the string of back or exit
        private string createBackOrExitString()
        {
            string resultString;
            if (this.m_FatherMenuItem == null)
            {
                resultString = string.Format(
@"0. {0}
",
k_ExitString);
            }
            else
            {
                resultString = string.Format(
@"0. {0}
",
k_BackString);
            }

            return resultString;
        }
    }
}