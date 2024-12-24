using AutoMapper;
using Totos.DTOs.BannedWords;
using Totos.DTOs.Languages;
using Totos.Entities;

namespace Totos.Profiles
{
    public class BannedWordProfile:Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWordCreateDto, BannedWord>().ForMember(b=>b.Id, bcd => bcd.MapFrom(x => x.Id));

            CreateMap<BannedWord, BannedWordGetDto>();
        }
    }
}
