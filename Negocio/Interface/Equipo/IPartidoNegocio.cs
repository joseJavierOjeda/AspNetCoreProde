using Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interface.Equipo
{
    public interface IPartidoNegocio
    {
        Task<IList<PartidoCompleto>> BuscarPartido(string palabrasABuscar, int? faseId, int? torneoId, int? temporadaId);
    }
}
