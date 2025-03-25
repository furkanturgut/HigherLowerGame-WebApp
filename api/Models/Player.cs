using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public decimal Value { get; set; }
        public string? ImgPath {get;set;}= null;
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        
    }
}