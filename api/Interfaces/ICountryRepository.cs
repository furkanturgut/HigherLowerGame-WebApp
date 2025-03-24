using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync ();
        Task<Country> GetByIdAsync (int CountryId);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country?> UpdateCountryAsync(int CountryId , Country country);
        Task<Country?> DeleteCountryAsync(int Id);

    }
}