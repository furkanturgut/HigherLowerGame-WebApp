using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPlayerRepository
    {
        Task<ICollection<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(int id);
        Task<bool> PlayerExists(int id);
        Task<Player?> CreatePlayerAsync(Player player);
        Task<Player?> UpdatePlayerAsync(int id, Player player);
        Task<Player?> DeletePlayerAsync(Player player);
        
    }
}