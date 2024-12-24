using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Totos.DAL;
using Totos.DTOs.BannedWords;
using Totos.DTOs.Words;
using Totos.Entities;
using Totos.Exceptions.BannedWords;
using Totos.Services.Abstracts;

namespace Totos.Services.Implements
{
    public class BannedWordServiceWordService(TotosDbContext _context, IMapper _mapper) : IBannedWordService
    {
        public async Task CreateAsync(BannedWordCreateDto dto)
        {
            if (await _context.BannedWords.AnyAsync(x => x.Id == dto.Id))
                throw new BannedWordExistException();
            await _context.BannedWords.AddAsync(_mapper.Map<BannedWord>(dto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BannedWordDeleteDto dto)
        {
            var bword = await _context.BannedWords.FirstOrDefaultAsync( x => x.Id == dto.Id);
            if (bword == null)
            {
                throw new BannedWordNotFoundException();
            }
            _context.Remove(bword);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            var datas = _context.BannedWords.ToListAsync();
            return _mapper.Map<IEnumerable<BannedWordGetDto>>(datas);
        }

        public async Task UpdateAsync(BannedWordUpdateDto dto)
        {
            if(await _context.BannedWords.AnyAsync(x => x.Id == dto.Id))
            throw new BannedWordNotFoundException();
            
            _context.BannedWords.Update(_mapper.Map<BannedWord>(dto));
            await _context.SaveChangesAsync();
        }
    }
}
