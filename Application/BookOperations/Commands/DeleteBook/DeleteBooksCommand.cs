using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteBook.Application.Commands
{
    public class DeleteBooksCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBooksCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamad─▒!");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}