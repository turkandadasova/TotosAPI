using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Totos.DTOs.Languages;
using Totos.DTOs.Words;
using Totos.Exceptions;
using Totos.Services.Abstracts;

namespace Totos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is IBaseException bEx)
                {
                    return StatusCode(bEx.StatusCode, new
                    {                        
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(ex.Message);

                }
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> Create(WordCreateDto dto)
        //{
        //   var data = _mapper.Map<Word>(dto);
        //    return Ok(data);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(WordUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(WordDeleteDto dto)
        {
            await _service.DeleteAsync(dto);
            return Ok();
        }
    }
}
