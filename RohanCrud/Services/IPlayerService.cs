using System.Collections.Generic;
using RohanCrud.Models.Domain;

namespace RohanCrud.Services
{
    public interface IPlayerService
    {
        void DeleteById(int id);
        IEnumerable<PlayerResponse> GetAllPlayers();
        PlayerResponse GetById(int id);
        int Insert(Player model);
        void UpdateById(Player model);
        IEnumerable<Team> GetTeams(); 
    }
}