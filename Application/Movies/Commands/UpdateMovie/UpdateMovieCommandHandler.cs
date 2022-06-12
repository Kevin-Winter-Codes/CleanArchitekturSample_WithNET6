using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;


namespace Application.Movies.Commands.UpdateMovie
{
    internal sealed class UpdateMovieCommandHandler : ICommandHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMovieCommandHandler(IMovieRepository userRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie movie = await _movieRepository.GetByIdAsync(request.MovieId, cancellationToken);

            if (movie is null)
            {
                throw new MovieNotFoundException(request.MovieId);
            }

            movie.Id = request.MovieId;
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Price = request.Price;
            movie.Genre = request.Genre;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
