using AutoMapper;
using BookManager.Application.Models;
using BookManager.Domain;


namespace BookManager.Application.Helpers
{
    public class ApplicationMappers: Profile
    {
        public ApplicationMappers()
        {
            CreateMap<AuthorEntity, AuthorDto>();
            CreateMap<AuthorDto, AuthorEntity>();
            CreateMap<BookEntity, BookDto>();
            CreateMap<BookDto, BookEntity>();
            CreateMap<AuthorEntity, BookEntity>();
            CreateMap<BookEntity, AuthorEntity>();
        }
    }
}
