using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoCollection : IMenuItemDao
    {
        private List<MenuItem> menuItemList;

        public List<MenuItem> MenuItemList
        {
            get { return menuItemList; }
            set { menuItemList = value; }
        }

        public MenuItemDaoCollection()
        {
            if (MenuItemList==null)
            {
                MenuItemList = new List<MenuItem>();
                MenuItem item1 = new MenuItem(1,"Basil Tomato & Mozzarella Cheese Sandwich",235,true,DateTime.Today,"Main Course",true);
                MenuItemList.Add(item1);
                MenuItem item2 = new MenuItem(2, "Cheese Croissant", 155, false, DateTime.Today.AddDays(5), "Main Course", true);
                MenuItemList.Add(item2);
                MenuItem item3 = new MenuItem(3, "Nitro Cold Brew", 295, true, DateTime.Today, "Beverages", true);
                MenuItemList.Add(item3);
                MenuItem item4 = new MenuItem(4, "Double Chocolate Chip Frappuccino", 295, true, DateTime.Today, "Beverages", true);
                MenuItemList.Add(item4);
                MenuItem item5 = new MenuItem(5, "Hazlenut Chocolate Cruffin", 205, true, DateTime.Today, "Dessert", true);
                MenuItemList.Add(item5);
            }
        }

        public MenuItem GetMenuItem(long menuItemId)
        {
            foreach (var item in MenuItemList)
            {
                if (item.Id==menuItemId)
                {
                    return item;
                }
            }
            return null;
        }

        public List<MenuItem> GetMenuItemListAdmin()
        {
            return MenuItemList;
        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
            List<MenuItem> menuItems=new List<MenuItem>();
            foreach (var item in menuItemList)
            {
                if (!(item.DateOfLaunch>DateTime.Today) && item.Active==true)
                {
                    menuItems.Add(item);
                }
            }
            return menuItems;
        }

        public void ModifyMenuItem(MenuItem menuItem)
        {
            for (int i = 0; i < MenuItemList.Count; i++)
            {
                if (MenuItemList[i].Id==menuItem.Id)
                {
                    MenuItemList[i] = menuItem;
                }
            }
        }

        //public void TestModifyMenuItem()
        //{
        //    MenuItem menuItem = MenuItemList[1];
        //    MenuItemDaoCollection menuItemDaoCollection = new MenuItemDaoCollection();
        //    ModifyMenuItem(menuItem);
        //    GetMenuItem(menuItem.Id);
        //    throw new NotImplementedException();
        //}
    }
}
