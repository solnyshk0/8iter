using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class DiscountTrans
    {
        public int ID { get; set; }
        public int TransId { get; set; }
        public Trans Trans { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
