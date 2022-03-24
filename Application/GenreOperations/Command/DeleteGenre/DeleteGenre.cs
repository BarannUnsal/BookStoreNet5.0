using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenre
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenre(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.GenreId == Id);
            if (genre == null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}