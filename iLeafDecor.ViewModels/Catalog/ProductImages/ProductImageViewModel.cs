using System;

namespace iLeafDecor.ViewModels.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
    }
}
