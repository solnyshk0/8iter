using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public uint DiscountSize { get; set; }
        public ICollection<DiscountTrans> DiscountTrans { get; set; }
    }
}
