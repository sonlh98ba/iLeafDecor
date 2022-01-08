using iLeafDecor.Data.EF;
using iLeafDecor.ViewModels.Utilities.Slides;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLeafDecor.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly ILeafDBContext _context;

        public SlideService(ILeafDBContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVM>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}
