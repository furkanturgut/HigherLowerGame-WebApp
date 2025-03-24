using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ILeagueRepository
    {
        Task<List<League>> GetAllLeaguesAsync ();
        Task<League?> GetLeagueByIdAsync (int leagueId);
        Task<League> CreateLeagueAsync(League league);
        Task<League?> UpdateLeagueAsync(int leagueId, League league );
        Task<League?> DeleteLeagueAsync(int leagueId);
    }
}