using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlayerDtos;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository playerRepo, IMapper mapper )
        {
            this._playerRepo = playerRepo;
            this._mapper= mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await  _playerRepo.GetPlayersAsync();
            return Ok( _mapper.Map<List<GetPlayerDto>>(players));
        }

        [HttpGet]
        [Route("{Playerid:int}")]
        public async Task<IActionResult> GetById([FromRoute]int Playerid)
        {
            var player = await _playerRepo.GetPlayerByIdAsync(Playerid);
            if (player == null )
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetPlayerDto>(player) );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerDto playerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Mappedplayer = _mapper.Map<Player>(playerDto);
            var player = await _playerRepo.CreatePlayerAsync(Mappedplayer);
            return CreatedAtAction(nameof(GetById), new {Playerid = player.Id} , _mapper.Map<GetPlayerDto>(player));
        }
        [HttpPut]
        [Route("{PlayerId:int}")]
        public async Task<IActionResult> Update([FromRoute] int PlayerId, [FromBody] UpdatePlayerDto playerDto)
        {
            if (!await _playerRepo.PlayerExists(PlayerId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var player = await _playerRepo.UpdatePlayerAsync(PlayerId, _mapper.Map<Player>(playerDto));
            return Ok(_mapper.Map<GetPlayerDto>(player));
        } 
        [HttpDelete]
        [Route("{PlayerId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int PlayerId)
        {
            var player = await _playerRepo.DeletePlayerAsync(PlayerId);
            if(player == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}