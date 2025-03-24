using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LeagueDto;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILeagueRepository _leagueRepo;

        public LeagueController(IMapper mapper, ILeagueRepository leagueRepo)
        {
            this._leagueRepo=leagueRepo;
            this._mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leagues = await  _leagueRepo.GetAllLeaguesAsync();
            return Ok( _mapper.Map<List<GetLeagueDto>>(leagues));
        }

        [HttpGet]
        [Route("{LeagueId:int}")]
        public async Task<IActionResult> GetById([FromRoute]int LeagueId)
        {
            var league = await _leagueRepo.GetLeagueByIdAsync(LeagueId);
            if (league == null )
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetLeagueDto>(league) );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeagueDto leagueDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedLeague = _mapper.Map<League>(leagueDto);
            var league = await _leagueRepo.CreateLeagueAsync(mappedLeague);
            return CreatedAtAction(nameof(GetById), new {LeagueId = league.Id} , _mapper.Map<GetLeagueDto>(league));
        }
        [HttpPut]
        [Route("{LeagueId:int}")]
        public async Task<IActionResult> Update([FromRoute] int LeagueId, [FromBody] UpdateLeagueDto leagueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var league = await _leagueRepo.UpdateLeagueAsync(LeagueId, _mapper.Map<League>(leagueDto));
            if(league==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetLeagueDto>(league));
        } 
        [HttpDelete]
        [Route("{LeagueId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int LeagueId)
        {
            var league = await _leagueRepo.DeleteLeagueAsync(LeagueId);
            if(league == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}