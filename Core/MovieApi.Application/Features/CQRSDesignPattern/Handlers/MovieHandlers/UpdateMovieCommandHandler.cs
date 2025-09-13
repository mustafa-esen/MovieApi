using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand updateMovieCommand)
        {
            var value = await _context.Movies.FindAsync(updateMovieCommand.MovieId);
            value.Title = updateMovieCommand.Title;
            value.Description = updateMovieCommand.Description;
            value.CoverImageUrl = updateMovieCommand.CoverImageUrl;
            value.CreatedYear = updateMovieCommand.CreatedYear;
            value.Duration = updateMovieCommand.Duration;
            value.Rating = updateMovieCommand.Rating;
            value.ReleaseDate = updateMovieCommand.ReleaseDate;
            value.Status = updateMovieCommand.Status;
            await _context.SaveChangesAsync();
        }   
    }
}
