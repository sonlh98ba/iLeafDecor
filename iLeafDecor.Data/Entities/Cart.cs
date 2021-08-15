using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Data.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
