using iLeafDecor.ViewModels.System.Languages;
using System.Collections.Generic;

namespace iLeafDecor.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<LanguageVM> Languages { get; set; }

        public string CurrentLanguageId { get; set; }
    }
}
