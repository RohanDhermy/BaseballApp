using RohanCrud.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RohanCrud.Adapter;
using RohanCrud.Tools;

namespace RohanCrud.Services
{
    public class TeamNewsService : BaseService, ITeamNewsService
    {
        public IEnumerable<TeamNews> GetAllNews()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.TeamNews_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = null
            };
            return Adapter.LoadObject<TeamNews>(cmdDef);
        }

        public IEnumerable<TeamNews> GetById(int id)
        {
            try
            {
                DbCmdDef cmdDef = new DbCmdDef
                {
                    DbCommandText = "dbo.TeamNews_SelectById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                       SqlDbParameter.Instance.BuildParameter("@Id", true, System.Data.SqlDbType.Int)
                    }
                };
                return Adapter.LoadObject<TeamNews>(cmdDef);
            }
            catch
            {
                throw;
            }
        }


    }
}