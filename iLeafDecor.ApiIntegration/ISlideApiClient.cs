using iLeafDecor.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iLeafDecor.ApiIntegration
{
    public interface ISlideApiClient
    {
        Task<List<SlideVM>> GetAll();
    }
}
