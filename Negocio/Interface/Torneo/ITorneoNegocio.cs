using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interface.Torneo
{
    public interface ITorneoNegocio
    {
        Task<IList<Entidades.DB.Torneo>> GetTorneos();
    }
}
