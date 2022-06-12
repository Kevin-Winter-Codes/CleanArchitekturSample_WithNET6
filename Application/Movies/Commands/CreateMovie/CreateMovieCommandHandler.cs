using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.CreateMovie
{
    internal sealed class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie movie = new Movie();
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Price = request.Price;
            movie.Genre = request.Genre;

            _movieRepository.Insert(movie);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return movie.Adapt<MovieResponse>();
        }
    }
}
