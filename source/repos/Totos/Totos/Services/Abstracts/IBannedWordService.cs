using Totos.DTOs.BannedWords;
using Totos.DTOs.Words;

namespace Totos.Services.Abstracts
{
    public interface IBannedWordService
    {
        Task CreateAsync(BannedWordCreateDto dto);
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task UpdateAsync(BannedWordUpdateDto dto);
        Task DeleteAsync(BannedWordDeleteDto dto);
    }
}
