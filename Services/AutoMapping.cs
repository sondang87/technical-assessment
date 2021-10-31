using AutoMapper;
using Services.DTOs;
using Services.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<BaseModelDto, BaseModel>().ReverseMap();
        CreateMap<KeywordDto, Keyword>().ReverseMap();
        CreateMap<DocumentDto, Document>().ReverseMap();
        CreateMap<DocumentKeywordDto, DocumentKeyword>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
    }
}
