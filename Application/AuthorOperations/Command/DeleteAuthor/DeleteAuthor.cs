using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthor
    {
        private readonly BookStoreDbContext _context;
        public int Id { get; set; }
        public DeleteAuthor(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == Id);
            if (author == null)
            {
                throw new InvalidOperationException("Silinecek Yazar Bulunamadı!");
            }
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}