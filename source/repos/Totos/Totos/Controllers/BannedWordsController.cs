﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Totos.DTOs.BannedWords;
using Totos.DTOs.Languages;
using Totos.Exceptions;
using Totos.Services.Abstracts;

namespace Totos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordService _service, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BannedWordCreateDto dto)
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
                        StatusCode = bEx.StatusCode,
                        Message = bEx.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message

                    });

                }
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> Create(LanguageCreateDto dto)
        //{
        //   var data = _mapper.Map<Language>(dto);
        //    return Ok(data);
        //}

        [HttpPut]
        public async Task<IActionResult> Update(BannedWordUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BannedWordDeleteDto dto)
        {
            await _service.DeleteAsync(dto);
            return Ok();
        }
    }
}