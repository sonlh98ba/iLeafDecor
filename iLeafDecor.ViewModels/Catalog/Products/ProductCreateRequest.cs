using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTittle { get; set; }
        public string LanguageID { get; set; }
        public string SeoAlias { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
