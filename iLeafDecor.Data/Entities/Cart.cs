using System;

namespace iLeafDecor.Data.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedDate { get; set; }

        public AppUser AppUser { get; set; }
    }
}
