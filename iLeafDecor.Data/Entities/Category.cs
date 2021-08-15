using iLeafDecor.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace iLeafDecor.Data.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentID { get; set; }
        public Status Status { get; set; }
    }
}
