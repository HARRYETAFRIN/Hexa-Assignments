using System;
using System.Collections.Generic;
using System.Text;

namespace OrderBillingApp.Models
{
    public class Order
    {
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
