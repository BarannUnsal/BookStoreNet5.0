using FluentValidation;

namespace WebApi.BookOperations.GetBookDetails.Application.Query
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}