using Com.Cognizant.Truyum.Dao;
using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumConsole
{
    public class CartDaoCollectionTest
    {
        public void TestAddCartItem()
        {
            CartDaoCollection cartDao = new CartDaoCollection();
            cartDao.AddCartItem(1, 1);
            List<MenuItem> menuItems = cartDao.GetAllCartItems(1).MenuItemList;
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }

        }

        public void TestGetAllCartItems() { }
        public void TestRemoveCartItem()
        {
            CartDaoCollection cartDao = new CartDaoCollection();
            cartDao.RemoveCartItem(1, 1);
            try
            {
                cartDao.GetAllCartItems(1);
            }
            catch (CartEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
