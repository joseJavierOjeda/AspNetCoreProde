﻿using Datos.Interfaces.Equipo;
using Entidades.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository.Equipo
{
    public class JugadorRepository: IJugadorRepository
    {
        #region Atributos
        private readonly ProdeContext context;

        #endregion

        #region Constructor
        public JugadorRepository(ProdeContext context)
        {
            this.context = context;
        }
        
        #endregion

        #region Metodos
        public async Task<IList<Jugador>> GetJugadoresAsync()
        {
            return await context.Jugador.ToListAsync();
        }

        public async Task<Jugador> GetJugadorPorIdAsync(int id)
        {
            return await context.Jugador
                .SingleOrDefaultAsync(m => m.JugadorId == id);
        }

        public async Task<IList<PartidoCompleto>> BuscarPartido(string palabrasABuscar, 
            int? faseId, int? torneoId, int? temporadaId)
        {

            var resultado = await context.PartidoCompleto
                .FromSql($"exec [partido].[Partido_Buscar] {0},{1},{2},{3}",
                palabrasABuscar,faseId,torneoId,temporadaId).ToListAsync();

            return resultado;
        }
        #endregion

    }
}
