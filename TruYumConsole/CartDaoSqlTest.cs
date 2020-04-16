using Com.Cognizant.Truyum.Dao;
using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruYumConsole
{
    public class CartDaoSqlTest
    {
        public void TestAddMenuItem()
        {
            CartDaoSql cartDaoSql = new CartDaoSql();
            cartDaoSql.AddMenuItem(1, 1);
        }

        public void TestGetMenuItems()
        {
            CartDaoSql cartDaoSql = new CartDaoSql();
            foreach (var item in cartDaoSql.GetMenuItems(1))
            {
                Console.WriteLine(item);
            }            

        }

        public void TestRemoveMenuItem()
        {
            CartDaoSql cartDaoSql = new CartDaoSql();
            cartDaoSql.RemoveMenuItem(1, 1);
        }

    }
}
