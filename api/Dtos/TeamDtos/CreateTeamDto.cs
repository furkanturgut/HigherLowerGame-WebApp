using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TeamDtos
{
    public class CreateTeamDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Min 5 char")]
        public string TeamName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int LeagueId { get; set; }
    }
}