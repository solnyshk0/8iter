using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.Dto
{
    public class ProductsDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int WholesalePrice { get; set; }
        public int RetailPrice { get; set; }
        public string? Description { get; set; }
        public int? Cost { get; set; }

    }
}
