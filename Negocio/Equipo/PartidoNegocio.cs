using Datos.Interfaces.Equipo;
using Entidades.DB;
using Negocio.Interface.Equipo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Equipo
{
    public class PartidoNegocio : IPartidoNegocio
    {
        #region Atributos
        private readonly IPartidoRepository repository;

        #endregion

        #region Constructor
        public PartidoNegocio(IPartidoRepository repository)
        {
            this.repository = repository;
        }
        #endregion

        #region Metodos
        public Task<IList<PartidoCompleto>> BuscarPartido(string palabrasABuscar, 
            int? faseId, int? torneoId, int? temporadaId)
        {
            return repository.BuscarPartido(palabrasABuscar, faseId, torneoId, temporadaId);
        }
        #endregion
        
    }
}
