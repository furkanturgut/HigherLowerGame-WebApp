using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PlayerDtos
{
    public class CreatePlayerDto
    {
        [Required]
        [MinLength (3, ErrorMessage ="Player Name min 3 char")]
        public string PlayerName { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Value { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TeamId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}