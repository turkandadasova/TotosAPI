using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Totos.DTOs.Languages;
using Totos.Services.Abstracts;

namespace Totos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(LanguageDeleteDto dto)
        {
            await _service.DeleteAsync(dto);
            return Ok();
        }

    }
}
