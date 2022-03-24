using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.BirthOfDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}