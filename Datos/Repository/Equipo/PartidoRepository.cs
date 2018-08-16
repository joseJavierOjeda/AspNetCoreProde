using Datos.Interfaces.Equipo;
using Entidades.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository.Equipo
{
    public class PartidoRepository : IPartidoRepository
    {
        #region Atributos
        private readonly ProdeContext context;

        #endregion

        #region Constructor
        public PartidoRepository(ProdeContext context)
        {
            this.context = context;
        }
        #endregion

        #region Metodos
        public async Task<IList<PartidoCompleto>> BuscarPartido(string palabrasABuscar, 
            int? faseId, int? torneoId, int? temporadaId)
        {

            var resultado = await context.PartidoCompleto
                .FromSql($"exec [partido].[Partido_Buscar] {0},{1},{2},{3}",
                palabrasABuscar,faseId,torneoId,temporadaId).ToListAsync();

            return resultado;
        }

        public async Task<Partido> GetPartidoPorIdAsync(int partidoId)
        {
            var entidad = await context.Partido.FirstOrDefaultAsync(x => x.EquipoIdLocal == partidoId);
            return entidad;
        }


        #endregion
    }
}
