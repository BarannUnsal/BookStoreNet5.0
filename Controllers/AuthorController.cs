using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Command.CreateAuthor;
using WebApi.Application.AuthorOperations.Command.DeleteAuthor;
using WebApi.Application.AuthorOperations.Command.UpdateAuthor;
using WebApi.Application.AuthorOperations.Query.GetAuthor;
using WebApi.Application.AuthorOperations.Query.GetAuthorDetails;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            GetAuthorDetails query = new GetAuthorDetails(_context, _mapper);
            query.Id = id;

            GetAuthorDetailsValidator validator = new GetAuthorDetailsValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorViewModel newAuthor)
        {
            CreateAuthor command = new CreateAuthor(_context, _mapper);
            command.Model = newAuthor;

            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateAuthorViewModel updatedAuthor)
        {
            UpdateAuthor command = new UpdateAuthor(_context);
            command.Id = id;
            command.Model = updatedAuthor;

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthor command = new DeleteAuthor(_context);
            command.Id = id;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}