using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class League
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public int CountryId { get; set; }
        public Country country { get; set; }
        public List<Team> Teams { get; set; }
    }
}