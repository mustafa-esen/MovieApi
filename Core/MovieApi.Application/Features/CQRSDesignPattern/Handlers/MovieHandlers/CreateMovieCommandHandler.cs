using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context; 

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMovieCommand createMovieCommand)
        {
            _context.Movies.Add(new()
            {
                CoverImageUrl = createMovieCommand.CoverImageUrl,
                CreatedYear = createMovieCommand.CreatedYear,
                Description = createMovieCommand.Description,
                Duration = createMovieCommand.Duration,
                Rating = createMovieCommand.Rating,
                ReleaseDate = createMovieCommand.ReleaseDate,
                Status = createMovieCommand.Status,
                Title = createMovieCommand.Title
            });
            await _context.SaveChangesAsync();
        }   
    }
}
