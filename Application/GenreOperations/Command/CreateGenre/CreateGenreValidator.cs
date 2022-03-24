using FluentValidation;

namespace WebApi.Application.GenreOperations.Command.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenre>
    {
        public CreateGenreValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
        }
    }
}