using Totos.DTOs.Languages;

namespace Totos.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task UpdateAsync(LanguageUpdateDto dto);
        Task DeleteAsync(LanguageDeleteDto dto);

    }
}
