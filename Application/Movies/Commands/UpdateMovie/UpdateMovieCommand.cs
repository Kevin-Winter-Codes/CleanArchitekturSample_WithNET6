using Application.Abstractions.Messaging;
using Domain.Entities;
using MediatR;


namespace Application.Movies.Commands.UpdateMovie
{
    public sealed record UpdateMovieCommand(int MovieId, string Title, string Description, decimal Price, GenreType Genre) : ICommand<Unit>;
}
