using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Trans
    {
        public int TransID { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string TransDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool WholesaleSign { get; set; }
        public ICollection<DiscountTrans> DiscountTrans { get; set; }
        public ICollection<ProductTrans> ProductTrans { get; set; }
    }
}
