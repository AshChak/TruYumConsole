using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Model;
using Com.Cognizant.Truyum.Utility;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoCollectionTest
    {
        public static void Main(string[] args)
        {

        }

        public void TestGetMenuItemListAdmin()
        {
            MenuItemDaoCollection menuItemDao = new MenuItemDaoCollection();
            foreach (var item in menuItemDao.GetMenuItemListAdmin())
            {
                Console.WriteLine(item);
            }
        }
        public void TestGetMenuItemListCustomer()
        {
            MenuItemDaoCollection menuItemDao = new MenuItemDaoCollection();
            foreach (var item in menuItemDao.GetMenuItemListCustomer())
            {
                Console.WriteLine(item);
            }
        }
        public void TestModifyMenuItem()
        {
            MenuItem menuItem;
            MenuItemDaoCollection menuItemDaoCollection = new MenuItemDaoCollection();
            menuItem = menuItemDaoCollection.MenuItemList[1];
            menuItemDaoCollection.ModifyMenuItem(menuItem);
            menuItemDaoCollection.GetMenuItem(menuItem.Id);
        }
        public void TestGetMenuItem() { }

    }
}
