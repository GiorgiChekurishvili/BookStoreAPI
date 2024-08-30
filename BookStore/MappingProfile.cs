﻿using AutoMapper;
using BookStore.DTOs;
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
            
        }
    }

}
