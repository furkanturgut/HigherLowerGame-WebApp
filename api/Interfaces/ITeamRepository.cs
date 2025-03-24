using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> CreateTeamAsync (Team team);
         Task<List<Team>> GetAllTeamsAsync ();
         Task<Team?> GetTeamByIdAsync (int teamId);
         Task<Team?> UpdateTeamAsync (int teamId, Team team);
         Task<Team?> DeleteTeamAsync (int teamId);

    }
}