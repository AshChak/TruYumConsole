using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoSql
    {
        public List<MenuItem> GetMenuItemListAdmin()
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            List<MenuItem> menuItems = new List<MenuItem>();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from menu_item", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItem item = new MenuItem();
                        item.Id = reader.GetInt64(0);
                        item.Name = reader.GetString(1);
                        item.Price = reader.GetFloat(2);
                        item.Active = (reader.GetString(3) == "yes" ? true : false);
                        item.DateOfLaunch = reader.GetDateTime(4);
                        item.Category = reader.GetString(5);
                        item.FreeDelivery = (reader.GetString(6) == "yes" ? true : false);
                        menuItems.Add(item);
                    }
                }

            }
            return menuItems;
        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            List<MenuItem> menuItems = new List<MenuItem>();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from menu_item where me_active='yes' and me_date_of_launch<=@today", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@today", DateTime.Today.ToString("d"));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItem item = new MenuItem();
                        item.Id = reader.GetInt64(0);
                        item.Name = reader.GetString(1);
                        item.Price = reader.GetFloat(2);
                        item.Active = (reader.GetString(3) == "yes" ? true : false);
                        item.DateOfLaunch = reader.GetDateTime(4);
                        item.Category = reader.GetString(5);
                        item.FreeDelivery = (reader.GetString(6) == "yes" ? true : false);
                        menuItems.Add(item);
                    }
                }

            }
            return menuItems;
        }

        public MenuItem GetMenuItem(long menuItemId)
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            MenuItem item = new MenuItem();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from menu_item where me_id=@menuItemId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@menuItemId", menuItemId);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    item.Id = reader.GetInt64(0);
                    item.Name = reader.GetString(1);
                    item.Price = reader.GetFloat(2);
                    item.Active = (reader.GetString(3) == "yes" ? true : false);
                    item.DateOfLaunch = reader.GetDateTime(4);
                    item.Category = reader.GetString(5);
                    item.FreeDelivery = (reader.GetString(6) == "yes" ? true : false);

                }

            }
            return item;
        }

        public void EditMenuItem(MenuItem menuItem)
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("update menu_item set me_name=@name, " +
                "me_price=@price, me_active=@active, me_date_of_launch=@date, me_category=@category, " +
                "me_free_delivery=@delivery where me_id=@id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@name", menuItem.Name);
                sqlCommand.Parameters.AddWithValue("@price", menuItem.Price);
                sqlCommand.Parameters.AddWithValue("@active", menuItem.Active);
                sqlCommand.Parameters.AddWithValue("@date", menuItem.DateOfLaunch);
                sqlCommand.Parameters.AddWithValue("@category", menuItem.Category);
                sqlCommand.Parameters.AddWithValue("@delivery", menuItem.FreeDelivery);
                sqlCommand.Parameters.AddWithValue("@id", menuItem.Id);

                sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
