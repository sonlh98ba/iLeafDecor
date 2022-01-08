using iLeafDecor.ViewModels.Catalog.Products;
using iLeafDecor.ViewModels.Utilities.Slides;
using System.Collections.Generic;

namespace iLeafDecor.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVM> Slides { get; set; }

        public List<ProductVM> FeaturedProducts { get; set; }
    }
}
