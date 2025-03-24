using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PlayerDtos;

namespace api.Dtos.TeamDtos
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
        public List<GetPlayerDto> players {get;set;}
    }
}