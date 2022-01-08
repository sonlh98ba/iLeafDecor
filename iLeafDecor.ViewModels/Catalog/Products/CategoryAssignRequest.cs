using iLeafDecor.ViewModels.Common;
using System.Collections.Generic;

namespace iLeafDecor.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
