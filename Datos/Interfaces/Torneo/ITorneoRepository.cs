using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces.Torneo
{
    public interface ITorneoRepository
    {
        Task<IList<Entidades.DB.Torneo>> GetTorneos();
    }
}
