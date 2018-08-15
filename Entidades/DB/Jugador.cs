using System;
using System.Collections.Generic;

namespace Entidades.DB
{
    public partial class Jugador
    {
        public Jugador()
        {
            EquipoJugador = new HashSet<EquipoJugador>();
        }

        public int JugadorId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public ICollection<EquipoJugador> EquipoJugador { get; set; }
    }
}
