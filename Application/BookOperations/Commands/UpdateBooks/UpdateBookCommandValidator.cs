using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook.Application.Commands
{
    public class UpdateBooksCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBooksCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}