using AutoMapper;
using Totos.DTOs.Languages;
using Totos.Entities;

namespace Totos.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                .ForMember(l=>l.Icon,lcd=>lcd.MapFrom(x=>x.IconUrl));

            CreateMap<Language, LanguageGetDto>();

        }
    }
}
