using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthor
    {
        private readonly BookStoreDbContext _context;
        public UpdateAuthorViewModel Model { get; set; }
        public int Id { get; set; }
        public UpdateAuthor(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == Id);
            if (author == null)
            {
                throw new InvalidOperationException("Güncellemek istediğiniz yazar bulunamadı!");
            }
            if (_context.Authors.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.AuthorId == Id))
            {
                throw new InvalidOperationException("Yazar zaten mevcut!");
            }
            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.BirthOfDate = Model.BirthOfDate;
            _context.SaveChanges();

        }
    }
    public class UpdateAuthorViewModel
    {
        public string Name { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}