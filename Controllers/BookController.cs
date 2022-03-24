using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations;
using WebApi.BookOperations.Application;
using WebApi.BookOperations.Application.Commands;
using WebApi.BookOperations.CreateBooksApplication;
using WebApi.BookOperations.CreateBooksApplication.Commands;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.DeleteBook.Application;
using WebApi.BookOperations.DeleteBook.Application.Commands;
using WebApi.BookOperations.GetBookDetails;
using WebApi.BookOperations.GetBookDetails.Application;
using WebApi.BookOperations.GetBookDetails.Application.Query;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooks.Application;
using WebApi.BookOperations.GetBooks.Application.Query;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.UpdateBook.Application;
using WebApi.BookOperations.UpdateBook.Application.Commands;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBooksApplication.Commands.CreateBooksCommand;
using static WebApi.BookOperations.GetBookDetails.Application.Query.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.Application.Commands.UpdateBookCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailValidator validator = new GetBookDetailValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookViewModel newBook)
        {
            CreateBooksCommand command = new CreateBooksCommand(_context, _mapper);
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
            command.BookId = id;
            command.Model = updatedBook;
            UpdateBooksCommandValidator validator = new UpdateBooksCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBooksCommand command = new DeleteBooksCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}