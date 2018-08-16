using Datos.Interfaces.Equipo;
using Entidades.DB;
using Negocio.Interface.Equipo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Equipo
{
    public class JugadorNegocio : IJugadorNegocio
    {
        #region Atributos
        private readonly IJugadorRepository repository;

        #endregion

        #region Constructor
        public JugadorNegocio(IJugadorRepository repository)
        {
            this.repository = repository;
        }
        
        #endregion

        #region Metodos
        public Task<IList<Jugador>> GetJugadoresAsync()
        {
            return repository.GetJugadoresAsync();
        }

        public Task<Jugador> GetJugadorPorIdAsync(int id)
        {
            return repository.GetJugadorPorIdAsync(id);
        }

        public Task<IList<PartidoCompleto>> BuscarPartido(string palabrasABuscar, 
            int? faseId, int? torneoId, int? temporadaId)
        {
            return repository.BuscarPartido(palabrasABuscar, faseId, torneoId, temporadaId);
        }

        #endregion
        
    }
}
