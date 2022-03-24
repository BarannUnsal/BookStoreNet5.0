using FluentValidation;

namespace WebApi.Application.GenreOperations.Command.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenre>
    {
        public UpdateGenreValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(1).When(x => x.Model.Name != string.Empty);
        }
    }
}