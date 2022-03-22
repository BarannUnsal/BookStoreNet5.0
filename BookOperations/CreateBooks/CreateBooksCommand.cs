using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.CreateBooks
{
    public class CreateBooksCommand
    {
        public CreateBookViewModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBooksCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Varolan kitap yeniden eklenemez!");

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public class CreateBookViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}