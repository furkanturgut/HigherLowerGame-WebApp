using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.PlayerDtos
{
    public class GetPlayerDto
    {
         public int Id { get; set; }
        public string PlayerName { get; set; }
        public decimal Value { get; set; }
        public string TeamName { get; set; }
        public string CountryName { get; set; }
    }
}