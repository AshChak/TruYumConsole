using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Dao;

namespace TruYumConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                MenuItemDaoCollectionTest menuItemDaoCollectionTest = new MenuItemDaoCollectionTest();
                menuItemDaoCollectionTest.TestGetMenuItemListAdmin();
                menuItemDaoCollectionTest.TestGetMenuItemListCustomer();
                menuItemDaoCollectionTest.TestModifyMenuItem();

                Console.WriteLine("1 object done.");

                CartDaoCollectionTest cartDaoCollectionTest = new CartDaoCollectionTest();
                cartDaoCollectionTest.TestAddCartItem();
                cartDaoCollectionTest.TestRemoveCartItem();

                Console.WriteLine("2 objects done.");

                MenuItemDaoSqlTest menuItemDaoSqlTest = new MenuItemDaoSqlTest();
                menuItemDaoSqlTest.TestGetMenuItemListAdmin();
                menuItemDaoSqlTest.TestGetMenuItemListCustomer();
                menuItemDaoSqlTest.TestEditMenuItem();
                menuItemDaoSqlTest.TestGetMenuItem();

                Console.WriteLine("3 objects done.");

                CartDaoSqlTest cartDaoSqlTest = new CartDaoSqlTest();
                cartDaoSqlTest.TestAddMenuItem();
                cartDaoSqlTest.TestGetMenuItems();
                cartDaoSqlTest.TestRemoveMenuItem();

                Console.WriteLine("4 objects done.");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Console.ReadKey();
        }
    }
}
