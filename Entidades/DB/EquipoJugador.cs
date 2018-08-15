using System;
using System.Collections.Generic;

namespace Entidades.DB
{
    public partial class EquipoJugador
    {
        public int EquipoJugadorId { get; set; }
        public int EquipoId { get; set; }
        public int JugadorId { get; set; }
        public DateTime FechaVigenciaDesde { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }

        public Equipo Equipo { get; set; }
        public Jugador Jugador { get; set; }
    }
}
