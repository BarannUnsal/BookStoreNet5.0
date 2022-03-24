using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthor
    {
        public CreateAuthorViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public CreateAuthor(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author != null)
            {
                throw new InvalidOperationException("Varolan yazarı yeniden ekleyemezsiniz!");
            }
            author = new Author();
            author.Name = Model.Name;
            author.BirthOfDate = Model.BirthOfDate;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}