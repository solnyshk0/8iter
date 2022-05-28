using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.BuisenessLayer
{
    public class ProcessFactory
    {
        public static ICustomersProcess GetCustomersProcess()
        {
            return new CustomersProcess();
        }

        public static IProductProcess GetProductsProcess()
        {
            return new ProductProcess();
        }
    }
}
