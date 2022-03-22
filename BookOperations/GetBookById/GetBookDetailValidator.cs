using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}