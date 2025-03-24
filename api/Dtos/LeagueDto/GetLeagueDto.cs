using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TeamDtos;
using api.Models;

namespace api.Dtos.LeagueDto
{
    public class GetLeagueDto
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public string  CountryName { get; set; }
        public List<GetTeamDto> Teams { get; set; }
    }
}