using FluentValidation;

namespace WebApi.Application.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenre>
    {
        public DeleteGenreValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}