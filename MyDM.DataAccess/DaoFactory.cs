using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.DataAccess
{
    public class DaoFactory
    {
        public static ICustomersDao GetCustomersDao()
        {
            return new CustomersDao();
        }

        public static IProductsDao GetProductsDao()
        {
            return new ProductsDao();
        }
    }
}
