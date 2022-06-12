using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMoviesById
{
    public sealed record GetMovieByIdQuery(int MovieId) : IQuery<MovieResponse>;
}
