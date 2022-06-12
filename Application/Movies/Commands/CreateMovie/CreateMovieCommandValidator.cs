using FluentValidation;

namespace Application.Movies.Commands.CreateMovie
{
    public sealed class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).LessThan(99);

            RuleFor(x => x.Genre).NotEmpty();
        }
    }
}
