using FluentValidation;

namespace WebApi.Application.AuthorOperations.Query.GetAuthorDetails
{
    public class GetAuthorDetailsValidator : AbstractValidator<GetAuthorDetails>
    {
        public GetAuthorDetailsValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}