using Entidades.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces.Equipo
{
    public interface IJugadorRepository 
    {
        Task<IList<Jugador>> GetJugadoresAsync();
        Task<Jugador> GetJugadorPorIdAsync(int id);
    }
}
