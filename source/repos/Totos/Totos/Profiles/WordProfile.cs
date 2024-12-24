using AutoMapper;
using Totos.DTOs.Words;
using Totos.Entities;

namespace Totos.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word, WordGetDto>();

        }
    }
}
