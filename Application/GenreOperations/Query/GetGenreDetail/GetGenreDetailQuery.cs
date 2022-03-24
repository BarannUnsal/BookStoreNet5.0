using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Query.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int Id { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenresDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.GenreId == Id);
            if (genre == null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            }
            return _mapper.Map<GenresDetailViewModel>(genre);
        }

    }
    public class GenresDetailViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}