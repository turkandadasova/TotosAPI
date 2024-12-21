using Microsoft.EntityFrameworkCore;
using Totos.DAL;
using Totos.DTOs.Languages;
using Totos.Services.Abstracts;

namespace Totos.Services.Implements
{
    public class LanguageService(TotosDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Name = dto.Name,
                Icon = dto.Icon,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Code = x.Code,
                Icon = x.Icon,
                Name = x.Name,
            }).ToListAsync();
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
