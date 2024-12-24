using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Totos.DAL;
using Totos.DTOs.Languages;
using Totos.DTOs.Words;
using Totos.Entities;
using Totos.Exceptions.Words;
using Totos.Services.Abstracts;

namespace Totos.Services.Implements
{
    public class WordService(TotosDbContext _context, IMapper _mapper) : IWordService
    {
        public async Task CreateAsync(WordCreateDto dto)
        {
            if( await _context.Words.AnyAsync(x=>x.Id==dto.Id))
                throw new WordExistException();
            await _context.Words.AddAsync(_mapper.Map<Word>(dto));
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(WordDeleteDto dto)
        {
            var word = await _context.Words.Where(x=>x.Id == dto.Id).FirstOrDefaultAsync();
            if (word == null)
            {
                throw new Exception("soz tapilmadi :(");
            }
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas = _context.Words.ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);

        }

        public async Task UpdateAsync(WordUpdateDto dto)
        { 
            if (await _context.Words.AnyAsync(x=> x.Id==dto.Id))
            {
                throw new Exception("Dil tapilmadi :(");
            };          
            _context.Words.Update(_mapper.Map<Word>(dto));
            await _context.SaveChangesAsync();

        }
    }
}
