using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.LeagueDto
{
    public class CreateLeagueDto
    {
           public string LeagueName { get; set; }
           public int CountryId { get; set; }
    }
}