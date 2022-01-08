using System.Collections.Generic;

namespace iLeafDecor.Data.Entities
{
    public class Language
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
