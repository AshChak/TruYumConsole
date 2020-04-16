using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Com.Cognizant.Truyum.Dao
{
    public class ConnectionHandler
    {
        public static SqlConnection GetConnection() {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        }
    }
}
