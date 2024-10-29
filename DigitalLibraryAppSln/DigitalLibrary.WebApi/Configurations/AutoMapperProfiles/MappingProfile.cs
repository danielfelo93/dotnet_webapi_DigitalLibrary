using AutoMapper;
using DigitalLibrary.WebApi.Dtos.Book;
using DigitalLibrary.WebApi.Models;

namespace DigitalLibrary.WebApi.Configurations.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookRequestDto>().ReverseMap();
            CreateMap<Book, BookResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap(); 
        }
    }
}
