using iLeafDecor.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVM>> GetAll();
    }
}
