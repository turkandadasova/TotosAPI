using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Totos.DAL;
using Totos.DTOs.Languages;
using Totos.Entities;
using Totos.Exceptions.Languages;
using Totos.Services.Abstracts;

namespace Totos.Services.Implements
{
    public class LanguageService(TotosDbContext _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var datas = await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);
        }

        public async Task UpdateAsync(LanguageUpdateDto dto)
        {
            var language = await _context.Languages.Where(x => x.Code == dto.Code)
                .FirstOrDefaultAsync();
            if (language == null)
            {
                throw new Exception("Dil tapilmadi :(");
            }

            language.Name = dto.Name;
            language.Icon = dto.Icon;
            language.Code = dto.Code;
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(LanguageDeleteDto dto)
        {
            var language = await _context.Languages.Where(x => x.Code == dto.Code)
                .FirstOrDefaultAsync();
            if (language == null)
            {
                throw new Exception("Dil tapilmadi :(");
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

        }

    }
}
