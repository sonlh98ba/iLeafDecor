using iLeafDecor.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Data.Entities
{
    public class Promotion
    {
        public int ID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public int ProductIDs { get; set; }
        public int ProductCategoryIDs { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
    }
}
