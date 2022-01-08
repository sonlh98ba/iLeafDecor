using System;
using System.Collections.Generic;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class ProductVM
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTittle { get; set; }
        public string LanguageID { get; set; }
        public string SeoAlias { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
