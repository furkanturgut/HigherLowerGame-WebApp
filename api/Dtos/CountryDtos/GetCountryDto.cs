using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CountryDtos
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}