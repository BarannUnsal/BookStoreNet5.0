using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Command.CreateGenre
{
    public class CreateGenre
    {
        public CreateGenreViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public CreateGenre(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre != null)
            {
                throw new InvalidOperationException("Kitap Türü Zaten Mevcut!");
            }
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

    }
    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}