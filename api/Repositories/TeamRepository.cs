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
    public class TeamRepository: ITeamRepository
    {
        private readonly ApplicationDbContext _context ; 
        public TeamRepository(ApplicationDbContext context)
        {
            this._context= context;
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            await _context.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team?> DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return null;
            }
            _context.Remove(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams.Include(t=> t.League).Include(t=> t.Players).ToListAsync();
            return teams;
        }

        public async Task<Team?> GetTeamByIdAsync(int teamId)
        {
            var team = await _context.Teams.Include(t=> t.League).Include(t=> t.Players).FirstOrDefaultAsync(t=> t.Id == teamId);
            if (team==null)
            {
                return null;
            }
            return team;
        }

        public async Task<Team?> UpdateTeamAsync(int teamId, Team team)
        {
            var teamToUpdate = await _context.Teams.FindAsync(teamId);
            if (teamToUpdate == null)
            {
                return null;
            }
            teamToUpdate.TeamName= team.TeamName;
            await _context.SaveChangesAsync();
            return teamToUpdate;
        }
    }
}