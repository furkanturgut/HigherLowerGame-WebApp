using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CountryDtos;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepo;

        public CountryController(IMapper mapper, ICountryRepository countryRepo)
        {
            this._countryRepo= countryRepo;
            this._mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await  _countryRepo.GetAllAsync();
            return Ok( _mapper.Map<List<GetCountryDto>>(countries));
        }

        [HttpGet]
        [Route("{CountryId:int}")]
        public async Task<IActionResult> GetById([FromRoute]int CountryId)
        {
            var country = await _countryRepo.GetByIdAsync(CountryId);
            if (country == null )
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetCountryDto>(country) );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryDto countryDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedCountry = _mapper.Map<Country>(countryDto);
            var country = await _countryRepo.CreateCountryAsync(mappedCountry);
            return CreatedAtAction(nameof(GetById), new {CountryId = country.Id} , _mapper.Map<GetCountryDto>(country));
        }
        [HttpPut]
        [Route("{CountryId:int}")]
        public async Task<IActionResult> Update([FromRoute] int CountryId, [FromBody] UpdateCountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var country = await _countryRepo.UpdateCountryAsync(CountryId, _mapper.Map<Country>(countryDto));
            if(country==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetCountryDto>(country));
        } 
        [HttpDelete]
        [Route("{CountryId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int CountryId)
        {
            var country = await _countryRepo.DeleteCountryAsync(CountryId);
            if(country == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}