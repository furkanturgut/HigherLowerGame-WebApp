using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TeamDtos;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepo;

        public TeamController(IMapper mapper, ITeamRepository teamRepo)
        {
            this._mapper=mapper;
            this._teamRepo=teamRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamRepo.GetAllTeamsAsync();
            return Ok(_mapper.Map<List<GetTeamDto>>(teams));
        }
        [HttpGet]
        [Route("{TeamId:int}")]
        public async Task<IActionResult> GetById ([FromRoute]int TeamId)
        {
            var team = await _teamRepo.GetTeamByIdAsync(TeamId);
            if (team==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTeamDto>(team));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTeamDto teamDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var team= await _teamRepo.CreateTeamAsync(_mapper.Map<Team>(teamDto));
            return CreatedAtAction(nameof(GetById), new {TeamId = team.Id}, _mapper.Map<GetTeamDto>(team));
        }

        [HttpPut]
        [Route("{TeamId:int}")]
        public async Task<IActionResult> Update([FromRoute] int TeamId, UpdateTeamDto teamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var team = await _teamRepo.UpdateTeamAsync(TeamId, _mapper.Map<Team>(teamDto));
            if (team==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetTeamDto>(team));
        }
        [HttpDelete]
        [Route("{TeamId:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int TeamId)
        {
            var team = await _teamRepo.DeleteTeamAsync(TeamId);
            if (team==null)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}