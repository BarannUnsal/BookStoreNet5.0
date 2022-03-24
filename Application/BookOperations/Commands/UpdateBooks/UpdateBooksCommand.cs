using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.BookOperations.GetBooks.Application.Query;
using WebApi.DbOperations;
namespace WebApi.BookOperations.UpdateBook.Application.Commands
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            Console.WriteLine(book);
            if (book == null)
            {
                throw new InvalidCastException("Güncellenecek kitap bulunamadın!");
            }

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(book);
            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}