using FluentValidation;

namespace WebApi.BookOperations.DeleteBook.Application.Commands
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBooksCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.BookId).NotEmpty();
        }
    }
}