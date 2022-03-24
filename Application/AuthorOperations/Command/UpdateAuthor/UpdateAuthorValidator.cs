using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthor>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(1).When(x => x.Model.Name != string.Empty);
        }
    }
}