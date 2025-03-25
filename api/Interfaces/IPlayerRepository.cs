using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IPlayerRepository
    {
        Task<ICollection<Player>> GetPlayersAsync(QueryObject queryObject);
        Task<Player?> GetPlayerByIdAsync(int id);
        Task<bool> PlayerExists(int id);
        Task<Player> CreatePlayerAsync(Player player);
        Task<Player?> UpdatePlayerAsync(int id, Player player);
        Task<Player?> DeletePlayerAsync(int PlayerId);
        
    }
}