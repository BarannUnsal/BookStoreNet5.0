using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Command.UpdateGenre
{
    public class UpdateGenre
    {
        public int Id { get; set; }
        public UpdateGenreViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateGenre(BookStoreDbContext context)
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
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.GenreId != Id))
            {
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut!");
            }
            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}