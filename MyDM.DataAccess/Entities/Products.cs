using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.DataAccess.Entities
{
    public class Products
    {
        public int ProductID;
        public string Name;
        public int WholesalePrice;
        public int RetailPrice;
        public string? Description;
        public int? Cost;
    }
}
