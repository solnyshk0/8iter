using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string ContactPerson { get; set; }
        public uint Phone { get; set; }
        public string Address { get; set; }
        public List<Trans> Trans { get; set; }
    }
}
