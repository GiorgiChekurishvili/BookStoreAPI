using AutoMapper;
using BookStore.DTOs.Author;
using BookStore.DTOs.Book;
using BookStore.DTOs.Genre;
using BookStore.DTOs.Publisher;
using BookStore.DTOs.Transaction;
using BookStore.DTOs.User;
using BookStore.Entities;

namespace BookStore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<Book, BookRetrieveDTO>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
            .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre.GenreName).ToList()))
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.PublisherName));
            CreateMap<BookUploadUpdateDTO, Book>();
            CreateMap<PublisherDTO, Publisher>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Author, AuthorRetrieveDTO>()
                .ForMember(dest => dest.BooksWritten, opt => opt.MapFrom(src => src.Books.Select(x => x.BookName).ToList()));
            CreateMap<Publisher, PublisherRetrieveDTO>()
                .ForMember(dest => dest.BooksPublished, x => x.MapFrom(src => src.Books.Select(x => x.BookName).ToList()));
            CreateMap<UserRegisterDTO, User>();
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.BookName, x => x.MapFrom(src => src.book!.BookName));
            CreateMap<BuyBookTransactionDTO, Transaction>();
            
            
        }
    }

}
