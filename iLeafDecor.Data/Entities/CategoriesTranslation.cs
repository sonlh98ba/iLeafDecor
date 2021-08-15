using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Data.Entities
{
    public class CategoriesTranslation
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTittle { get; set; }
        public int LanguageID { get; set; }
        public string SeoAlias { get; set; }
    }
}
