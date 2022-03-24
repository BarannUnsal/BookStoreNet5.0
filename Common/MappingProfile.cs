using AutoMapper;
using WebApi.Application.AuthorOperations.Query.GetAuthor;
using WebApi.Application.AuthorOperations.Query.GetAuthorDetails;
using WebApi.Application.GenreOperations.Query;
using WebApi.Application.GenreOperations.Query.GetGenre;
using WebApi.Application.GenreOperations.Query.GetGenreDetail;
using WebApi.BookOperations.GetBooks.Application.Query;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBooksApplication.Commands.CreateBooksCommand;
using static WebApi.BookOperations.GetBookDetails.Application.Query.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<Author, AuthorViewModel>().ForMember(dest => dest.BirthOfDate, opt => opt.MapFrom(src => src.BirthOfDate.ToString("dd/MM/yyyy")));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.BirthOfDate, opt => opt.MapFrom(src => src.BirthOfDate.ToString("dd/MM/yyyy")));
        }
    }
}