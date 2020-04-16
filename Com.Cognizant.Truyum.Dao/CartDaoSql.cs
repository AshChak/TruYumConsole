using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Com.Cognizant.Truyum.Model;

namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoSql
    {
        public void AddMenuItem(long userId, long menuItemId)
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into menu_item values(@userId, @menuItemId)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@menuItemId", menuItemId);
                sqlCommand.ExecuteNonQuery();
            }            
        }

        public List<MenuItem> GetMenuItems(long userId)
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();
            List<MenuItem> menuItems = new List<MenuItem>();
            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from menu_item m left join cart c on m.me_id=c.ct_me_id where ct_id=@userId", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ct_us_id", userId);
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

        public void RemoveMenuItem(long userId, long menuItemId)
        {
            SqlConnection sqlConnection = ConnectionHandler.GetConnection();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("delete from cart " +
                    "where ct_us_id = @userId, ct_me_id = @menuItemId",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@menuItemId", menuItemId);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
