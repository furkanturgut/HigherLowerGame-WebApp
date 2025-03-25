using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public string? CountryName { get; set; }=null;
        public string? LeagueName { get; set; }=null;
        public int PageNumber { get; set; }= 1;
        public int PageSize { get; set; }= 20;
    }
}