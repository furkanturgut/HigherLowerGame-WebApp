using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayerController(IPlayerRepository playerRepo)
        {
            this._playerRepo = playerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await  _playerRepo.GetPlayersAsync();
            return Ok(stocks);
        }
    }
}