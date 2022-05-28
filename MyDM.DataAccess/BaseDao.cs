using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace MyDB.DataAccess
{
    abstract class BaseDao
    {
        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["sqlconfig"].ConnectionString;
        }
        protected static SqlConnection GetConnection()
        {
            var connString = GetConnectionString();
            return new SqlConnection(connString);
        }
    }
}
