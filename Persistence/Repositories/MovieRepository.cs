using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public Task<List<Movie>> GetAsync(CancellationToken cancellationToken = default) =>
            _dbContext.Movies.ToListAsync(cancellationToken);

        public Task<Movie> GetByIdAsync(int userId, CancellationToken cancellationToken = default) =>
            _dbContext.Movies.FirstOrDefaultAsync(user => user.Id == userId, cancellationToken);

        public void Insert(Movie movie) => _dbContext.Movies.Add(movie);
    }
}
