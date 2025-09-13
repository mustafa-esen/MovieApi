using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = await _context.Categories.FindAsync(updateCategoryCommand.CategoryId);
            value.CategoryName = updateCategoryCommand.CategoryName;
            _context.SaveChangesAsync();
        }
    }
}
