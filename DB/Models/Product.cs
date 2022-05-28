using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int WholesalePrice { get; set; }
        public int RetailPrice { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public ICollection<ProductTrans> ProductTrans { get; set; }

    }
}
