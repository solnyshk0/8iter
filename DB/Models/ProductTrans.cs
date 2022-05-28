using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class ProductTrans
    {
        public int Id { get; set; }
        public int TransId { get; set; }
        public Trans Trans { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
