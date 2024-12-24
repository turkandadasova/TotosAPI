using Totos.DTOs.Languages;
using Totos.DTOs.Words;

namespace Totos.Services.Abstracts
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task UpdateAsync(WordUpdateDto dto);
        Task DeleteAsync(WordDeleteDto dto);
    }
}
