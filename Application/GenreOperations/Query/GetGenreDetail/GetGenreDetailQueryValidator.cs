using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Query.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }

    }
}