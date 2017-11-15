using RohanCrud.Adapter;
using RohanCrud.Models.Domain;
using RohanCrud.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohanCrud.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        public IEnumerable<PlayerResponse> GetAllPlayers()
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Player_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = null
            };
            return Adapter.LoadObject<PlayerResponse>(cmdDef);
        }

        public PlayerResponse GetById(int id)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Player_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
                }
            };
            return Adapter.LoadObject<PlayerResponse>(cmdDef).FirstOrDefault();
        }

        public int Insert(Player model)
        {
            int id = 0;
                DbCmdDef cmdDef = new DbCmdDef
                {
                    DbCommandText = "dbo.Player_Insert",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, System.Data.SqlDbType.NVarChar, 50),
                        SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, System.Data.SqlDbType.NVarChar, 50),
                        SqlDbParameter.Instance.BuildParameter("@TeamId", model.TeamId, System.Data.SqlDbType.Int),
                        SqlDbParameter.Instance.BuildParameter("@BattingAverage", model.BattingAverage, System.Data.SqlDbType.Decimal),
                        SqlDbParameter.Instance.BuildParameter("@OPS", model.OPS, System.Data.SqlDbType.Decimal),
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int, paramDirection: System.Data.ParameterDirection.Output)
                    }
                };
                Adapter.ExecuteQuery(cmdDef, (collection) =>
                {
                    id = collection.GetParamValue<int>("@Id");
                });
                return id;

        }

        public void UpdateById(Player model)
        {
                DbCmdDef cmdDef = new DbCmdDef
                {
                    DbCommandText = "dbo.Player_UpdateById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", model.Id, System.Data.SqlDbType.Int),
                        SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, System.Data.SqlDbType.NVarChar, 50),
                        SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, System.Data.SqlDbType.NVarChar, 50),
                        SqlDbParameter.Instance.BuildParameter("@TeamId", model.TeamId, System.Data.SqlDbType.Int),
                        SqlDbParameter.Instance.BuildParameter("@BattingAverage", model.BattingAverage, System.Data.SqlDbType.Decimal),
                        SqlDbParameter.Instance.BuildParameter("@OPS", model.OPS, System.Data.SqlDbType.Decimal),
                    }
                };

            Adapter.ExecuteQuery(cmdDef);
        }

        public void DeleteById(int id)
        {
            try
            {
                Adapter.ExecuteQuery(new DbCmdDef
                {
                    DbCommandText = "dbo.Player_DeleteById",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
                    }
                });
            }
            catch
            {
                throw;
            }

        }

        public IEnumerable<Team> GetTeams()
        {
            try
            {
                DbCmdDef cmdDef = new DbCmdDef
                {
                    DbCommandText = "dbo.Team_SelectAll",
                    DbCommandType = System.Data.CommandType.StoredProcedure,
                    DbParameters = null
                };
                return Adapter.LoadObject<Team>(cmdDef);
            }
            catch
            {
                throw; 
            }
        }
    }
}