using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.UpdateMovie
{


    public sealed record UpdateMovieRequest(int Id, string Title, string Description, decimal Price, int GenreType);
}
