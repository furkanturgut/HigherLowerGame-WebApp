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
    public class PlayerRepository: IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> DeletePlayerAsync(int PlayerId)
        {
            var player = await _context.Players.FindAsync(PlayerId);
            if (player == null)
            {
                return null;
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> GetPlayerByIdAsync(int id)
        {
            var player = await _context.Players.Include(p=> p.Country).Include(p=> p.Team).FirstOrDefaultAsync(p=> p.Id == id);
            return player;
        }

        public async Task<ICollection<Player>> GetPlayersAsync(QueryObject queryObject)
        {
            var players = _context.Players.Include(p=> p.Country).Include(p=> p.Team).AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.CountryName))
            {
                players= players.Where(cm=> cm.Country.CountryName.Contains(queryObject.CountryName));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.LeagueName))
            {
                players=players.Where(ln=> ln.Team.League.LeagueName.Contains(queryObject.LeagueName));
            }


            var skipNumber= (queryObject.PageNumber -1) * queryObject.PageSize;
            var toList =await players.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
            var random = new Random();
            var shuffledPlayers= toList.OrderBy(x=> random.Next()).ToList(); 
            return  shuffledPlayers;
        }

        public async Task<bool> PlayerExists(int id)
        {
            return await _context.Players.AnyAsync(p => p.Id == id);
        }

        public async Task<Player?> UpdatePlayerAsync(int id , Player player)
        {
            var playerToUpdate = await _context.Players.FindAsync(id);
            if (playerToUpdate == null)
            {
                return null;
            }
            playerToUpdate.PlayerName = player.PlayerName;
            playerToUpdate.CountryId = player.CountryId;
            playerToUpdate.TeamId = player.TeamId;
            playerToUpdate.Value = player.Value;
            await _context.SaveChangesAsync();
            return playerToUpdate;
        }
    }
}