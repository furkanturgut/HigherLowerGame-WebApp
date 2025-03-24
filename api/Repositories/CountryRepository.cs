using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context ; 

        public CountryRepository(ApplicationDbContext context)
        {
            this._context= context;
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<Country?> DeleteCountryAsync(int Id)
        {
           var country = await _context.Countries.FindAsync(Id);
            if (country == null)
            {
                return null;
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetByIdAsync(int CountryId)
        {
            var country = await _context.Countries.FindAsync(CountryId);
            return country;
        }

        public async Task<Country?> UpdateCountryAsync(int CountryId, Country country)
        {
            var countryToUpdate = await _context.Countries.FindAsync(CountryId);
            if (countryToUpdate == null)
            {
                return null;
            }
            countryToUpdate.CountryName = country.CountryName;
            await _context.SaveChangesAsync();
            return countryToUpdate;
        }
    }
}