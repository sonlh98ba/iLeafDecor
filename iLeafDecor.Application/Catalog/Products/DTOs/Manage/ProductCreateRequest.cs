using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Application.Catalog.Products.DTOs.Manage
{
    public class ProductCreateRequest
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTittle { get; set; }
        public string LanguageID { get; set; }
        public string SeoAlias { get; set; }
    }
}
