using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovies
{
    internal sealed class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, List<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetMoviesQueryHandler(IMovieRepository userRepository) => _movieRepository = userRepository;

        public async Task<List<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var users = await _movieRepository.GetAsync(cancellationToken);

            return users.Adapt<List<MovieResponse>>(); //Mapster
        }
    }
}
