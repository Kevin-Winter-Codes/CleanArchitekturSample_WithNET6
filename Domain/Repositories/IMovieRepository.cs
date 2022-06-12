using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAsync(CancellationToken cancellationToken = default);
        Task<Movie> GetByIdAsync(int movieId, CancellationToken cancellationToken = default);
        void Insert(Movie movie);
    }

   
}
