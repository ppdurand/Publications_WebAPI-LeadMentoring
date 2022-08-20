using AutoMapper;
using publication.Dto;
using publication.Models;

namespace publication.util;

public class AutoMapperProfile : Profile
{  
    public AutoMapperProfile()
    {
        CreateMap<Publication, PublicationDto>().ReverseMap();
        CreateMap<Publication, PublicationCreateDto>().ReverseMap();
        CreateMap<Publication, PublicationDetailsDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();

    }
}