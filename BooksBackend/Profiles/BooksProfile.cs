using AutoMapper;
using BooksBackend.Domain;
using BooksBackend.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksBackend.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            // Book => BooksResponseItem
            CreateMap<Book, BooksResponseItem>();
            CreateMap<Book, GetBookDetailsResponse>();
            CreateMap<BookCreateRequest, Book>()
                .ForMember(dest => dest.IsInInventory, opt => opt.MapFrom((x) => true))
                .ForMember(dest => dest.DateAdded, opt => opt.MapFrom((x) => DateTime.Now))
                .ForMember(dest => dest.MarkedForSale, opt => opt.MapFrom((x) => false));
        }
    }
}
