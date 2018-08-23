using Dapper;
using Datos.Interfaces.Equipo;
using Entidades.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository.Equipo
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly ProdeContext prodeContext;

        public EquipoRepository(ProdeContext prodeContext)
        {
            this.prodeContext = prodeContext;
        }

        //public async Task<Entidades.DB.Equipo> GetEquipoPorId(int equipoId)
        //{
        //    var sql = $"select * from equipo.Equipo e inner join equipo.EquipoInfo ei on e.EquipoId = ei.EquipoId where e.EquipoId = {equipoId}";

        //    using (var cn = new SqlConnection("Server=.; Database=Prode; Trusted_Connection = True"))
        //    {
        //        var param = new DynamicParameters();

        //        param.Add("@EquipoId", equipoId);

        //        try
        //        {
        //            var equipo = await SqlMapper.QueryFirstAsync<Entidades.DB.Equipo>(cn,
        //                sql,
        //                param,
        //                commandType: System.Data.CommandType.Text);

        //            return equipo;
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }
        //}

        public async Task<Entidades.DB.Equipo> GetEquipoPorId(int equipoId)
        {
            var sql = $"select * from equipo.Equipo e inner join equipo.EquipoInfo ei on e.EquipoId = ei.EquipoId where e.EquipoId = {equipoId}";

            using (var cn = new SqlConnection("Server=.; Database=Prode; Trusted_Connection = True"))
            {
                var param = new DynamicParameters();

                param.Add("@EquipoId", equipoId);

                try
                {
                    var equipo = await GetEquipo(equipoId, sql, cn);

                    return equipo;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private static Task<Entidades.DB.Equipo> GetEquipo(int equipoId, string sql, SqlConnection cn)
        {
            return SqlMapper.QueryFirstAsync<Entidades.DB.Equipo>(cn,
                                    sql,
                                    new { EquipoId = equipoId });
        }
    }
}
