using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Tolkien",
                        BirthOfDate = new DateTime(1920, 10, 10)
                    },
                    new Author
                    {
                        Name = "Yaşar Kemal",
                        BirthOfDate = new DateTime(1930, 11, 11)
                    },
                    new Author
                    {
                        Name = "Orhan Kemal",
                        BirthOfDate = new DateTime(1940, 12, 12)
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Noval"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Murtaza",
                        GenreId = 1,
                        PageCount = 250,
                        PublishDate = new DateTime(2001, 06, 12),
                        AuthorId = 3
                    },
                    new Book
                    {
                        Title = "Ince Memed",
                        GenreId = 2,
                        PageCount = 350,
                        PublishDate = new DateTime(1968, 11, 25),
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "Lort Of The Rings",
                        GenreId = 2,
                        PageCount = 560,
                        PublishDate = new DateTime(1970, 02, 04),
                        AuthorId = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}