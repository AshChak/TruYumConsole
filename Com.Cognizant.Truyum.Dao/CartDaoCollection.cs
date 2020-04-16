using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Model;

namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoCollection : ICartDao
    {
        private static Dictionary<long,Cart> userCarts;

        public static Dictionary<long,Cart> UserCarts
        {
            get { return userCarts; }
            set { userCarts = value; }
        }

        public CartDaoCollection()
        {
            if (UserCarts==null)
            {
                UserCarts = new Dictionary<long, Cart>();
            }
        }

        public void AddCartItem(long userId, long menuItemId)
        {
            MenuItemDaoCollection menuItemDaoCollection = new MenuItemDaoCollection();
            MenuItem menuItem = menuItemDaoCollection.GetMenuItem(menuItemId);
            if (UserCarts.ContainsKey(userId))
            {
                userCarts[userId].MenuItemList.Add(menuItem);
            }
            else
            {
                Cart cart = new Cart();
                cart.MenuItemList = new List<MenuItem>();
                cart.MenuItemList.Add(menuItem);
                UserCarts.Add(userId, cart);
            }
            
        }

        public Cart GetAllCartItems(long userId)
        {
            List<MenuItem> menuItems = UserCarts[userId].MenuItemList;
            if (menuItems.Count==0)
            {
                throw new CartEmptyException();
            }
            else
            {
                foreach (var item in menuItems)
                {
                    UserCarts[userId].Total += item.Price;
                }
                return UserCarts[userId];
            }
            
        }

        public void RemoveCartItem(long userId, long menuItemId)
        {
            List<MenuItem> menuItems = UserCarts[userId].MenuItemList;

            foreach (var item in menuItems)
            {
                if (item.Id==menuItemId)
                {
                    UserCarts[userId].MenuItemList.Remove(item);
                    break;
                }
            }
        }
    }
}
