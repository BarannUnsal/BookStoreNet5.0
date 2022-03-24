using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Query.GetAuthorDetails
{
    public class GetAuthorDetails
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public AuthorDetailViewModel Model { get; set; }
        public GetAuthorDetails(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(x => x.AuthorId == Id).SingleOrDefault();
            if (author == null)
            {
                throw new InvalidOperationException("Aranan Yazar bulunamadı!");
            }
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
            return vm;
        }
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}