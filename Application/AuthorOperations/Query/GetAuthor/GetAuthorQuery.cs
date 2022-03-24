using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Query.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.AuthorId);
            List<AuthorViewModel> returnObj = _mapper.Map<List<AuthorViewModel>>(authorList);

            return returnObj;
        }
    }
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}