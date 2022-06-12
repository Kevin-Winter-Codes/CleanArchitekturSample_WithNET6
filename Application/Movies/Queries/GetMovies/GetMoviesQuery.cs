﻿using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Queries.GetMovies
{
    public sealed record GetMoviesQuery() : IQuery<List<MovieResponse>>;
}
