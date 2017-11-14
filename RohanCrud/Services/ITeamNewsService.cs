using System.Collections.Generic;
using RohanCrud.Models.Domain;

namespace RohanCrud.Services
{
    public interface ITeamNewsService
    {
        IEnumerable<TeamNews> GetAllNews();
        IEnumerable<TeamNews> GetById(int id);
    }
}