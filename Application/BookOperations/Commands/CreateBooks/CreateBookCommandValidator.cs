using System;
using FluentValidation;
using WebApi.BookOperations.CreateBooksApplication;
using WebApi.BookOperations.CreateBooksApplication.Commands;

namespace WebApi.BookOperations.Application.Commands
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}