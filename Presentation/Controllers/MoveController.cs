using Application.Contracts.Movies;
using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.UpdateMovie;
using Application.Movies.Queries.GetMovies;
using Application.Movies.Queries.GetMoviesById;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    /// <summary>
    /// The users controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class MoveController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveController"/> class.
        /// </summary>
        /// <param name="sender"></param>
        public MoveController(ISender sender) => _sender = sender;

        /// <summary>
        /// Gets all of the users.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of users.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<MovieResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            var query = new GetMoviesQuery();

            var users = await _sender.Send(query, cancellationToken);

            return Ok(users);
        }

        /// <summary>
        /// Gets the user with the specified identifier, if it exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The user with the specified identifier, if it exists.</returns>
        [HttpGet("{userId:int}")]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieById(int movieId, CancellationToken cancellationToken)
        {
            var query = new GetMovieByIdQuery(movieId);

            var user = await _sender.Send(query, cancellationToken);

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user based on the specified request.
        /// </summary>
        /// <param name="request">The create user request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created user.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateMovieCommand>();

            var user = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetMovieById), new { userId = user.Id }, user);
        }

        /// <summary>
        /// Updates the user with the specified identifier based on the specified request, if it exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="request">The update user request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpPut("{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovie(int movieId, [FromBody] UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateMovieCommand>() with
            {
                MovieId = movieId
            };

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
