using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.BookOperations.GetBookDetails.Application.Query
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public BookDetailViewModel Model { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Id == BookId).SingleOrDefault();

            if (book == null)
            {
                throw new InvalidOperationException("Aranan kitap bulunamadı!");
            }

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }

        public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }
    }
}