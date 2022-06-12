using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Entities;

namespace Application.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieCommand(int Id, string Title, string Description, decimal Price, GenreType Genre) : ICommand<MovieResponse>;
}
