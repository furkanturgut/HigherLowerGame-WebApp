using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public LeagueRepository(IMapper mapper, ApplicationDbContext context)
        {
            this._mapper= mapper;
            this._context=context;
        }

        public async Task<League> CreateLeagueAsync(League league)
        {
            await _context.Leagues.AddAsync(league);
            await _context.SaveChangesAsync();
            return league;
        }

        public async Task<League?> DeleteLeagueAsync(int leagueId)
        {
            var league = await _context.Leagues.FindAsync(leagueId);
            if (league == null)
            {
                return null;
            }
            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return league;
        }

        public async Task<List<League>> GetAllLeaguesAsync()
        {
            var leagues = await _context.Leagues.Include(p => p.country).Include(p => p.Teams).ToListAsync();
            return leagues;
        }

        public async Task<League?> GetLeagueByIdAsync(int leagueId)
        {
           var league = await _context.Leagues.Include(p=> p.country).Include(p=> p.Teams).FirstOrDefaultAsync(p=> p.Id == leagueId);
            return league;
        }

        public async Task<League?> UpdateLeagueAsync(int leagueId, League league)
        {
            var leagueToUpdate = await _context.Leagues.FindAsync(leagueId);
            if (leagueToUpdate == null)
            {
                return null;
            }
            leagueToUpdate.LeagueName= league.LeagueName;
            await _context.SaveChangesAsync();
            return leagueToUpdate;
        }
    }
}