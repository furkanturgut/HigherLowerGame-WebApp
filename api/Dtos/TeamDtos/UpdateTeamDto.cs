using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TeamDtos
{
    public class UpdateTeamDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Min 5 char")]
        public string TeamName { get; set; }
    }
}